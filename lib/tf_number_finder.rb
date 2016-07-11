require "./number_finder_class"

find_a_num = NumberFinder.new

File.open("test.txt", "r").each_line do |line|
  find_a_num.findMissingNumber(line)
end
