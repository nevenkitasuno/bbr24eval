using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlgorithmsDataStructures
{
    public class RemoveTailTests
    {
        [Fact]
        public void TestRemoveTail()
        {
            var deque = new Deque<int>();
            deque.AddTail(1);
            deque.AddTail(2);
            deque.AddTail(3);

            Assert.Equal(3, deque.Size());
            Assert.Equal(3, deque.RemoveTail());
            Assert.Equal(2, deque.Size());
            Assert.Equal(2, deque.RemoveTail());
            Assert.Equal(1, deque.RemoveTail());
            Assert.Equal(0, deque.Size());
            Assert.Equal(default, deque.RemoveTail());
        }

        [Fact]
        public void RemoveTail_RemovesElementFromTailOfDeque()
        {
            var deque = new Deque<int>(new List<int> { 10, 20, 30 });
            Assert.Equal(30, deque.RemoveTail());
            Assert.Equal(20, deque.RemoveTail());
            Assert.Equal(10, deque.RemoveTail());
        }

        [Fact]
        public void RemoveTail_BigDeque()
        {
            var bigList = from number in Enumerable.Range(0, 100) select number;
            var deque = new Deque<int>(bigList);
            
            Assert.Equal(bigList.Count(), deque.Size());
            Assert.Equal(100, deque.Size());

            for (int i = 99; i >= 0; i--)
            {
                Assert.Equal(i, deque.RemoveTail());
                Assert.Equal(i, deque.Size());
            }
            Assert.Equal(0, deque.RemoveTail());
            Assert.Equal(0, deque.Size());
        }
    }
}