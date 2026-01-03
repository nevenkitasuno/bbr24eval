using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class SimpleGraphTests
    {
        [Fact]
        public void BreadthFirstSearch_ValidGraph_ReturnsCorrectPath()
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
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 5);

            // Act
            var result = graph.BreadthFirstSearch(0, 4);

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void BreadthFirstSearch_InvalidGraph_ReturnsEmptyList()
        {
            // Arrange
            var graph = new SimpleGraph<int>(5);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);

            // Act
            var result = graph.BreadthFirstSearch(0, 4);

            // Assert
            Assert.Empty(result);
        }
    }
}