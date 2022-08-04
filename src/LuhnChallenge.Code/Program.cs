using System;
using System.Collections.Generic;

namespace LuhnChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> creditCardNumbers = new List<string> { 
                "1234567890123452", 
                "1234567812345670", 
                "4012888888881881", 
                "4417 1234 5678 9113",
                "12345678901234AB",
                "123456789012",
                "1234567812345678",

                "4417 1234 5678 9114" };

            Dictionary<string, string> validatedNumbers = new Dictionary<string, string>();

            ////TODO: Loop around each entry in the creditCardNumbers collection
            //foreach (??? ??? in ???)
            //{
            //    //TODO: Call the ValidateNumber function and using the current credit card number as a key
            //    // add the function's returned value to the validatedNumbers dictionary
            //    validatedNumbers.Add(???, ValidateNumber(???));
            //}
            ////TODO: Loop around each entry in the creditCardNumbers collection
            //foreach (??? ??? in ???)
            //{
            //    //TODO: Using each credit card number as a key get the associated value from the validatedNumbers dictionary
            //    // and write it to the console
            //    Console.WriteLine(validatedNumbers[???]);
            //}
        }

        public static string ValidateNumber(string creditCardNumber)
        {
            bool isValid;
            string message = string.Empty;
            string creditCardNumberWithNoSpaces;

            // TODO: Replace any spaces in creditCardNo with Empty String and place result in creditCardNumberWithNoSpaces
            // HINT: make use of the string type's Replace fucntion
                        
            // dummy long ready to hold the 'out' param of TryParse.
            long numericCreditCardNumber;
            // TODO: Use TryParse to convert creditCardNumber to a long data type. If it fails return from function with 
            // error message in the form "9999999999999999 is non-numeric"

            // TODO: Check credit card number (with no spaces) is 16 chars long. If it is not return from function with
            // error message in the form "9999999999999 is not 16 digits long"

            // If we reach this point we know we have a 16 digit numeric number
            // TODO: convert creditCardNumberWithNoSpaces to a char array called digitsAsChars
            // HINT: The string type has a built in function that will do this
            char[] digitsAsChars;

            // initialise running check digit total
            int runningTotal = 0;
            // TODO: Create logic that deals with each digit in turn and applies the Luhn rules to it. The first thing to do inside
            // // the loop is convert the current digitAsChar to its numerical equivalent. The following note may be of help:

            // NOTE: char variables hold a number that represents the unicode value of the associated character so, the character 
            // '0' is held as 48, '1' is held as 49, '2' is held as 50 and so on. To convert the unicode value to the actual number 
            // we can simply subtract 48. 
            // '0' -> 48 subtracting 48 gives 0
            // '1' -> 49 subtracting 48 gives 1
            // '2' -> 50 subtracting 48 gives 2...
            // This can be acheived by the following line: 
            // int singleDigit = digitsAsChars[i] - 48;

            // If the current digit is a digit in an odd POSITION multiply it by 2 if the result is greater than 9 subtract 9 and add to the running total
            // If the current digit is in an even POSITION add it to the running total
            // You can use modal division to see if a number is odd or even. Use the percent symbol (%) rather than the slash (/) 
            // and divide by 2. An even number mod 2 will give a remainder of zero whilst an odd number mod 2 will leave a remainder of 1... 

            // TODO: Once the loop has completed see if the running total is divisible by 10 (use the mod (%) character again)
            // If it is divisible by 10 then return a message in the form "9999999999999999 is a valid number"
            // If it is not divisible by 10 return a message in the form "9999999999999999 is NOT a valid number"
            return message;
        }
    }
}
