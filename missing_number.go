package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
	"strconv"
	"strings"
)

func main() {
	csvFile, err := os.Open(os.Getenv("FILE_PATH"))
	if err != nil {
		fmt.Println(err)
		return
	}
	defer csvFile.Close()

	scanner := bufio.NewScanner(csvFile)
	for scanner.Scan() {
		stringSlice := strings.Split(scanner.Text(), ",")
		intSlice := ConvertToInt(stringSlice)
		missingNumber, foundMissingNumber := FindMissingNumber(intSlice)
		if foundMissingNumber {
			fmt.Println(missingNumber)
		} else {
			fmt.Println("No missing number")
		}
	}
}

func ConvertToInt(stringSlice []string) (intSlice []int) {
	for _, value := range stringSlice {
		intValue, err := strconv.Atoi(value)
		if err != nil {
			fmt.Printf("There was some bad data in this string %s\n", stringSlice)
			return intSlice
		}
		intSlice = append(intSlice, intValue)
	}
	return intSlice
}

func FindMissingNumber(sequence []int) (int, bool) {
	sort.Ints(sequence)
	for index, value := range sequence {
		if index+1 == len(sequence) {
			break
		}

		if sequence[index+1] != value+1 {
			return value + 1, true
		}
	}
	return 0, false
}
