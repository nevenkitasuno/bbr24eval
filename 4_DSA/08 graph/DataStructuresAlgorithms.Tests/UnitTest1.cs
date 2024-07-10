using System;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddVertex()
        {
            int size = 5;
            SimpleGraph graph = new SimpleGraph(size);
            graph.AddVertex(1);
            Assert.Equal(1, graph.vertex[0].Value);
            for (int i = 0; i < size; i++) Assert.False(graph.IsEdge(0, i));
        }

        [Fact]
        public void TestAddRemoveEdge()
        {
            int size = 5;
            SimpleGraph graph = new SimpleGraph(size);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddEdge(0, 1);
            Assert.True(graph.IsEdge(0, 1));
            graph.RemoveEdge(0, 1);
            Assert.False(graph.IsEdge(0, 1));
        }

        [Fact]
        public void TestRemoveVertex()
        {
            int size = 5;
            SimpleGraph graph = new SimpleGraph(size);
            for (int i = 0; i < size; i++) graph.AddVertex(i);
            graph.AddEdge(0, 2);
            graph.RemoveVertex(2);
            Assert.False(graph.IsEdge(0, 2));
            Assert.Null(graph.vertex[2]);
            for (int i = 0; i < size; i++)
            {
                if (i == 2) continue;
                Assert.Equal(i, graph.vertex[i].Value);
            }
        }
    
    }
}
