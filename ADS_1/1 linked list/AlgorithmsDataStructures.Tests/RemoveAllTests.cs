using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class RemoveAllTests
    {
        [Fact]
        public void RemoveAll_ShouldRemoveAllNodesWithGivenValue()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(3));

            // Act
            linkedList.RemoveAll(2);

            // Assert
            Assert.Equal(1, linkedList.head.value);
            Assert.Equal(3, linkedList.head.next.value);
            Assert.Equal(3, linkedList.tail.value);
            Assert.Null(linkedList.head.next.next);
            Assert.Null(linkedList.tail.next);
        }

        [Fact]
        public void RemoveAll_ShouldRemoveFromFirst()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(3));

            // Act
            linkedList.RemoveAll(2);

            // Assert
            Assert.Equal(1, linkedList.head.value);
            Assert.Equal(3, linkedList.head.next.value);
            Assert.Equal(3, linkedList.tail.value);
            Assert.Null(linkedList.head.next.next);
            Assert.Null(linkedList.tail.next);
        }

        [Fact]
        public void RemoveAll_ShouldRemoveFromEnd()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(3));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(2));

            // Act
            linkedList.RemoveAll(2);

            // Assert
            Assert.Equal(1, linkedList.head.value);
            Assert.Equal(3, linkedList.head.next.value);
            Assert.Equal(3, linkedList.tail.value);
            Assert.Null(linkedList.head.next.next);
            Assert.Null(linkedList.tail.next);
        }

        [Fact]
        public void RemoveAll_ShouldRemoveAll()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(2));

            // Act
            linkedList.RemoveAll(2);

            // Assert
            Assert.Null(linkedList.head);
            Assert.Null(linkedList.tail);
        }

        [Fact]
        public void RemoveAll_ShouldRemoveToEnd()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(3));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(2));

            // Act
            linkedList.RemoveAll(2);

            // Assert
            Assert.Equal(1, linkedList.head.value);
            Assert.Equal(3, linkedList.head.next.value);
            Assert.Equal(3, linkedList.tail.value);
            Assert.Null(linkedList.head.next.next);
            Assert.Null(linkedList.tail.next);
        }

        [Fact]
        public void RemoveAll_ShouldNotRemoveNodesIfValueDoesNotExist()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(3));

            // Act
            linkedList.RemoveAll(4);

            // Assert
            Assert.True(linkedList.head.value == 1);
            Assert.True(linkedList.head.next.value == 2);
            Assert.True(linkedList.head.next.next.value == 3);
        }
    }
}