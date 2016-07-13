class NumberFinder

  def findMissingNumber(lineOfFile)
    stringArr = lineToArray(lineOfFile)
    if(stringArr.length>1)
      unsortedArr = convertToInts(stringArr)
      numberArr = sortNumbers(unsortedArr)
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
      numchar = deleteExtraLetters(numChar)
      number = numChar.to_i
      unsortedArr[indexCount] = number
      indexCount = indexCount + 1
    end
    return unsortedArr
  end

  def deleteExtraLetters(input)
    input = input.gsub(/[^[0-9]]/,"")
  end

  def sortNumbers(unsortedArr)
    numberArray = unsortedArr.sort
  end

  def checkForMissingNumber(numberArray)
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
