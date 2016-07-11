require "../lib/number_finder_class"

describe NumberFinder do
  before :each do
    @numFinder = NumberFinder.new
  end

  describe ".lineToArray" do

    context "given the string '1'" do
      it "returns ['1']" do
        result = @numFinder.lineToArray("1")
        expect(result).to eql(['1'])
      end
    end

    context "given the string '10'" do
      it "returns ['10']" do
        result = @numFinder.lineToArray("10")
        expect(result).to eql(['10'])
      end
    end

    context "given the string '0,1,3'" do
      it "returns ['0','1','3']" do
        result = @numFinder.lineToArray("0,1,3")
        expect(result).to eql(['0','1','3'])
      end
    end

    context "given the string '1,12,3'" do
      it "returns ['1','12','3']" do
        result = @numFinder.lineToArray("1,12,3")
        expect(result).to eql(['1','12','3'])
      end
    end

    context "given the string '1,5,9,4,3'" do
      it "returns ['1','5','9','4','3']" do
        result = @numFinder.lineToArray("1,5,9,4,3")
        expect(result).to eql(['1','5','9','4','3'])
      end
    end
  end



  describe ".convertToInts" do

    context "given the array ['2']" do
      it "it returns [2]" do
        testArray = ['2']
        result = @numFinder.convertToInts(testArray)
        expect(result).to eql([2])
      end
    end

    context "given the array ['14']" do
      it "it returns [14]" do
        testArray = ['14']
        result = @numFinder.convertToInts(testArray)
        expect(result).to eql([14])
      end
    end

    context "given the array ['0','2','3']" do
      it "it returns [0,2,3]" do
        testArray = ['0','2','3']
        result = @numFinder.convertToInts(testArray)
        expect(result).to eql([0,2,3])
      end
    end

    context "given the array ['9','10','12']" do
      it "it returns [9,10,12]" do
        testArray = ['9','10','12']
        result = @numFinder.convertToInts(testArray)
        expect(result).to eql([9,10,12])
      end
    end
  end


  describe ".checkForMissingNumber" do
    context "given [3,1]" do
      it "returns 2" do
        testArray = [3,1]
        result = @numFinder.checkForMissingNumber(testArray)
        expect(result).to eql(2)
      end
    end

    context "given [9,11]" do
      it "returns 10" do
        testArray = [9,11]
        result = @numFinder.checkForMissingNumber(testArray)
        expect(result).to eql(10)
      end
    end

    context "given [3,1,5,2]" do
      it "returns 4" do
        testArray = [3,1,5,2]
        result = @numFinder.checkForMissingNumber(testArray)
        expect(result).to eql(4)
      end
    end

  end

  describe ".findMissingNumber" do
    context "given '1,3'" do
      it "returns 2" do
        result = @numFinder.findMissingNumber('1,3')
        expect(result).to eql(2)
      end
    end
  end

end
