using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlgorithmsDataStructures {
    public class RemoveFrontTests {
        [Fact]
        public void TestRemoveFront() {
            Deque<int> deque = new Deque<int>();
            Assert.Equal(0, deque.Size());
            deque.AddTail(1);
            Assert.Equal(1, deque.Size());
            Assert.Equal(1, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, deque.RemoveFront());
            Assert.Equal(0, deque.RemoveFront());
        }
        [Fact]
        public void TestRemoveFrontWithInitialList() {
            Deque<int> deque = new Deque<int>(new List<int> { 1, 2, 3 });
            Assert.Equal(3, deque.Size());
            Assert.Equal(1, deque.RemoveFront());
            Assert.Equal(2, deque.Size());
            Assert.Equal(2, deque.RemoveFront());
            Assert.Equal(3, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
        }

        [Fact]
        public void RemoveFront_RemovesElementFromFrontOfDeque()
        {
            var deque = new Deque<int>(new List<int> { 10, 20, 30 });
            Assert.Equal(3, deque.Size());
            Assert.Equal(10, deque.RemoveFront());
            Assert.Equal(2, deque.Size());
            Assert.Equal(20, deque.RemoveFront());
            Assert.Equal(1, deque.Size());
            Assert.Equal(30, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
            Assert.Equal(default, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, deque.Size());
            Assert.Equal(default, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
        }

        [Fact]
        public void RemoveFront_BigDeque()
        {
            var bigList = from number in Enumerable.Range(0, 100) select number;
            var deque = new Deque<int>(bigList);
            
            Assert.Equal(bigList.Count(), deque.Size());
            Assert.Equal(100, deque.Size());
            
            int j = 100;
            for (int i = 0; i <= 99; i++)
            {
                Assert.Equal(i, deque.RemoveFront());
                Assert.Equal(j - 1, deque.Size());
                j--;
            }
            Assert.Equal(0, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
        }
    }
}