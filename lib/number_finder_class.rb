class NumberFinder

  def get_missing_number(input_string)
    string_array = to_string_array(input_string)

    if(string_array.length > 1)
      unsorted_arr = to_int_array(string_array)
      sorted_arr = sort_numbers(unsorted_arr)
      missing_num = check_for_missing_number(sorted_arr)
    end
  end

  private

  def to_string_array(input_string)
    string_array = input_string.split(",")
  end


  def to_int_array(string_array)
    index_counter = 0
    unsorted_arr = Array.new

    string_array.each do |numchar|
      numchar = delete_extra_letters(numchar)
      number = numchar.to_i
      unsorted_arr[index_counter] = number
      index_counter = index_counter + 1
    end

    return unsorted_arr
  end


  def delete_extra_letters(input)
    input = input.gsub(/[^[0-9]]/,"")
  end


  def sort_numbers(unsorted_arr)
    unsorted_arr.sort
  end


  def check_for_missing_number(sorted_arr)
    missing_num = nil

    (0..sorted_arr.length - 2).each do |k|
      # Checks each number agaist the next highest EXCEPT for the last number &&
      # checks for possible duplicate numbers
      if(sorted_arr[k] + 1 != sorted_arr[k + 1] && sorted_arr[k] != sorted_arr[k + 1])
        missing_num = sorted_arr[k] + 1
      end
    end
    return missing_num
  end

end
