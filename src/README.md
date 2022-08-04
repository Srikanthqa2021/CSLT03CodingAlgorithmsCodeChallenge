# Coding Algorithms Coding Challenge
In this challenge, there is no step-by-step guide and no hints. However, if you get really stuck, the full solution is located in the ModelSolutionIfYouNeedIt.Code project.

The challenge gives you a starter project that contains a ```program.cs``` file with a number of TODO comments designed to help you along the way. When you feel you have completed the challenge, you can submit your solution and have it automatically tested to ensure it behaves exactly as requested. Note, the automated tests are also looking out for the suggestions made in the additional challenges section at the end of this document. Consequently, you will need to ensure the messages returned from the ValidateNumber method and the data that gets written to the console match the specification. 

# Overview
The Luhn algorithm is used for credit and debit card validation.
Each card number can be checked to see if the given number is valid. The verification will not tell you if a card number has been issued or not. However, in the majority of cases, it will tell you if a user has mistyped the number (for example, to aid in the validation of online payments).

# Algorithm Walkthrough
The algorithm used in this example is for 16-digit card numbers, although it can work for other lengths.

Start with an integer variable to hold a sum (running total), which will be increased as you process the card number. Initialise this variable to zero.

Then, loop through each digit in the number. 

For the digits in the odd number positions (i.e., 1st, 3rd, 5th, 7th, 9th etc.), you calculate a number by multiplying the value of the digit by 2. 

If the value of the calculated number is then greater than 9, you take 9 away from it. 
So, if for example, the digit is a 6, then multiplying this by 2 gives 12. 
This is greater than 9, so take 9 away to get 3. Finally, add the calculated number to the running total declared earlier.

For the digits in the even-number positions (i.e., 2nd, 4th, 6th, 8th, 10th etc.), simply add the value of the digit to your running total.

After you have looped through all the digits, divide the running total by 10 (use integer division so you get a whole number result and remainder). If the remainder is zero, then the card number is valid. If the remainder is non-zero, the card number is invalid.

Here is the detail of how the process works for an example number of 6304024062814363.

```
Start with sum at 0.

Digit 1: 6 - multiply by 2 to get 12, which is greater than 9, so take 9 away to get 3 - add this to sum to get 3.

Digit 2: 3 - add this to sum to get 6.

Digit 3: 0 multiply by 2 to get 0 - add this to sum to get 6.

Digit 4: 4 - add this to sum to get 10.

Digit 5: 0 multiply by 2 to get 0 - add this to sum to get 10.

Digit 6: 2 - add this to sum to get 12.

Digit 7: 4 multiply by 2 to get 8 - add this to sum to get 20.

Digit 8: 0 - add this to sum to get 20.

Digit 9: 15 - as above.

Digit 16: 3 - add this to sum (it becomes 50).
```

To determine whether the number is valid you look at the final sum. 

If, after dividing by 10, the remainder is equal to zero then the number is valid. 
In this case, the remainder after 50 is divided by 10 - equalling zero - so the number is valid.

# Task
Locate the LuhnChallenge.Code console application. Open the ```Program.cs``` files and tackle the ```TODO``` comments:

For the automated tests to work, you must complete the logic in the ValidateNumber method that takes a credit card number as a string and returns a string in one of the formats listed in the ```TODO``` comments. You also need to complete the logic in the Main method by uncommenting lines 22 to 35 and replacing the question marks with the missing details.

# Hints and Tips
To take a string that represents a credit card number and store it in a char array, use code like this:
```
char[] digitsAsChars = creditCardNumber.ToCharArray();
```

Your array of characters will contain each individual character from the entered number, which you need to convert into an integer, i.e., the character ‘4’ must be converted to the number 4. Assuming you have a loop with an index variable called ‘i’, you can get the numeric value of a digit in the character array by subtracting 48 (or the character ‘0’) from it, e.g.,
```
// char implicitly converts to int so subtraction works!
int singleDigit = digitsAschars[i] - '0'; 
```

The algorithm above uses 1st digit, 2nd digit, 3rd digit, etc. and the first digit in an array is referenced by a zero (0).
You can use modular arithmetic to determine whether a number is even or odd, such as your loop index variable. 

For each position in the loop, see what the remainder is when divided by two. Then you will know if you are on an even or odd number ‘slot’.

Finally, use modular arithmetic to determine if the final sum is correct.

A string array of valid and invalid numbers is defined at the top of the Main function. The first four test numbers are valid and the last four are invalid.

# Additional Challenges
Make your solution better by adding validation, i.e., ensure the credit card number is made up only of digits, contains exactly 16 digits, and add logic to remove any spaces between the digits. 

Note: If your code contains any ‘else’ statements, then it can be modified and simplified to remove them. The specification does not require an ‘else’.

# Expected Messages
The unit tests are looking for the following messages to be written to the console for the associated credit card numbers:

                "1234567890123452 is a valid number"
                "1234567812345670 is a valid number"
                "4012888888881881 is a valid number"
                "4417 1234 5678 9113 is a valid number"
                "12345678901234AB is non-numeric"
                "123456789012 is not 16 digits long"
                "1234567812345678 is NOT a valid number"
                "4417 1234 5678 9114 is NOT a valid number";

# To Run the Project
-  Select "Start Debugging" or "Run Without Debugging" from Visual Studio Code's "Run" menu or press F5 or Ctrl+F5
-  To interact with the console (and view the program's output) select the "Terminal" option from Visual Studio Code's View Menu (or press Ctrl+')  

# Execute Unit Tests
At any time you can invoke the unit tests that will be used to determine whether you have successfully completed the challenge by selecting the "Terminal" option from Visual Studio Code's View Menu (or pressing Ctrl+')) and running the following command:

```
dotnet test
```
If all the tests pass you will see a message (in green) that states <span style="color:green">"Passed!  - Failed:   0..."</span>. If any of the tests fail tou will see a message in red that states <span style="color:red">"Failed! - Failed:    n..."</span> where n indicates the number of tests that have failed.

__Note:__ You are NOT (yet) expected to understand how to create your own unit tests nor to interpret the results beyond knowing whether the tests have passed or failed. You will be looking at unit testing as the final topic of this digital course.

# Model Solution (__but only if you need it__)
The code for a model solution can be found in the ```ModelSolutionIfYouNeedIt.Code``` project 