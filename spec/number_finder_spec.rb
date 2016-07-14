require "../lib/number_finder_class"

describe NumberFinder do
  before :each do
    @numFinder = NumberFinder.new
  end


  describe ".to_string_array" do

    context "given a single digit number as a string" do
      it "returns that single digit number as a string in an array" do
        result = @numFinder.to_string_array("1")
        expect(result).to eql(['1'])
      end
    end

    context "given a double digit number as a string" do
      it "returns that double digit number as a string in an array" do
        result = @numFinder.to_string_array("10")
        expect(result).to eql(['10'])
      end
    end

    context "given a string of multiple single digit numbers separated by commas" do
      it "returns an array of those single digit numbers as strings w/o commas" do
        result = @numFinder.to_string_array("0,1,3")
        expect(result).to eql(['0','1','3'])
      end
    end

    context "given a string of single and double digit numbers as strings separated by commas " do
      it "returns an array of those numbers as strings w/o commas" do
        result = @numFinder.to_string_array("1,12,3")
        expect(result).to eql(['1','12','3'])
      end
    end

    context "given a string of lots of numbers out of order separated by commas" do
      it "returns an array of strings of those numbers still out of order" do
        result = @numFinder.to_string_array("1,5,9,4,3")
        expect(result).to eql(['1','5','9','4','3'])
      end
    end
  end



  describe ".to_int_array" do

    context "given an array of a single digit number as a string" do
      it "returns an array of that single digit number as an integer" do
        testArray = ['2']
        result = @numFinder.to_int_array(testArray)
        expect(result).to eql([2])
      end
    end

    context "given an array of a double digit number as a string" do
      it "returns an array of that double digit number as an integer" do
        testArray = ['14']
        result = @numFinder.to_int_array(testArray)
        expect(result).to eql([14])
      end
    end

    context "given an array of single digit numbers as strings" do
      it "returns an array of those single digit numbers as integers" do
        testArray = ['0','2','3']
        result = @numFinder.to_int_array(testArray)
        expect(result).to eql([0,2,3])
      end
    end

    context "given an array of a mix of single/double digit numbers as strings" do
      it "returns an array of those numbers as integers" do
        testArray = ['9','10','12']
        result = @numFinder.to_int_array(testArray)
        expect(result).to eql([9,10,12])
      end
    end
  end



  describe ".sort_numbers" do
    context "given an array of two single digit numbers with no missing integers in between in order of largest to smallest" do
      it "returns an array of those numbers sorted from smallest to largest" do
        testArray = [2,1]
        result = @numFinder.sort_numbers(testArray)
        expect(result).to eql([1,2])
      end
    end

    context "given an unsorted array of multiple numbers with no missing sequential integers" do
      it "returns an array of those numbers sorted from smallest to largest" do
        testArray = [1,3,2,4]
        result = @numFinder.sort_numbers(testArray)
        expect(result).to eql([1,2,3,4])
      end
    end

    context "given an unsorted array of multiple numbers with sequential integers missing" do
      it "returns an array of those numbers sorted from smallest to largest" do
        testArray = [1,3,9,4]
        result = @numFinder.sort_numbers(testArray)
        expect(result).to eql([1,3,4,9])
      end
    end
  end



  describe ".check_for_missing_number" do
    context "given an array with only one number in it" do
      it "returns nil" do
        testArray = [3]
        result = @numFinder.check_for_missing_number(testArray)
        expect(result).to eql(nil)
      end
    end

    context "given a sorted array of two single digit numbers with one number missing in that sequence" do
      it "returns the single digit number in between them" do
        testArray = [1,3]
        result = @numFinder.check_for_missing_number(testArray)
        expect(result).to eql(2)
      end
    end

    context "given an ordered array of a single and a double digit number with one integer missing in between" do
      it "returns the number missing in between the other two integers" do
        testArray = [9,11]
        result = @numFinder.check_for_missing_number(testArray)
        expect(result).to eql(10)
      end
    end

    context "given an ordered array of two numbers with no integer missing in sequence" do
      it "returns nil" do
        testArray = [1,2]
        result = @numFinder.check_for_missing_number(testArray)
        expect(result).to eql(nil)
      end
    end

    context "given an ordered array of multiple numbers with one integer missing in that sequence" do
      it "returns the integer that was missing" do
        testArray = [1,2,3,5]
        result = @numFinder.check_for_missing_number(testArray)
        expect(result).to eql(4)
      end
    end

    context "given an ordered array of multiple numbers with no integer missing in sequence" do
      it "returns nil" do
        testArray = [1,2,3,4]
        result = @numFinder.check_for_missing_number(testArray)
        expect(result).to eql(nil)
      end
    end

    context "given an ordered array of multiple numbers with a duplicate number and an integer missing in sequence" do
      it "returns the integer that was missing" do
        testArray = [1,2,2,4]
        result = @numFinder.check_for_missing_number(testArray)
        expect(result).to eql(3)
      end
    end

    context "given an ordered array of multiple numbers with multiple duplicate numbers and an integer missing in sequence" do
      it "returns the integer that was missing" do
        testArray = [1,1,2,2,4,4,4]
        result = @numFinder.check_for_missing_number(testArray)
        expect(result).to eql(3)
      end
    end

  end



  describe ".get_missing_number" do
    context "given a string of two numbers not in order with one number missing sequentially" do
      it "returns the missing sequential number" do
        result = @numFinder.get_missing_number('1,3')
        expect(result).to eql(2)
      end
    end
  end



  describe ".delete_extra_letters" do
    context "given a string containing a single letter" do
      it "returns an empty string" do
        result = @numFinder.delete_extra_letters("s")
        expect(result).to eql('')
      end
    end

    context "given a string that contains a single digit number" do
      it "returns the same string containing that single digit number" do
        result = @numFinder.delete_extra_letters("1")
        expect(result).to eql("1")
      end
    end

    context "given a string that contains a multiple digit number" do
      it "returns the same string containing that multiple digit number" do
        result = @numFinder.delete_extra_letters("193")
        expect(result).to eql("193")
      end
    end

    context "given a string that contains multiple letters" do
      it "returns an empty string" do
        result = @numFinder.delete_extra_letters("alottaletters")
        expect(result).to eql('')
      end
    end

    context "given a string that contains a single digit number followed by a letter" do
      it "returns a string containing that single digit number only" do
        result = @numFinder.delete_extra_letters("1s")
        expect(result).to eql("1")
      end
    end

    context "given a string that contains a letter followed by a single digit number" do
      it "returns a string containing that single digit number only" do
        result = @numFinder.delete_extra_letters("r4")
        expect(result).to eql("4")
      end
    end

    context "given a string that contains a single digit, a letter, then another single digit number" do
      it "returns a string containing only the two numbers in their same order" do
        result = @numFinder.delete_extra_letters("1s2")
        expect(result).to eql("12")
      end
    end

    context "given a string that contains a letter, a single digit number, then another letter" do
      it "returns a string containing only the number" do
        result = @numFinder.delete_extra_letters("r1")
        expect(result).to eql("1")
      end
    end

    context "given a string that contains two letters then a multiple digit number" do
      it "returns a string containing only the number" do
        result = @numFinder.delete_extra_letters("wp10")
        expect(result).to eql("10")
      end
    end
  end
end
