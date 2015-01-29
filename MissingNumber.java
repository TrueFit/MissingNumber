/** @author Ian Waldschmidt: ian.waldschmidt12@gmail.com
  *  Truefit Missing Number Coding Challenge
  *  Please refer to the main method
  */

/** CHANGE LOG
  *  1/26/2015: Started project brainstorming, imported libraries, made preliminary code. Problem with absolute file paths containing the \
  *             character. Considering different language, making it a relative path, other ideas?
  *  1/27/2015: Realized the / character works in place of \, so problems with \ are eliminated. Now there are problems with the last number
  *             being read. Will likely end up making a try/catch block to fix that problem, but implementation details are undecided.
  *  1/28/2015: The problem from yesterday was fixed by using different delimiters. Minor issues (file name containing spaces, filename errors, etc.)
  *             taken care of. Finished error testing. Javadoc comments finalized, document cleaned up as a whole.
  */

//LIBRARIES (from Java API)
import java.util.Scanner;                        //Allows the code to break the file into lines and numbers
import java.io.File;                             //Allows the code to find the file based on its path name
import java.io.FileNotFoundException;            //Thrown by the code if the path name is invalid

public class MissingNumber{
  /*********
  * FIELDS *
  *********/
  
  /** A scanner used to separate the file into lines */
  private static Scanner lineScanner = null;
  
  /*****************
  * HELPER METHODS *
  *****************/
  
  /** Takes a path name as input and sets up 2 scanners: one to break the document into lines, and the other to break the lines into numbers
    * @param path The file's path name in a String representation
    * @return true on success, false on failure
    */
  private static boolean readFile(String path){
    try{
      lineScanner = new Scanner(new File(path));
    }
    catch(FileNotFoundException e){
      System.out.println("Invalid path name. Please use the style \"Drive:/Folder/...filename\"");
      return false;
    }
    return true;
  }
  
  /** Takes a string in the following form and returns the missing integer within:
    * -Has integers separated by commas (no spaces)
    * -The integers range from a minimum (in the list) to a maximum (in the list) and include all but one integer in that range
    * Uses a summation formula of integers from a minimum to a maximum to make a theoretical sum to compare to the actual sum
    * This method could theoretically be used outside of the program, so I made it a public method
    * @param line The string with the integers
    * @return The missing integer in the list
    */
  public static int missingInteger(String line){
    //Set up the scanner
    Scanner numberScanner = new Scanner(line);
    numberScanner.useDelimiter(",");
    
    //Set up the necessary variables
    int min = Integer.MAX_VALUE;
    int max = Integer.MIN_VALUE;
    int sum = 0;
    int currentNumber;
    
    //Iterate through the numbers, updating the variables as necessary
    while(numberScanner.hasNext()){
      currentNumber = numberScanner.nextInt();
      sum += currentNumber;
      if(currentNumber > max){
        max = currentNumber;
      }
      if(currentNumber < min){
        min = currentNumber;
      }
    }
    
    //Compare the actual sum to the theoretical sum and report the difference
    return (min+max)*(max-min+1)/2 - sum;
  }
  
  /**************
  * MAIN METHOD *
  **************/
  
  /** Accepts a file's path name as input. The path name can be either relative or absolute and should reference a file that follows the following guidelines:
    * -Each line should contain a series of integers, separated by commas.
    * -The integers range from a minimum (in the list) to a maximum (in the list) and include all but one integer in that range
    * -There is no restriction on number of lines, number of integers in a line, or the order of the integers.
    */
  
  public static void main(String[] args){
    //Turn the input into a cogent file name
    StringBuilder fileName = new StringBuilder();     //Saves the entire file name rather than pieces separated by spaces
    for(String filePart: args){
      fileName.append(filePart + " ");
    }
    
    //Read the file and make sure the file exists
    if(!readFile(fileName.toString()))
      return;
    
    //Iterate through each line of the file
    while(lineScanner.hasNext()){
      System.out.println(missingInteger(lineScanner.next()));
    }
  }
}