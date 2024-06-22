using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    // Those tests should not run in parallel because
    // tested methods may share output
    [Collection("Sequential")]
    public class PrintEvenTests
    {
        [Fact]
        public void GeneralTests()
        {
            StringWriter output = new();
            Console.SetOut(output);

            RecursionFunctions.PrintEven(new List<int>{1, 2, 3, 4, 5, 8, 7, 6, 9, 10}, 0); // just [1, 2, ... , 10] starting from C# 12

            string outputString = output.ToString();
            Assert.Equal("2 4 8 6 10 ", outputString);

            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }

        [Fact]
        public void EmptyInputTest()
        {
            StringWriter output = new();
            Console.SetOut(output);

            RecursionFunctions.PrintEven(new List<int>{}, 0); // just [] starting from C# 12

            string outputString = output.ToString();
            Assert.Equal("", outputString);

            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }
    }
}