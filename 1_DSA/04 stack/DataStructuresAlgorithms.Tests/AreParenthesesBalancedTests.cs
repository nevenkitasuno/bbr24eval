using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DataStructuresAlgorithms.Tests
{
    public class AreParenthesesBalancedTests
    {
        [Fact]
        public void TestAreParenthesesBalanced()
        {
            Stack<int> stack = new Stack<int>();

            Assert.True(Exercises.AreParenthesesBalanced(""));
            Assert.True(Exercises.AreParenthesesBalanced("()"));
            Assert.True(Exercises.AreParenthesesBalanced("()()"));
            Assert.True(Exercises.AreParenthesesBalanced("(())"));
            Assert.True(Exercises.AreParenthesesBalanced("(())()"));

            Assert.False(Exercises.AreParenthesesBalanced(")"));
            Assert.False(Exercises.AreParenthesesBalanced("(())("));
            Assert.False(Exercises.AreParenthesesBalanced("(()))"));
            Assert.False(Exercises.AreParenthesesBalanced("(()("));
            Assert.False(Exercises.AreParenthesesBalanced("())("));

            Assert.True(Exercises.AreParenthesesBalanced("(()((())()))"));
            Assert.False(Exercises.AreParenthesesBalanced("(()()(()"));
            Assert.False(Exercises.AreParenthesesBalanced("())("));
            Assert.False(Exercises.AreParenthesesBalanced("))(("));
            Assert.False(Exercises.AreParenthesesBalanced("((())"));
        }
    }
}