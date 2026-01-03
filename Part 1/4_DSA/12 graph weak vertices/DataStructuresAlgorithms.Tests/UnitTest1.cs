using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class SimpleGraphTests
    {
        [Fact]
        public void WeakVertices_ReturnsCorrectWeakVertices_FromExample()
        {
            // Arrange
            var graph = new SimpleGraph<int>(9);
            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddVertex(8);
            graph.AddVertex(9);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 3);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 5);
            graph.AddEdge(2, 7);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 6);
            graph.AddEdge(4, 5);
            graph.AddEdge(4, 6);
            graph.AddEdge(5, 7);
            graph.AddEdge(7, 8);

            // Act
            var weakVertices = graph.WeakVertices();

            // Assert
            Assert.Equal(2, weakVertices.Count);
            Assert.Equal(1, weakVertices[0].Value);
            Assert.Equal(8, weakVertices[1].Value);
        }
    }
}