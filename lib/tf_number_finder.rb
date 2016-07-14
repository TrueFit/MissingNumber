require "./number_finder_class"

# To change the input, edit the path below to point to
# whichever file you want as input.
fileInput = "../spec/test.txt"


finder = NumberFinder.new

File.open(fileInput, "r").each_line do |line|
  puts finder.get_missing_number(line)
end
