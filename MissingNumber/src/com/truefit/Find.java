package com.truefit;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;

public class Find {
/**
 * @author yanma
 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		File inputFile = new File("number.txt");
		File outputFile = new File("output.txt");
		
		FileInputStream fisFileInputStream;
		FileOutputStream fosFileOutputStream;
		try {
			fisFileInputStream = new FileInputStream(inputFile);
			fosFileOutputStream = new FileOutputStream(outputFile);
			DataInputStream inputStream = new DataInputStream(fisFileInputStream);
			DataOutputStream outputStream = new DataOutputStream(fosFileOutputStream);
			BufferedReader bReader = new BufferedReader(new InputStreamReader(inputStream));
			BufferedWriter bWriter = new BufferedWriter(new OutputStreamWriter(outputStream));
			try {
				String line = bReader.readLine();
				String result = "";
				//till the last line
				while(line!=null) {
					//for all non-empty lines
					if(!line.equals("")) {
						
						//split the line and store into string array
						String[] original = line.split(",");
						int length = original.length;
						int[] numbers = new int[length];
						// transfer string array into int array
						for (int i=0; i<length;i++) {
							numbers[i] = Integer.valueOf(original[i]);
						}
						
						// find the min and max value of the array
						int max = numbers[0];
						int min = numbers[0];
						for(int i=0; i<length; i++) {
							if(numbers[i]<=min) {
								min = numbers[i];
							}
							if(numbers[i]>=max) {
								max = numbers[i];
							}
						}
						
						//in if condition, there must be a number missing
						if(length<(max-min+1)) {
							// the min number must exist, so not need to check
							// the missing number set to lost
							// the test number set to temp
							int lost = min+1;
							int temp = min+1;
							
							// check through all elements
							// when the test number exists
							// check the next number and jump back to 1st element
							
							// after go through all elements and not find the test number
							// set the temp number to lost
							// it is the result
							for(int i=0; i<length; i++) {
								if(numbers[i]==temp) {
									temp++;
									i=-1;
								}
								
								
								if(i==length-1) {
									lost = temp;
								}
							}
							//accumulate all lines result
							result += String.valueOf(lost);
						} else {
							result += "no lost number";
						}
						
						
						
					}else {//for all empty lines, write an empty line
						result +="\n\n";
					}
					line = bReader.readLine();
				}//read all lines
				//output the accumulated result
				
				bWriter.write(result);
				bWriter.flush();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
			
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	}

}
