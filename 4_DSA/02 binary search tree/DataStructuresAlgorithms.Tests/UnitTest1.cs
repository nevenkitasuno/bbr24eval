using System;
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

            tree.DeleteNodeByKey(4); // full-child
            result = tree.FindNodeByKey(4);
            Assert.Null(result.Node);
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
            Assert.Equal(1, tree.Count());

            tree.AddKeyValue(3, 4); // add after last deletion
            Assert.NotNull(result.Node);
            Assert.Equal(3, result.Node.NodeKey);
            Assert.Equal(4, result.Node.NodeValue);

            tree.DeleteNodeByKey(7); // right
            Assert.Equal(2, tree.Count());
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
        public void DeleteHeadTest() // FAIL
        {
            var tree = new BST<int>(new BSTNode<int>(5, 2, null));
            tree.AddKeyValue(3, 4);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(6, 5);
            tree.AddKeyValue(7, 5);
            Assert.Equal(5, tree.Count());

            tree.DeleteNodeByKey(5);
            Assert.Equal(4, tree.Count());
        }

        [Fact] 
        public void DeleteLastTest() // FAIL
        {
            var tree = new BST<int>(new BSTNode<int>(5, 2, null));
            Assert.Equal(1, tree.Count());

            tree.DeleteNodeByKey(5);
            Assert.Equal(0, tree.Count());
        }
    }
}
