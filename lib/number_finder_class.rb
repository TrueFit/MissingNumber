class NumberFinder

  def get_missing_number(lineOfFile)
    stringArr = to_string_array(lineOfFile)
    if(stringArr.length>1)
      unsortedArr = to_int_array(stringArr)
      numberArr = sort_numbers(unsortedArr)
      missingNum = check_for_missing_number(numberArr)
    end
  end

  def to_string_array(fileString)
    stringArr = fileString.split(",")
  end

  def to_int_array(stringArr)
    indexCount = 0
    unsortedArr = Array.new
    stringArr.each do |numChar|
      numchar = delete_extra_letters(numChar)
      number = numChar.to_i
      unsortedArr[indexCount] = number
      indexCount = indexCount + 1
    end
    return unsortedArr
  end

  def delete_extra_letters(input)
    input = input.gsub(/[^[0-9]]/,"")
  end

  def sort_numbers(unsortedArr)
    numberArray = unsortedArr.sort
  end

  def check_for_missing_number(numberArray)
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
