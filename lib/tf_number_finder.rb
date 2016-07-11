require "./number_finder_class"

finder = NumberFinder.new

File.open("test.txt", "r").each_line do |line|
  puts finder.findMissingNumber(line)
end
