using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures {
    public class AddTailTests {
        [Fact]
        public void TestAddTail() {
            Deque<int> deque = new Deque<int>();
            Assert.Equal(0, deque.Size());
            deque.AddTail(1);
            Assert.Equal(1, deque.Size());
            Assert.Equal(1, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
            deque.AddTail(2);
            Assert.Equal(1, deque.Size());
            Assert.Equal(2, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
        }
        [Fact]
        public void TestAddTailWithInitialList() {
            Deque<int> deque = new Deque<int>(new List<int> { 1, 2, 3 });
            Assert.Equal(3, deque.Size());
            Assert.Equal(3, deque.RemoveTail());
            Assert.Equal(2, deque.Size());
            Assert.Equal(2, deque.RemoveTail());
            Assert.Equal(1, deque.RemoveTail());
            Assert.Equal(0, deque.Size());
            deque.AddTail(4);
            Assert.Equal(1, deque.Size());
            deque.AddTail(5);
            Assert.Equal(2, deque.Size());
            Assert.Equal(5, deque.RemoveTail());
            Assert.Equal(4, deque.RemoveFront());
        }

        [Fact]
        public void AddTail_AddsElementToTailOfDeque()
        {
            var deque = new Deque<int>();
            deque.AddTail(10);
            Assert.Equal(10, deque.RemoveTail());
        }

        [Fact]
        public void AddTail_AddsMultipleElementsToTailOfDeque()
        {
            var deque = new Deque<int>();
            deque.AddTail(10);
            deque.AddTail(20);
            Assert.Equal(20, deque.RemoveTail());
            Assert.Equal(10, deque.RemoveTail());
        }
    }
}