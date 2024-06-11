using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class AddFrontTests
    {
        [Fact]
        public void AddFront_AddsElementToFrontOfDeque()
        {
            var deque = new Deque<int>();
            deque.AddFront(10);
            Assert.Equal(10, deque.RemoveFront());
        }

        [Fact]
        public void AddFront_AddsMultipleElementsToFrontOfDeque()
        {
            var deque = new Deque<int>();
            deque.AddFront(10);
            deque.AddFront(20);
            Assert.Equal(20, deque.RemoveFront());
            Assert.Equal(10, deque.RemoveFront());
        }
    }
}