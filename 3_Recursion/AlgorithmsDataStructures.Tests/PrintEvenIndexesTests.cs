using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    // Those tests should not run in parallel because
    // tested methods may share output
    [Collection("Sequential")]
    public class PrintEvenIndexesTests
    {
        [Fact]
        public void GeneralTests()
        {
            StringWriter output = new();
            Console.SetOut(output);

            RecursionFunctionsGeneric<int>.PrintEvenIndexes(new List<int>{1, 2, 3, 4, 5, 8, 9, 6, 7, 10, 11}, 0);

            string outputString = output.ToString();
            Assert.Equal("1 3 5 9 7 11 ", outputString);

            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }

        [Fact]
        public void EmptyInputTest()
        {
            StringWriter output = new();
            Console.SetOut(output);

            RecursionFunctionsGeneric<int>.PrintEvenIndexes(new List<int>{}, 0);

            string outputString = output.ToString();
            Assert.Equal("", outputString);

            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }

        [Fact]
        public void StringInputTest()
        {
            StringWriter output = new();
            Console.SetOut(output);

            RecursionFunctionsGeneric<string>.PrintEvenIndexes(new List<string>{"cat", "bat", "rat"}, 0);

            string outputString = output.ToString();
            Assert.Equal("cat rat ", outputString);

            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }
    }
}