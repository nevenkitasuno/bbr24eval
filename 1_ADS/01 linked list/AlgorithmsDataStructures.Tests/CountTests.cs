using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class CountTests
    {
        [Fact]
        public void Count_ShouldReturnCorrectCountOfNodes()
        {
            // Arrange
            var linkedList = new LinkedList();
            linkedList.AddInTail(new Node(1));
            linkedList.AddInTail(new Node(2));
            linkedList.AddInTail(new Node(3));

            // Act
            int count = linkedList.Count();

            // Assert
            Assert.Equal(3, count);
        }
    }
}