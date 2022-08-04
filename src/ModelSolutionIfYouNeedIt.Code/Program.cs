using System;
using System.Collections.Generic;

namespace LuhnChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> creditCardNumbers = new List<string> { "1234567890123452", "1234567812345670", "4012888888881881", "4417 1234 5678 9113", "12345678901234AB", "123456789012", "1234567812345678", "4417 1234 5678 9114" };
            Dictionary<string, string> validatedNumbers = new Dictionary<string, string>();
            foreach (string creditCardNumber in creditCardNumbers)
            {
                validatedNumbers.Add(creditCardNumber, ValidateNumber(creditCardNumber));
            }
            foreach(string creditCardNumber in creditCardNumbers)
            {
                Console.WriteLine(validatedNumbers[creditCardNumber]);
            }
        }

        public static string ValidateNumber(string creditCardNumber)
        {
            bool isValid;
            string message = string.Empty;
            // Replace any spaces with Empty String
            string creditCardNumberWithNoSpaces
                = creditCardNumber.Replace(" ", String.Empty);
            // dummy long ready to hold the 'out' param of TryParse.
            long numericCreditCardNumber;
            // if it fails Messagebox and exit
            if (!long.TryParse(creditCardNumberWithNoSpaces, out numericCreditCardNumber))
            {
                message = $"{creditCardNumber} is non-numeric";
                return message;
            }

            // Check it is 16 chars long
            if (creditCardNumberWithNoSpaces.Length != 16)
            {
                message = $"{creditCardNumber} is not 16 digits long";
                return message;
            }

            // we got here so it is a 16 digit numeric
            // convert it to a 16 char array
            char[] digitsAsChars = creditCardNumberWithNoSpaces.ToCharArray();
            // init running check digit total
            int runningTotal = 0;
            // loop thru 16 times
            for (int i = 0; i < digitsAsChars.Length; i++)
            {
                // calculate an int version of this digit as chars
                // will convert to int
                int singleDigit = digitsAsChars[i] - 48; // or subtract '0'

                // if 1st or 3rd or 5th digit of number 
                // (i being even 0/2/4 etc)
                if (i % 2 == 0)
                {
                    // double
                    singleDigit *= 2;
                    // if gt 9 subtract 9
                    if (singleDigit > 9)
                    {
                        singleDigit -= 9;
                    }
                }
                // always add to runningTotal
                // if it was 2nd / 4th / 6th number etc then added unaltered
                runningTotal += singleDigit;
            }
            // see if it is divisible by 10
            isValid = (runningTotal % 10 == 0);
            string messageInsert = string.Empty;
            if (!isValid)
            {
                messageInsert = "NOT ";
            }
            return $"{creditCardNumber} is {messageInsert}a valid number";

        }
    }
}
