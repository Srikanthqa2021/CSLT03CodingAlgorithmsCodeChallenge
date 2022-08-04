using System;
using Xunit;
using LuhnChallenge;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace SimpleConsoleAppTests
{
    public class LuhnChallengeUnitTests
    {
        TextWriter m_normalOutput;
        StringWriter m_testingConsole;
        StringBuilder m_testingSB;

        //User input
        List<string> creditCardNumbers = new List<string> { "1234567890123452", "1234567812345670", "4012888888881881", "4417 1234 5678 9113", "12345678901234AB", "123456789012", "1234567812345678", "4417 1234 5678 9114" };

        public LuhnChallengeUnitTests()
        {
            // Set current folder to testing folder
            //string assemblyCodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string assemblyCodeBase = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string dirName = Path.GetDirectoryName(assemblyCodeBase);

            if (dirName.StartsWith("file:\\"))
                dirName = dirName.Substring(6);

            Environment.CurrentDirectory = dirName;

            m_testingSB = new StringBuilder();
            m_testingConsole = new StringWriter(m_testingSB);
            m_normalOutput = System.Console.Out;
            System.Console.SetOut(m_testingConsole);
        }

        [Fact]
        public void FullOutputTest()
        {
            String expectedOutput =
                "1234567890123452 is a valid number\r\n" +
                "1234567812345670 is a valid number\r\n" +
                "4012888888881881 is a valid number\r\n" +
                "4417 1234 5678 9113 is a valid number\r\n" +
                "12345678901234AB is non-numeric\r\n" +
                "123456789012 is not 16 digits long\r\n" +
                "1234567812345678 is NOT a valid number\r\n" +
                "4417 1234 5678 9114 is NOT a valid number\r\n\r\n";
            Assert.Equal(0, StartConsoleApplication(""));
            Assert.Equal(expectedOutput, m_testingSB.ToString());
        }

        [Fact]
        public void FirstValidNumberTest()
        {
            int i = 0;
            //Assert.Equal(0, StartConsoleApplication(""));
            //Assert.Contains($"{creditCardNumbers[i]} is a valid number", m_testingSB.ToString());

            string message = Program.ValidateNumber(creditCardNumbers[i]);
            Assert.Contains($"{creditCardNumbers[i]} is a valid number", message);
        }

        [Fact]
        public void SecondValidNumberTest()
        {
            int i = 1;
            //Assert.Equal(0, StartConsoleApplication(""));
            //Assert.Contains($"{creditCardNumbers[i]} is a valid number", m_testingSB.ToString());

            string message = Program.ValidateNumber(creditCardNumbers[i]);
            Assert.Contains($"{creditCardNumbers[i]} is a valid number", message);
        }

        [Fact]
        public void ThirdValidNumberTest()
        {
            int i = 2;
            //Assert.Equal(0, StartConsoleApplication(""));
            //Assert.Contains($"{creditCardNumbers[i]} is a valid number", m_testingSB.ToString());

            string message = Program.ValidateNumber(creditCardNumbers[i]);
            Assert.Contains($"{creditCardNumbers[i]} is a valid number", message);
        }

        [Fact]
        public void ValidNumberWithSpacesTest()
        {
            int i = 3;
            //Assert.Equal(0, StartConsoleApplication(""));
            //Assert.Contains($"{creditCardNumbers[i]} is a valid number", m_testingSB.ToString());

            string message = Program.ValidateNumber(creditCardNumbers[i]);
            Assert.Contains($"{creditCardNumbers[i]} is a valid number", message);
        }

        [Fact]
        public void NonNumericNumberTest()
        {
            int i = 4;
            //Assert.Equal(0, StartConsoleApplication(""));
            //Assert.Contains($"{creditCardNumbers[i]} is non-numeric", m_testingSB.ToString());

            string message = Program.ValidateNumber(creditCardNumbers[i]);
            Assert.Contains($"{creditCardNumbers[i]} is non-numeric", message);
        }

        [Fact]
        public void NotEnoughDigitsInNumberTest()
        {
            int i = 5;
            //Assert.Equal(0, StartConsoleApplication(""));
            //Assert.Contains($"{creditCardNumbers[i]} is not 16 digits long", m_testingSB.ToString());
            string message = Program.ValidateNumber(creditCardNumbers[i]);
            Assert.Contains($"{creditCardNumbers[i]} is not 16 digits long", message);

        }

        [Fact]
        public void InvalidNumberTest()
        {
            int i = 6;
            //Assert.Equal(0, StartConsoleApplication(""));
            //Assert.Contains($"{creditCardNumbers[i]} is NOT a valid number", m_testingSB.ToString());
            string message = Program.ValidateNumber(creditCardNumbers[i]);
            Assert.Contains($"{creditCardNumbers[i]} is NOT a valid number", message);
        }

        [Fact]
        public void InvalidNumberWithSpacesTest()
        {
            int i = 7;
            //Assert.Equal(0, StartConsoleApplication(""));
            //Assert.Contains($"{creditCardNumbers[i]} is a valid number", m_testingSB.ToString());
            string message = Program.ValidateNumber(creditCardNumbers[i]);
            Assert.Contains($"{creditCardNumbers[i]} is NOT a valid number", message.ToString());
        }

        private int StartConsoleApplication(string arguments)
        {
            //Program.Main(arguments.Split(' '));
            Process proc = new Process();
            proc.StartInfo.FileName = "LuhnChallenge.Code.exe";
            proc.StartInfo.Arguments = arguments;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.Start();
            proc.WaitForExit();
            System.Console.WriteLine(proc.StandardOutput.ReadToEnd());
            System.Console.Write(proc.StandardError.ReadToEnd());
            return proc.ExitCode;
        }
    }
}
