require "../lib/number_finder_class"

describe NumberFinder do
  before :each do
    @num_finder = NumberFinder.new
  end

  describe ".get_missing_number" do

    context "given a string of one number" do
      it "returns nil" do
        result = @num_finder.get_missing_number('1')
        expect(result).to eql(nil)
      end
    end

    context "given a string of one double digit number" do
      it "returns nil" do
        result = @num_finder.get_missing_number('10')
        expect(result).to eql(nil)
      end
    end

    context "given an ordered string of two numbers separated by a comma with one number missing sequentially" do
      it "returns the missing sequential number" do
        result = @num_finder.get_missing_number('1,3')
        expect(result).to eql(2)
      end
    end

    context "given a string of one number followed by one letter" do
      it "returns nil" do
        result = @num_finder.get_missing_number('1t')
        expect(result).to eql(nil)
      end
    end

    context "given a string of one letter followed by one number" do
      it "returns nil" do
        result = @num_finder.get_missing_number('t3')
        expect(result).to eql(nil)
      end
    end

    context "given a string of multiple letters mixed with one number" do
      it "returns nil" do
        result = @num_finder.get_missing_number('t3rr')
        expect(result).to eql(nil)
      end
    end

    context "given a string of one number and one letter separated by a comma" do
      it "returns nil" do
        result = @num_finder.get_missing_number('1,t')
        expect(result).to eql(nil)
      end
    end

    context "given a string of a letter followed by a number with another number separated by a comma with one number missing sequentially" do
      it "returns the missing sequential number" do
        result = @num_finder.get_missing_number('1t,3')
        expect(result).to eql(2)
      end
    end

    context "given an unordered string of a double digit number split by a letter, and another number separated by a comma with one number missing sequentially" do
      it "returns the missing sequential number" do
        result = @num_finder.get_missing_number('14, 1t2')
        expect(result).to eql(13)
      end
    end

    context "given a string of two letters separated by commas" do
      it "returns nil" do
        result = @num_finder.get_missing_number('t,r')
        expect(result).to eql(nil)
      end
    end

    context "given an unordered string of multiple numbers with no number missing" do
      it "returns nil" do
        result = @num_finder.get_missing_number('1,2,3,4')
        expect(result).to eql(nil)
      end
    end

    context "given an unordered string of multiple numbers with one number missing in sequence" do
      it "returns the missing number" do
        result = @num_finder.get_missing_number('1,5,3,2')
        expect(result).to eql(4)
      end
    end

    context "given an unordered string of multiple numbers and have duplicates with one number missing in sequence" do
      it "returns the missing number" do
        result = @num_finder.get_missing_number('9,8,10,11,14,11,12,14')
        expect(result).to eql(13)
      end
    end

    context "given an unordered string of multiple numbers and have duplicates with no number missing" do
      it "returns nil" do
        result = @num_finder.get_missing_number('9,8,10,11,14,11,12,14,13')
        expect(result).to eql(nil)
      end
    end

  end
end
