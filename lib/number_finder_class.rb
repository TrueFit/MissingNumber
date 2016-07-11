class NumberFinder

  def findMissingNumber(lineOfFile)
    stringArr = lineToArray(lineOfFile)
    if(stringArr.length>1)
      numberArr = convertToInts(stringArr)
      missingNum = checkForMissingNumber(numberArr)
    end
  end

  def lineToArray(fileString)
    stringArr = fileString.split(",")
  end

  def convertToInts(stringArr)
    indexCount = 0
    unsortedArr = Array.new
    stringArr.each do |numChar|
      if(checkIfDigit(numChar)==true)
        number = numChar.to_i
        unsortedArr[indexCount] = number
        indexCount = indexCount + 1
      end
    end
    return unsortedArr
  end

  def checkIfDigit(input)
    if(/[0-9]/.match(input) == nil)
      return false
    else
      return true
    end
  end

  def checkForMissingNumber(unsortedArr)
    numberArray = unsortedArr.sort
    missingNum = ""
    # Checks each number agaist the next highest EXCEPT for the last number
    (0..numberArray.length-2).each do |k|
      if(numberArray[k]+1 != numberArray[k+1])
        missingNum = numberArray[k]+1
      end
    end
    return missingNum
  end
end
