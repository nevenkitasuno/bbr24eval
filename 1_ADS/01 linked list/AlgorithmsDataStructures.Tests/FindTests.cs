using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class FindTests
    {
        // данный метод
        [Fact]
        public void Find_EmptyLinkedList_ReturnsNull()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();

            int valueToFind = 1;

            // Act
            Node result = linkedList.Find(valueToFind);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Find_SingleNodeLinkedList_ReturnsNode()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.AddInTail(new Node(1));

            int valueToFind = 1;

            // Act
            Node result = linkedList.Find(valueToFind);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.value);
        }

        [Fact]
        public void Find_MultipleNodesLinkedList_ReturnsNode()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(3));

            int valueToFind = 2;

            // Act
            Node result = linkedList.Find(valueToFind);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.value);
        }

        [Fact]
        public void Find_ValueNotInLinkedList_ReturnsNull()
        {
            // Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(3));

            int valueToFind = 4;

            // Act
            Node result = linkedList.Find(valueToFind);

            // Assert
            Assert.Null(result);
        }
    }
}