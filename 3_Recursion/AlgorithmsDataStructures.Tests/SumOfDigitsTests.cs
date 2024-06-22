using System;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(6, RecursionFunctions.SumOfDigits(123));
            Assert.Equal(10, RecursionFunctions.SumOfDigits(1234));
            Assert.Equal(0, RecursionFunctions.SumOfDigits(0));
        }
    }
}
