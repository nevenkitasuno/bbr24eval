using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class InsertAfterTests
    {
        [Fact]
        public void InsertAfter_ShouldInsertNodeAtTheEnd()
        {
            // Arrange
            var linkedList = new LinkedList2();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));

            var nodeToInsert = new Node(3);
            var nodeAfter = linkedList.head.next;

            // Act
            linkedList.InsertAfter(nodeAfter, nodeToInsert);

            // Assert
            Assert.Equal(3, nodeAfter.next.value);
            Assert.Equal(3, linkedList.tail.value);
            Assert.Equal(2, linkedList.tail.prev.value);
        }

        [Fact]
        public void InsertAfter_ShouldInsertNodeAfterGivenNode()
        {
            // Arrange
            var linkedList = new LinkedList2();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(4));

            var nodeToInsert = new Node(3);
            var nodeAfter = linkedList.head.next;

            // Act
            linkedList.InsertAfter(nodeAfter, nodeToInsert);

            // Assert
            Assert.Equal(3, nodeAfter.next.value);
            Assert.Equal(3, linkedList.head.next.next.value);
        }

        [Fact]
        public void InsertAfter_ShouldInsertInTail()
        {
            // Arrange
            var linkedList = new LinkedList2();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(4));

            var nodeToInsert = new Node(3);
            var nodeAfter = linkedList.tail;

            // Act
            linkedList.InsertAfter(nodeAfter, nodeToInsert);

            // Assert
            Assert.Equal(3, nodeAfter.next.value);
            Assert.Null(nodeAfter.next.next);
            Assert.Equal(3, linkedList.tail.value);
            Assert.Null(linkedList.tail.next);
        }

        [Fact]
        public void InsertAfter_ShouldInsertNodeAtBeginningIfNodeAfterIsNull()
        {
            // Arrange
            var linkedList = new LinkedList2();
            linkedList.AddInTail(new Node(1));

            var nodeToInsert = new Node(0);

            // Act
            linkedList.InsertAfter(null, nodeToInsert);

            // Assert
            Assert.Equal(0, linkedList.head.value);
            Assert.Equal(1, linkedList.head.next.value);
        }
    }
}