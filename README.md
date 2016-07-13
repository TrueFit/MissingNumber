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
----------------
The specifications for the program to find a missing number were as follows:
1. Accept a flat file as input.
	- Each new line will contain a set of sequential numbers with one number missing.
	- Each series will be comma delimited and in a random order
2. Output the missing number for each series


<><><><><><><><>
Accepting a flat file can be found in the following directory:
"/MissingNumber/lib/tf_number_finder.rb".

To change the file input, simply edit the file path where the comments specify.

It seemed prudent to create a class for finding a missing number to capitalize on possible re-use. The class NumberFinder can be found in the following directory:
"/MissingNumber/lib/number_finder_class.rb".

To use the class to find a missing number create an instance of the NumberFinder class, call the get_missing_number function, pass in any string, then output the result.
	example:
		classInstance = NumberFinder.new
		puts classInstance.get_missing_number(someString)

Some possible issues I foresaw were as follows:
1. The input would only have one number in the sequence -> "1"

2. The input would be a full sequence with no number missing -> "1,2,3"

3. The input would have more than one number missing -> "1,2,5"

4. The input would be a non-digit -> "Y"

5. The input could contain a sequence with one of the pieces having a number and a non-digit -> "1,2Y,4"

6. The input could have multiple of the same number in a sequence -> "1,1,3"
