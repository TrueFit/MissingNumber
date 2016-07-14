Missing Number
==============

The Problem
-----------
Please write a program which finds the missing number in a sequential series of numbers. The program should:

1. Accept a flat file as input.
	1. Each new line will contain a set of sequential numbers with one number missing.
	2. Each series will be comma delimited and in a random order
2. Output the missing number for each series

Sample Input
------------
1,2,3,4,5,6,7,8,9,10,12

24,26,27,29,28

1,2,4,5

99,100,101,102,103,104,105,107

109,105,107,108,106,110,112,111,118,116,115,114,117

Sample Output
-------------
11

25

3

106

113

The Fine Print
--------------
Please use whatever technology and techniques you feel are applicable to solve the problem. We suggest that you approach this exercise as if this code was part of a larger system. The end result should be representative of your abilities and style.

Please fork this repository. When you have completed your solution, please issue a pull request to notify us that you are ready.

Have fun.



Finished Program
================

Instructions
------------
- Accepting a flat file can be found in the following directory:
	"/MissingNumber/lib/tf_number_finder.rb".
	To change the file input, simply edit the file path where the comments specify.

- It seemed prudent to create a class for finding a missing number to capitalize on possible re-use.
	The class NumberFinder can be found in the following directory:
	"/MissingNumber/lib/number_finder_class.rb".

- To find a missing number first create an instance of the NumberFinder class.
	Then, call the get_missing_number function, pass in the input string, and output the result.
	example:
		classInstance = NumberFinder.new
		puts classInstance.get_missing_number(someString)

Discussion Points
-----------------
Some possible issues I foresaw were as follows:
1. The input would only have one number in the sequence -> "1"
	- The output returns nil as there is no number missing

2. The input would be a full sequence with no number missing -> "1,2,3"
	- The output returns nil as there is no number missing

3. The input would be a non-digit -> "Y"
	- This input is deleted as it has no effect on a number sequence
	- Another option would be to store this data in the program instead of deleting it. That would be a discussion with the group leader and would take a closer look at the surrounding environment.

4. The input could contain a sequence with one of the pieces having a number and a non-digit -> "1,2Y,4"
	- This input is filtered and the non-digit is deleted. The program will still output the correct missing number after the extra non-digits are removed.
	- Again, this would be a conversation with the other group members and would benefit from a good understanding of the direction and purpose of this program in relation to the project.

5. The input could have multiple of the same number in a sequence -> "1,1,3"
	- Duplicates are ignored and the string is parsed as usual


Notes
-----
TDD was used to write this program and can be found in the following directory:
"/MissingNumber/spec/number_finder_spec.rb".

A "test.txt" file can also be found in the same directory. This file was used to test the program once it was built. Normal input is stored there as well as any input that might cause problems.

I also sought out code reviews before I submitted this file. I had missed some unit tests and was given advice on some specific case Ruby styling. It also prompted a discussion of better organization, which was beneficial to the readability of the program and unit tests.

Thanks so much for letting me work through this program. I had a blast working through some of the problems and thinking about possible solutions as well!
