using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DataStructuresAlgorithms.Tests
{
    public class PostfixCalcTests
    {
        [Fact]
        public void TestPostfixCalc()
        {
            Exercises exercises = new Exercises();

            Assert.Equal(9, exercises.PostfixCalc("1 2 + 3 *"));
            Assert.Equal(59, exercises.PostfixCalc("8 2 + 5 * 9 +"));
            Assert.Equal(59, exercises.PostfixCalc("8 2 + 5 * 9 + ="));

            Assert.Equal(-4, exercises.PostfixCalc("2 3 1 * + 9 -"));

            Assert.Equal(7, exercises.PostfixCalc("2 3 * 1 +"));
            Assert.Equal(1, exercises.PostfixCalc("3 2 - 1 *"));
            Assert.Equal(10, exercises.PostfixCalc("2 2 * 6 +"));
            Assert.Equal(2, exercises.PostfixCalc("6 3 /"));
            Assert.Equal(-1, exercises.PostfixCalc("1 2 -"));

            /*
            Assert.Throws<ArgumentException>(() => exercises.PostfixCalc("23^"));
            Assert.Throws<ArgumentException>(() => exercises.PostfixCalc("23!"));
            Assert.Throws<ArgumentException>(() => exercises.PostfixCalc("23a"));
            */
        }
    }
}