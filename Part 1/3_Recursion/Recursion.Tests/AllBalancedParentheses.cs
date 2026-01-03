using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Recursion.Tests
{
    public class AllBalancedParenthesis
    {
        [Fact]
        public void Test1()
        {
            Assert.Empty(RecursionFunctions.AllBalancedParenthesis(0));

            List<string> answer1 = RecursionFunctions.AllBalancedParenthesis(1);
            Assert.Equal(answer1, new List<string>{"()"});

            List<string> answer2 = RecursionFunctions.AllBalancedParenthesis(2);
            Assert.Equal(2, answer2.Count);
            Assert.Contains("(())", answer2);
            Assert.Contains("()()", answer2);

            List<string> answer3 = RecursionFunctions.AllBalancedParenthesis(3);
            Assert.Equal(5, answer3.Count);
            Assert.Contains("((()))", answer3);
            Assert.Contains("(()())", answer3);
            Assert.Contains("(())()", answer3);
            Assert.Contains("()(())", answer3);
            Assert.Contains("()()()", answer3);

            Assert.Equal(14, RecursionFunctions.AllBalancedParenthesis(4).Count);
            Assert.Equal(42, RecursionFunctions.AllBalancedParenthesis(5).Count);
            // long tests
            // Assert.Equal(132, RecursionFunctions.AllBalancedParenthesis(6).Count);
            // Assert.Equal(429, RecursionFunctions.AllBalancedParenthesis(7).Count);
            // Assert.Equal(1430, RecursionFunctions.AllBalancedParenthesis(8).Count);
            // Assert.Equal(4862, RecursionFunctions.AllBalancedParenthesis(9).Count);
            // Assert.Equal(16796, RecursionFunctions.AllBalancedParenthesis(10).Count);
            
            // foreach (string str in RecursionFunctions.AllBalancedParenthesis(1)) Console.WriteLine(str);
            // Console.WriteLine();
        }
    }
}