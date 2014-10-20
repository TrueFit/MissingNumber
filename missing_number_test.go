package main

import "testing"

func TestWhenNumberIsMissingFromSeqeunce(t *testing.T) {
	sequence := []int{1, 2, 4}
	expected := 3
	actual, _ := FindMissingNumber(sequence)
	if expected != actual {
		t.Errorf("Should have found %d but found %d instead", expected, actual)
	}
}

func TestWhenSequenceDoestStartAtOne(t *testing.T) {
	sequence := []int{24, 26, 27, 29, 28}
	expected := 25
	actual, _ := FindMissingNumber(sequence)
	if expected != actual {
		t.Errorf("Should have found %d but found %d instead", expected, actual)
	}
}

func TestWhenSequenceIsntMissingANumber(t *testing.T) {
	sequence := []int{24, 25, 26, 27, 29, 28}
	_, foundMissingNumber := FindMissingNumber(sequence)

	if foundMissingNumber {
		t.Errorf("Found missing number when there wasnt one")
	}
}

func WhenNegativeNumber(t *testing.T) {
	sequence := []int{-1, -2, -3, -5}
	expected := -4
	actual, _ := FindMissingNumber(sequence)
	if expected != actual {
		t.Errorf("Should have found %d but found %d instead", expected, actual)
	}
}

func TestWhenNotSorted(t *testing.T) {
	sequence := []int{1, 2, 3, 5, 4, 7}
	expected := 6
	actual, _ := FindMissingNumber(sequence)
	if expected != actual {
		t.Errorf("Should have found %d but found %d instead", expected, actual)
	}
}
