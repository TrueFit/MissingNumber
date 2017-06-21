var App = React.createClass({
    getInitialState: function () {
        return {
            Input: new Array(),
            Output: new Array()
        };
    },
    handleNewData: function (newData) {
        this.setState({ Input: newData != null ? newData.Input : new Array(), Output: newData != null ? newData.Output : new Array() });
    },
    render() {
        return (
            <div className="mainDiv">
                <FileUploadForm postUrl={this.props.postUrl} onNewData={this.handleNewData} />

                <section className="input-output-container">
                    <Input input={this.state.Input} />
                    <Output output={this.state.Output} />
                </section>
            </div>
        )
    }
});

var Input = React.createClass({
    render() {
        if (this.props.input == null || this.props.input.length == 0) {
            return null;
        }
        return (
            <div className="input-div">
                <label>Sequence</label>
                <ul className="list-group">
                    {this.props.input.map(function (line, index) {
                        return <li key={index} className="list-group-item"> {line} </li>;
                    })}
                </ul>
            </div>
        )
    }
});

var Output = React.createClass({
    render() {
        if (this.props.output == null || this.props.output.length == 0) {
            return null;
        }
        return (
            <div className="output-div">
                <label>Missing Number</label>
                <ul className="list-group">
                    {this.props.output.map(function (line, index) {
                        return <li key={index} className="list-group-item"> {line} </li>;
                    })}
                </ul>
            </div>
        )
    }
});

var FileUploadForm = React.createClass({
    propTypes: {
        postUrl: React.PropTypes.string,
        handleNewData: React.PropTypes.func
    },

    handleResponse: function (response) {
        response = JSON.parse(response);
        switch (response) {
            case "NoFile":
                alert("Something went wrong when uploading the file. Please try again.");
                this.props.onNewData(null);
                break;
            case "BadFileExtension":
                alert("This is not a valid extension. Please upload either .csv or .txt files.");
                this.props.onNewData(null);
                break;
            case 'BadData':
                alert("File did not contain sequence of numbers.");
                this.props.onNewData(null);
                break;
            default:
                this.props.onNewData(response);
                break;
        }
    },

    handleFileUpload: function () {
        //check if there actually is a file and the user didn't click cancel
        var file = document.getElementById('file').files.item(0);
        if (file !== null) {
            //check file size. 2GB is the maximum supported by all browsers.
            if (file.size < 2000000) {
                document.getElementById('filename').value = file.name;
                var data = new FormData(document.getElementById("fileUploadForm"));
                var xhr = new XMLHttpRequest();
                xhr.open('post', this.props.postUrl, true);
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == XMLHttpRequest.DONE) {
                        this.handleResponse(xhr.responseText);
                    }
                }.bind(this);
                xhr.send(data);
            }
            else {
                alert("File cannot be bigger than 2GB.");
            }

        }

    },

    render: function () {
        return (
            <div className="file-upload-div">
                <label>Please Select a Flat File to Upload (.csv or .txt)</label>
                <form id="fileUploadForm">
                    <div className="input-group">
                        <label className="input-group-btn">
                            <span className="btn btn-primary">Browse&hellip;
                            <input type="file" name="file" id="file" className="hidden" onChange={this.handleFileUpload} accept=".csv, .txt" />
                            </span>
                        </label>
                        <input id="filename" type="text" className="form-control" readOnly />
                    </div>
                </form>
            </div>
        )
    }
});

ReactDOM.render(
    <App postUrl="/Home/MissingNumbersCheck" />,
    document.getElementById('content')
);