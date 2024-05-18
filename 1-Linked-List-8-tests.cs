using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class SumElementsTests
    {
        [Fact]
        public void SumElements_Empty()
        {
            // Arrange
            LinkedList first = new LinkedList();
            LinkedList second = new LinkedList();

            // Act
            var result = first.SumElements(second);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void SumElements_Unequal()
        {
            // Arrange
            LinkedList first = new LinkedList();
            first.AddInTail(new Node(1));
            first.AddInTail(new Node(2));
            LinkedList second = new LinkedList();
            second.AddInTail(new Node(1));

            // Act
            var result = first.SumElements(second);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void SumElements_One()
        {
            // Arrange
            LinkedList first = new LinkedList();
            first.AddInTail(new Node(4));
            LinkedList second = new LinkedList();
            second.AddInTail(new Node(7));

            // Act
            var result = first.SumElements(second);

            // Assert
            Assert.Equal(11, result.head.value);
            Assert.Equal(11, result.tail.value);
            Assert.Equal(result.head, result.tail);
            Assert.Null(result.head.next);
        }

        [Fact]
        public void SumElements_Many()
        {
            // Arrange
            LinkedList first = new LinkedList();
            first.AddInTail(new Node(1));
            first.AddInTail(new Node(2));
            first.AddInTail(new Node(3));
            first.AddInTail(new Node(4));
            LinkedList second = new LinkedList();
            second.AddInTail(new Node(4));
            second.AddInTail(new Node(5));
            second.AddInTail(new Node(4));
            second.AddInTail(new Node(5));

            // Act
            var result = first.SumElements(second);

            // Assert
            Assert.Equal(4, result.Count());
            Assert.Equal(5, result.head.value);
            Assert.Equal(7, result.head.next.value);
            Assert.Equal(7, result.head.next.next.value);
            Assert.Equal(9, result.tail.value);
            Assert.Null(result.tail.next);
        }
    }
}
