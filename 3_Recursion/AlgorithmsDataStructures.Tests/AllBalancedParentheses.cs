using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    [Collection("Sequential")]
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

            List<string> answer4 = RecursionFunctions.AllBalancedParentheses(4);
            Assert.Equal(14, answer4.Count);
            
            // foreach (string str in RecursionFunctions.AllBalancedParentheses(1)) Console.WriteLine(str);
            // Console.WriteLine();
        }
    }
}