using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class SizeTests
    {
        [Fact]
        public void Size_ReturnsCorrectSizeOfDeque()
        {
            var deque = new Deque<int>();
            Assert.Equal(0, deque.Size());
            deque.AddFront(10);
            Assert.Equal(1, deque.Size());
            deque.AddTail(20);
            Assert.Equal(2, deque.Size());
        }
    }
}