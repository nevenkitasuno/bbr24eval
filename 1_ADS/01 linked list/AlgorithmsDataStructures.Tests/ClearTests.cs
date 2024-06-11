using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class ClearTests
    {
        [Fact]
        public void Clear_ShouldClearLinkedList()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));

            // Act
            linkedList.Clear();

            // Assert
            Assert.Null(linkedList.head);
            Assert.Null(linkedList.tail);
        }
    }
}