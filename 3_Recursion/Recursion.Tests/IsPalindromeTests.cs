using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Recursion.Tests
{
    public class IsPalindromeTests
    {
        [Fact]
        public void TestIsPalindrome() {
            Assert.True(RecursionFunctions.IsPalindrome("racecar"));
            Assert.True(RecursionFunctions.IsPalindrome("madam"));
            Assert.True(RecursionFunctions.IsPalindrome("12321"));
            Assert.True(RecursionFunctions.IsPalindrome(""));
            Assert.True(RecursionFunctions.IsPalindrome("Ω"));
            Assert.False(RecursionFunctions.IsPalindrome("hello"));
            Assert.False(RecursionFunctions.IsPalindrome("12345"));
        }
    }
}