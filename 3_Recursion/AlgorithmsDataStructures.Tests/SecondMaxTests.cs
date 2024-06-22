using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class SecondMaxTests
    {
        [Fact]
        public void GeneralTests()
        {
            Assert.Equal(5, RecursionFunctions.SecondMax(new List<int>{5, 4, 3, 2, 5}));
            Assert.Equal(4, RecursionFunctions.SecondMax(new List<int>{5, 3, 4, 2, 1}));
            Assert.Equal(4, RecursionFunctions.SecondMax(new List<int>{4, 3, 2, 5}));
        }

        [Fact]
        public void EmptyListTest()
        {
            Assert.Equal(0, RecursionFunctions.SecondMax(new List<int>()));
        }
    }
}