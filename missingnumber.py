#! /usr/bin/env python3

import csv

'''Takes a sequence of integers with one number missing and finds that 
missing number. In particular, gives the first number that is 
missing, if there are several, and if none are missing, gives the next in the 
sequence.

Also provides a generator for reading in these sequences from a flat CSV.'''
class MissingNumber:
	def __init__(self):
		self.missing = None
		
	'''Takes a sequence of integers with one number missing and finds that 
	missing number. In particular, gives the first number that is 
	missing, if there are several, and if none are missing, gives the next in the 
	sequence.'''
	def parse(self, seq):
		prev = None
		try:
			for num in sorted(seq):
				if prev != None and num > prev+1:
					self.missing = prev+1
					prev = None
					break
				else:
					prev = num
			if prev != None:
				self.missing = prev+1
		except ValueError:
			raise RuntimeError('Invalid file provided.')
			
	'''Reads CSV lines from a file as integer sequences and parses them.'''
	def readfile(self, filename):
		with open(sys.argv[1]) as f:
			for line in f:
				line = line.strip()
				if len(line) > 0:
					self.parse(map(int, line.split(',')))
					yield self.missing
		


import sys

if __name__ == '__main__':
	if len(sys.argv) < 2:
		print('Please provide the name of a file to read in')
		exit()
	for num in MissingNumber().readfile(sys.argv[1]):
		print(num, end='\n\n')

