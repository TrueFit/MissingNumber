window.onload = function() {
  var app = new Vue({
    el: "#app",
    data: {
      fileContent: null,
      fileData: []
    }, //end data
    methods: {
      fileUpload(e) {
        const self = this;
        const file = e.target.files[0];
        reader = new FileReader();
        reader.onload = function(e) {
          self.fileContent = reader.result;
          self.processFile();
        };
        reader.readAsText(file);
      }, //End fileUpload
      processFile() {
        var sortedPattern = [];
        //Clears existing array
        app.fileData = [];
        //Clean content of non-numeric characters
        var splitContent = this.fileContent.replace(/[^0-9\,\n\s]/g, '');
        //Split file contents into individual lines
        splitContent = splitContent.split("\n");
        //Break down file data
        splitContent.forEach(function(e, i) {
          sortedPattern.push(e.split(",").sort(function(a, b) { return a - b; }));
          //get missing number
          var x = sortedPattern[i][0];
          var missingNumber = '';
          sortedPattern[i].forEach(function(e, index) {
            if (x != e) {
              missingNumber = x;
              x++;
            }
            x++;
          }); //end get missing number

          //Populate fileData
          app.fileData.push({
            line: i + 1,
            originalPattern: e,
            missingNumber: missingNumber
          })
        }); //End forEach
      }, //end processFile
    }, //end methods
  }); //end app
};
