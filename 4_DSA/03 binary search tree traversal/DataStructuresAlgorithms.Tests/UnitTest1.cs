using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class UnitTest1
    {
        [Fact] 
        public void GeneralTest() // FAIL
        {
            var tree = new BST<int>(new BSTNode<int>(5, 2, null));
            tree.AddKeyValue(3, 4);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(6, 5);
            tree.AddKeyValue(7, 5);
            tree.AddKeyValue(7, 5);
            
            var result = tree.FindNodeByKey(4);

            Assert.NotNull(result.Node);
            Assert.Equal(4, result.Node.NodeKey);
            Assert.Equal(4, result.Node.NodeValue);
            Assert.NotNull(result.Node.Parent);
            Assert.Null(result.Node.LeftChild);
            Assert.Equal(5, tree.Count());

            tree.DeleteNodeByKey(9); // non-existing
            Assert.Equal(5, tree.Count());

            Assert.True(tree.DeleteNodeByKey(4)); // full-child
            result = tree.FindNodeByKey(4);
            Assert.False(result.NodeHasKey);
            Assert.Equal(4, tree.Count());

            tree.DeleteNodeByKey(9); // non-existing after deletion
            Assert.Equal(4, tree.Count());

            tree.DeleteNodeByKey(3); // left
            Assert.Equal(3, tree.Count());

            tree.DeleteNodeByKey(7); // right
            Assert.Equal(2, tree.Count());

            tree.DeleteNodeByKey(5); // head
            Assert.Equal(1, tree.Count());

            tree.DeleteNodeByKey(6); // last
            Assert.Equal(0, tree.Count());

            tree.AddKeyValue(3, 4); // add after last deletion

            tree.DeleteNodeByKey(7); // non-existing
            Assert.Equal(1, tree.Count());
        }

        [Fact] 
        public void DeleteNonExistingTest()
        {
            var tree = new BST<int>(new BSTNode<int>(5, 2, null));
            tree.AddKeyValue(3, 4);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(6, 5);
            tree.AddKeyValue(7, 5);
            Assert.Equal(5, tree.Count());

            tree.DeleteNodeByKey(9);
            Assert.Equal(5, tree.Count());
        }

        [Fact] 
        public void DeleteRightTest()
        {
            var tree = new BST<int>(new BSTNode<int>(5, 2, null));
            tree.AddKeyValue(3, 4);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(6, 5);
            tree.AddKeyValue(7, 5);
            Assert.Equal(5, tree.Count());

            tree.DeleteNodeByKey(7);
            Assert.Equal(4, tree.Count());
        }

        [Fact] 
        public void DeleteHeadTest()
        {
            var tree = new BST<int>(new BSTNode<int>(5, 2, null));
            tree.AddKeyValue(3, 4);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(6, 5);
            tree.AddKeyValue(7, 5);
            Assert.Equal(5, tree.Count());

            Assert.True(tree.DeleteNodeByKey(5));
            Assert.Equal(4, tree.Count());
        }

        [Fact] 
        public void DeleteLastTest()
        {
            var tree = new BST<int>(new BSTNode<int>(5, 2, null));
            Assert.Equal(1, tree.Count());

            tree.DeleteNodeByKey(5);
            Assert.Equal(0, tree.Count());
        }

        [Fact] 
        public void WideAllNodesTest()
        {
            var tree = new BST<int>(new BSTNode<int>(5, 2, null));
            tree.AddKeyValue(3, 4);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(6, 5);
            tree.AddKeyValue(7, 5);
            tree.AddKeyValue(2, 6);
            Assert.Equal(6, tree.Count());
            var nodes = tree.WideAllNodes();
            Assert.Equal(6, nodes.Count);
            Assert.Equal(5, nodes[0].NodeKey);
            Assert.Equal(3, nodes[1].NodeKey);
            Assert.Equal(6, nodes[2].NodeKey);
            Assert.Equal(2, nodes[3].NodeKey);
            Assert.Equal(4, nodes[4].NodeKey);
            Assert.Equal(7, nodes[5].NodeKey);
        }

        [Fact] 
        public void WideAllNodes_EmptyInputTest()
        {
            var tree = new BST<int>(null);
            Assert.Equal(0, tree.Count());
            var nodes = tree.WideAllNodes();
            Assert.Empty(nodes);
        }

        [Fact]
        public void DeepInOrderTest()
        {
            var tree = new BST<int>(new BSTNode<int>(5, 2, null));
            tree.AddKeyValue(3, 4);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(6, 5);
            tree.AddKeyValue(7, 5);
            tree.AddKeyValue(2, 6);
            Assert.Equal(6, tree.Count());
            var nodes = tree.DeepAllNodes(0);
            Assert.Equal(6, nodes.Count);
            Assert.Equal(2, nodes[0].NodeKey);
            Assert.Equal(3, nodes[1].NodeKey);
            Assert.Equal(4, nodes[2].NodeKey);
            Assert.Equal(5, nodes[3].NodeKey);
            Assert.Equal(6, nodes[4].NodeKey);
            Assert.Equal(7, nodes[5].NodeKey);
        }

        [Fact]
        public void DeepPreOrderTest()
        {
            var tree = new BST<int>(new BSTNode<int>(5, 2, null));
            tree.AddKeyValue(3, 4);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(6, 5);
            tree.AddKeyValue(7, 5);
            tree.AddKeyValue(2, 6);
            Assert.Equal(6, tree.Count());
            var nodes = tree.DeepAllNodes(1);
            Assert.Equal(6, nodes.Count);
            Assert.Equal(5, nodes[0].NodeKey);
            Assert.Equal(3, nodes[1].NodeKey);
            Assert.Equal(2, nodes[2].NodeKey);
            Assert.Equal(4, nodes[3].NodeKey);
            Assert.Equal(6, nodes[4].NodeKey);
            Assert.Equal(7, nodes[5].NodeKey);
        }

        [Fact]
        public void DeepPostOrderTest()
        {
            var tree = new BST<int>(new BSTNode<int>(5, 2, null));
            tree.AddKeyValue(3, 4);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(6, 5);
            tree.AddKeyValue(7, 5);
            tree.AddKeyValue(2, 6);
            Assert.Equal(6, tree.Count());
            var nodes = tree.DeepAllNodes(2);
            Assert.Equal(6, nodes.Count);
            Assert.Equal(2, nodes[0].NodeKey);
            Assert.Equal(4, nodes[1].NodeKey);
            Assert.Equal(3, nodes[2].NodeKey);
            Assert.Equal(7, nodes[3].NodeKey);
            Assert.Equal(6, nodes[4].NodeKey);
            Assert.Equal(5, nodes[5].NodeKey);
        }
    }
}
