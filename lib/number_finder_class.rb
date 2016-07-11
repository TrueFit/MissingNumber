class NumberFinder

  def findMissingNumber(lineOfFile)
    stringArr = lineToArray(lineOfFile)
    numberArr = convertToInts(stringArr)
    checkForMissingNumber(numberArr)
  end

  def lineToArray(fileString)
    stringArr = fileString.split(",")
    return stringArr
  end

  def convertToInts(stringArr)
    indexCount = 0
    unsortedArr = Array.new
    stringArr.each do |numChar|
      number = numChar.to_i
      unsortedArr[indexCount] = number
      indexCount = indexCount + 1
    end
    return unsortedArr
  end

  def checkForMissingNumber(unsortedArr)
    numberArray = unsortedArr.sort
    missingNum = numberArray.last+1
    puts missingNum
    # Checks each number agaist the next highest EXCEPT for the last number
    (0..numberArray.length-2).each do |k|
      if(numberArray[k]+1 != numberArray[k+1])
        missingNum = numberArray[k]+1
        return missingNum
      end
    end
  end
end
