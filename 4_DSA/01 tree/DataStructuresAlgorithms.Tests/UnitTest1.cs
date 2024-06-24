using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class SimpleTreeTests
    {
        [Fact]
        public void TestSimpleTreeCreation()
        {
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            Assert.Equal(1, tree.Root.NodeValue);
            Assert.Null(tree.Root.Parent);
            Assert.Null(tree.Root.Children);
        }

        [Fact]
        public void TestAddChild()
        {
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            Assert.Equal(2, tree.Root.Children[0].NodeValue);
            Assert.Equal(tree.Root, tree.Root.Children[0].Parent);
        }

        [Fact]
        public void TestDeleteNode()
        {
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            tree.DeleteNode(tree.Root.Children[0]);
            Assert.Null(tree.Root.Children);
        }

        [Fact]
        public void TestFindNodesByValue()
        {
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(3, tree.Root));
            var result = tree.FindNodesByValue(2);
            Assert.Single(result);
            Assert.Equal(2, result[0].NodeValue);
        }

        [Fact]
        public void TestMoveNode()
        {
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            tree.MoveNode(tree.Root.Children[0], null);
            Assert.Null(tree.Root.Children);
        }

        [Fact]
        public void TestCount()
        {
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(3, tree.Root));
            Assert.Equal(3, tree.Count());
        }

        [Fact]
        public void TestLeafCount()
        {
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(3, tree.Root));
            Assert.Equal(2, tree.LeafCount());
        }
    }
}