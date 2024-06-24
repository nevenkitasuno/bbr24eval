using System.Collections.Generic;
using Xunit;

namespace DataStructuresAlgorithms.Tests
{
    public class AddInTailTests
    {
        // данный метод
        [Fact]
        public void AddInTail_EmptyLinkedList_AddsNode()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();

            // Act
            linkedList.AddInTail(new Node(1));

            // Assert
            Assert.NotNull(linkedList.head);
            Assert.Equal(1, linkedList.head.value);
            Assert.Null(linkedList.head.next);
        }

        [Fact]
        public void AddInTail_EmptyLinkedList_AddsTwoNodes()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();

            // Act
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));

            // Assert
            Assert.Null(linkedList.tail.next);
            Assert.Equal(2, linkedList.tail.value);
        }

        [Fact]
        public void AddInTail_NonEmptyLinkedList_UpdatesTail()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));

            // Act
            linkedList.AddInTail(new Node(3));

            // Assert
            Assert.Equal(3, linkedList.tail.value);
        }

        [Fact]
        public void AddInTail_NonEmptyLinkedList_AddsNodeSameValue()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(3));

            // Assert
            Assert.Equal(1, linkedList.head.value);
            Assert.Equal(2, linkedList.head.next.value);
            Assert.Equal(2, linkedList.head.next.next.value);
            Assert.Equal(3, linkedList.head.next.next.next.value);
            Assert.Equal(3, linkedList.tail.value);
            Assert.Null(linkedList.head.next.next.next.next);
            Assert.Null(linkedList.tail.next);
        }
    }
}