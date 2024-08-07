using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class SimpleGraphTests
    {
        [Fact]
        public void TestDepthFirstSearch_ValidPath_ReturnsPath()
        {
            // Arrange
            var graph = new SimpleGraph<int>(5);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 5);

            // Act
            var result = graph.DepthFirstSearch(0, 4).Select(x => x.Value).ToList();

            // Assert
            Console.WriteLine();
            Assert.Equal(4, result.Count);
            var expected = new List<int> { 1, 2, 3, 5 };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestDepthFirstSearch_NoPath_ReturnsEmptyList()
        {
            // Arrange
            var graph = new SimpleGraph<int>(5);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);

            // Act
            var result = graph.DepthFirstSearch(0, 5);

            // Assert
            Assert.Empty(result);
        }
    }
}