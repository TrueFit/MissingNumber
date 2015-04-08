//
//Missing Number Exercie
//Jordan Walsh
//04/07/15
//

#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <sstream>
#include <algorithm>

int main(){

	std::string file;
	
	std::cout << "Enter the name of the input file: ";
	std::cin >> file;

	std::ifstream inFile;
	inFile.open(file);

	std::vector<int> numbers; //hold the numbers contained on each line of the file
	std::string line;
	int begin;
	int end;

	while(inFile){
		
		std::getline(inFile, line);

		std::istringstream strStream(line);

		if(line.size() > 0){ //make sure the line isnt blank

			//extract numbers between commas, then convert them to ints
			while(std::getline(strStream,line,',')){
				numbers.push_back(atoi(line.c_str()));
			}

			std::sort(numbers.begin(), numbers.end());
			
			begin = numbers.at(0);
			end = numbers.at(numbers.size() - 1);
			
			//find missing numbers
			for(int i = begin; i < end; i++){
				if(!std::binary_search(numbers.begin(), numbers.end(),i)){
					std::cout << i << std::endl;
				}
			}

			numbers.clear();
		}
	

	}
	
	inFile.close();

	return 0;
}
