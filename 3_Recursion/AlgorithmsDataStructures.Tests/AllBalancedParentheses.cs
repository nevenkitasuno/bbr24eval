using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class AllBalancedParentheses
    {
        [Fact]
        public void Test1()
        {
            Assert.Empty(RecursionFunctions.AllBalancedParentheses(0));

            List<string> answer1 = RecursionFunctions.AllBalancedParentheses(1);
            Assert.Equal(answer1, new List<string>{"()"});

            List<string> answer2 = RecursionFunctions.AllBalancedParentheses(2);
            Assert.Equal(2, answer2.Count);
            Assert.Contains("(())", answer2);
            Assert.Contains("()()", answer2);

            List<string> answer3 = RecursionFunctions.AllBalancedParentheses(3);
            Assert.Equal(5, answer3.Count);
            Assert.Contains("((()))", answer3);
            Assert.Contains("(()())", answer3);
            Assert.Contains("(())()", answer3);
            Assert.Contains("()(())", answer3);
            Assert.Contains("()()()", answer3);

            Assert.Equal(14, RecursionFunctions.AllBalancedParentheses(4).Count);
            Assert.Equal(14, RecursionFunctions.AllBalancedParentheses(5).Count);
            Assert.Equal(14, RecursionFunctions.AllBalancedParentheses(6).Count);
            Assert.Equal(14, RecursionFunctions.AllBalancedParentheses(7).Count);
            Assert.Equal(14, RecursionFunctions.AllBalancedParentheses(8).Count);
            Assert.Equal(14, RecursionFunctions.AllBalancedParentheses(9).Count);
            Assert.Equal(14, RecursionFunctions.AllBalancedParentheses(10).Count);
            
            // foreach (string str in RecursionFunctions.AllBalancedParentheses(1)) Console.WriteLine(str);
            // Console.WriteLine();
        }
    }
}