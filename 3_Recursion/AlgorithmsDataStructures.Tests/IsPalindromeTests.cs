using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class IsPalindromeTests
    {
        [Fact]
        public void TestIsPalindrome() {
            Assert.True(RecursionFunctions.IsPalindrome("racecar", 0));
            Assert.True(RecursionFunctions.IsPalindrome("madam", 0));
            Assert.True(RecursionFunctions.IsPalindrome("12321", 0));
            Assert.True(RecursionFunctions.IsPalindrome("", 0));
            Assert.True(RecursionFunctions.IsPalindrome("Ω", 0));
            Assert.False(RecursionFunctions.IsPalindrome("hello", 0));
            Assert.False(RecursionFunctions.IsPalindrome("12345", 0));
        }
    }
}