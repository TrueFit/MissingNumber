require "../lib/number_finder_class"

describe NumberFinder do
  before :each do
    @numFinder = NumberFinder.new
  end


  describe ".lineToArray" do

    context "given a single digit number as a string" do
      it "returns that single digit number as a string in an array" do
        result = @numFinder.lineToArray("1")
        expect(result).to eql(['1'])
      end
    end

    context "given a double digit number as a string" do
      it "returns that double digit number as a string in an array" do
        result = @numFinder.lineToArray("10")
        expect(result).to eql(['10'])
      end
    end

    context "given a string of multiple single digit numbers separated by commas" do
      it "returns an array of those single digit numbers as strings w/o commas" do
        result = @numFinder.lineToArray("0,1,3")
        expect(result).to eql(['0','1','3'])
      end
    end

    context "given a string of single and double digit numbers as strings separated by commas " do
      it "returns an array of those numbers as strings w/o commas" do
        result = @numFinder.lineToArray("1,12,3")
        expect(result).to eql(['1','12','3'])
      end
    end

    context "given a string of lots of numbers out of order separated by commas" do
      it "returns an array of strings of those numbers still out of order" do
        result = @numFinder.lineToArray("1,5,9,4,3")
        expect(result).to eql(['1','5','9','4','3'])
      end
    end
  end



  describe ".convertToInts" do

    context "given an array of a single digit number as a string" do
      it "returns an array of that single digit number as an integer" do
        testArray = ['2']
        result = @numFinder.convertToInts(testArray)
        expect(result).to eql([2])
      end
    end

    context "given an array of a double digit number as a string" do
      it "returns an array of that double digit number as an integer" do
        testArray = ['14']
        result = @numFinder.convertToInts(testArray)
        expect(result).to eql([14])
      end
    end

    context "given an array of single digit numbers as strings" do
      it "returns an array of those single digit numbers as integers" do
        testArray = ['0','2','3']
        result = @numFinder.convertToInts(testArray)
        expect(result).to eql([0,2,3])
      end
    end

    context "given an array of a mix of single/double digit numbers as strings" do
      it "returns an array of those numbers as integers" do
        testArray = ['9','10','12']
        result = @numFinder.convertToInts(testArray)
        expect(result).to eql([9,10,12])
      end
    end
  end



  describe ".sortNumbers" do
    context "given an array of two single digit numbers with no missing integers in between in order of largest to smallest" do
      it "returns an array of those numbers sorted from smallest to largest" do
        testArray = [2,1]
        result = @numFinder.sortNumbers(testArray)
        expect(result).to eql([1,2])
      end
    end

    context "given an unsorted array of multiple numbers with no missing sequential integers" do
      it "returns an array of those numbers sorted from smallest to largest" do
        testArray = [1,3,2,4]
        result = @numFinder.sortNumbers(testArray)
        expect(result).to eql([1,2,3,4])
      end
    end

    context "given an unsorted array of multiple numbers with sequential integers missing" do
      it "returns an array of those numbers sorted from smallest to largest" do
        testArray = [1,3,9,4]
        result = @numFinder.sortNumbers(testArray)
        expect(result).to eql([1,3,4,9])
      end
    end
  end



  describe ".checkForMissingNumber" do
    context "given a sorted array of two single digit numbers one number apart" do
      it "returns the single digit number in between them" do
        testArray = [1,3]
        result = @numFinder.checkForMissingNumber(testArray)
        expect(result).to eql(2)
      end
    end

    context "given an ordered array of a single and a double digit number with one integer missing in between" do
      it "returns the number missing in between the other two integers" do
        testArray = [9,11]
        result = @numFinder.checkForMissingNumber(testArray)
        expect(result).to eql(10)
      end
    end

    context "given an ordered array of multiple numbers with one integer missing" do
      it "returns the integer that was " do
        testArray = [1,2,3,5]
        result = @numFinder.checkForMissingNumber(testArray)
        expect(result).to eql(4)
      end
    end
  end



  describe ".findMissingNumber" do
    context "given a string of two numbers not in order with one number missing sequentially" do
      it "returns the missing sequential number" do
        result = @numFinder.findMissingNumber('1,3')
        expect(result).to eql(2)
      end
    end
  end



  describe ".deleteExtraLetters" do
    context "given a string containing a single letter" do
      it "returns an empty string" do
        result = @numFinder.deleteExtraLetters("s")
        expect(result).to eql('')
      end
    end

    context "given a string that contains a single digit number" do
      it "returns the same string containing that single digit number" do
        result = @numFinder.deleteExtraLetters("1")
        expect(result).to eql("1")
      end
    end

    context "given a string that contains a multiple digit number" do
      it "returns the same string containing that multiple digit number" do
        result = @numFinder.deleteExtraLetters("193")
        expect(result).to eql("193")
      end
    end

    context "given a string that contains multiple letters" do
      it "returns an empty string" do
        result = @numFinder.deleteExtraLetters("alottaletters")
        expect(result).to eql('')
      end
    end

    context "given a string that contains a single digit number followed by a letter" do
      it "returns a string containing that single digit number only" do
        result = @numFinder.deleteExtraLetters("1s")
        expect(result).to eql("1")
      end
    end

    context "given a string that contains a letter followed by a single digit number" do
      it "returns a string containing that single digit number only" do
        result = @numFinder.deleteExtraLetters("r4")
        expect(result).to eql("4")
      end
    end

    context "given a string that contains a single digit, a letter, then another single digit number" do
      it "returns a string containing only the two numbers in their same order" do
        result = @numFinder.deleteExtraLetters("1s2")
        expect(result).to eql("12")
      end
    end

    context "given a string that contains a letter, a single digit number, then another letter" do
      it "returns a string containing only the number" do
        result = @numFinder.deleteExtraLetters("r1")
        expect(result).to eql("1")
      end
    end

    context "given a string that contains two letters then a multiple digit number" do
      it "returns a string containing only the number" do
        result = @numFinder.deleteExtraLetters("wp10")
        expect(result).to eql("10")
      end
    end
  end
end
