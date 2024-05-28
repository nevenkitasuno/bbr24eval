using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class RemoveTests
    {
        [Fact]
        public void TestRemoveBoth_RemoveFrontIsLast() {

            // Arrange
            Deque<int> deque = new Deque<int>();
            deque.AddFront(3);
            deque.AddTail(4);
            deque.AddFront(2);
            deque.AddTail(5);
            deque.AddFront(1);

            // Act, Assert
            Assert.Equal(5, deque.Size());
            Assert.Equal(1, deque.RemoveFront());
            Assert.Equal(4, deque.Size());
            Assert.Equal(5, deque.RemoveTail());
            Assert.Equal(3, deque.Size());
            Assert.Equal(2, deque.RemoveFront());
            Assert.Equal(2, deque.Size());
            Assert.Equal(4, deque.RemoveTail());
            Assert.Equal(1, deque.Size());
            Assert.Equal(3, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, deque.RemoveFront());
            Assert.Equal(0, deque.RemoveTail());
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, deque.Size());
        }

        [Fact]
        public void TestRemoveBoth_RemoveTailIsLast() {

            // Arrange
            Deque<int> deque = new Deque<int>();
            deque.AddFront(3);
            deque.AddTail(4);
            deque.AddFront(2);
            deque.AddTail(5);
            deque.AddFront(1);

            // Act, Assert
            Assert.Equal(5, deque.Size());
            Assert.Equal(1, deque.RemoveFront());
            Assert.Equal(4, deque.Size());
            Assert.Equal(5, deque.RemoveTail());
            Assert.Equal(3, deque.Size());
            Assert.Equal(2, deque.RemoveFront());
            Assert.Equal(2, deque.Size());
            Assert.Equal(4, deque.RemoveTail());
            Assert.Equal(1, deque.Size());
            Assert.Equal(3, deque.RemoveTail());
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, deque.RemoveFront());
            Assert.Equal(0, deque.RemoveTail());
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, deque.Size());
        }

        [Fact]
        public void TestRemoveBothWithInitialList() {
            Deque<int> deque = new Deque<int>(new List<int> { 1, 2, 3, 4, 5 });
            Assert.Equal(5, deque.Size());
            Assert.Equal(1, deque.RemoveFront());
            Assert.Equal(4, deque.Size());
            Assert.Equal(5, deque.RemoveTail());
            Assert.Equal(3, deque.Size());
            Assert.Equal(2, deque.RemoveFront());
            Assert.Equal(2, deque.Size());
            Assert.Equal(4, deque.RemoveTail());
            Assert.Equal(1, deque.Size());
            Assert.Equal(3, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, deque.RemoveFront());
            Assert.Equal(0, deque.RemoveTail());
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, deque.Size());
        }
    }
}