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
            List<string> answer = RecursionFunctions.AllBalancedParentheses(0);
            foreach (string str in answer) Console.WriteLine(str);
            Console.WriteLine();
            
            foreach (string str in RecursionFunctions.AllBalancedParentheses(1)) Console.WriteLine(str);
            Console.WriteLine();
            foreach (string str in RecursionFunctions.AllBalancedParentheses(2)) Console.WriteLine(str);
            Console.WriteLine();
            foreach (string str in RecursionFunctions.AllBalancedParentheses(3)) Console.WriteLine(str);
            Console.WriteLine();
            Assert.True(true);
        }
    }
}