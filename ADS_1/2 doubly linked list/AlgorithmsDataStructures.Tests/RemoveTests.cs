using System.Globalization;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class RemoveTests
    {
        [Fact]
        public void Remove_ShouldRemoveNodeWithGivenValue()
        {
            // Arrange
            var linkedList = new LinkedList2();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(3));

            // Act
            linkedList.Remove(2);

            // Assert
            Assert.Equal(1, linkedList.head.value);
            Assert.Equal(3, linkedList.head.next.value);
            Assert.Equal(3, linkedList.tail.value);
            Assert.Null(linkedList.head.next.next);
            Assert.Null(linkedList.tail.next);
            Assert.Null(linkedList.head.prev);
            Assert.Equal(1, linkedList.tail.prev.value);
        }

        [Fact]
        public void Remove_ShouldRemoveTail()
        {
            // Arrange
            var linkedList = new LinkedList2();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(3));

            // Act
            linkedList.Remove(3);

            // Assert
            Assert.Equal(1, linkedList.head.value);
            Assert.Equal(2, linkedList.head.next.value);
            Assert.Equal(2, linkedList.tail.value);
            Assert.Null(linkedList.head.next.next);
            Assert.Null(linkedList.tail.next);
            Assert.Null(linkedList.head.prev);
            Assert.Equal(1, linkedList.tail.prev.value);
        }

        [Fact]
        public void Remove_ShouldRemoveOne()
        {
            // Arrange
            var linkedList = new LinkedList2();
            linkedList.AddInTail(new Node(1));

            // Act
            linkedList.Remove(1);

            // Assert
            Assert.Null(linkedList.head);
            Assert.Null(linkedList.tail);
        }

        [Fact]
        public void Remove_ShouldNotRemoveNodeIfValueDoesNotExist()
        {
            // Arrange
            var linkedList = new LinkedList2();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(3));

            // Act
            linkedList.Remove(4);

            // Assert
            Assert.True(linkedList.head.value == 1);
            Assert.True(linkedList.head.next.value == 2);
            Assert.True(linkedList.head.next.next.value == 3);
        }
    }
}