using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class FindAllTests
    {
        [Fact]
        public void FindAll_EmptyLinkedList_ReturnsEmptyList()
        {
            // Arrange
            LinkedList2 linkedList = new LinkedList2();

            int valueToFind = 1;

            // Act
            List<Node> result = linkedList.FindAll(valueToFind);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void FindAll_SingleNodeLinkedList_ReturnsSingleNodeList()
        {
            // Arrange
            LinkedList2 linkedList = new LinkedList2();
            linkedList.AddInTail(new Node(1));

            int valueToFind = 1;

            // Act
            List<Node> result = linkedList.FindAll(valueToFind);

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result[0].value);
        }

        [Fact]
        public void FindAll_MultipleNodesLinkedList_ReturnsMultipleNodesList()
        {
            // Arrange
            LinkedList2 linkedList = new LinkedList2();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(3));

            int valueToFind = 2;

            // Act
            List<Node> result = linkedList.FindAll(valueToFind);

            // Assert
            Assert.Single(result);
            Assert.Equal(2, result[0].value);
        }

        [Fact]
        public void FindAll_ValueGreaterThanMaxValue_ReturnsEmptyList()
        {
            // Arrange
            LinkedList2 linkedList = new LinkedList2();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(3));

            int valueToFind = 4;

            // Act
            List<Node> result = linkedList.FindAll(valueToFind);

            // Assert
            Assert.Empty(result);
        }
    }
}