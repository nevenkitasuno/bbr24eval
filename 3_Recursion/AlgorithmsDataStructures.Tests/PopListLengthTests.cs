using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class PopListLengthTests
    {
        [Fact]
        public void GeneralTest()
        {
            var popList = PopList<int>.FromLinkedList(
                                        new LinkedList<int>(
                                        new List<int> {42, 42, 21, 42, 21, 42})); // just [42, 42, 21, 42, 21, 42] starting from C# 12
            Assert.True(popList.Pop());
            Assert.Equal(5, popList.Length());
            Assert.False(popList.Pop());
            Assert.Equal(0, popList.Length());
        }
    }
}