using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GeneralTestFromExample()
        {
            //Arrange
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            SimpleTreeNode<int> node1 = new (2, tree.Root);
            tree.AddChild(node1, new SimpleTreeNode<int>(5, node1));
            tree.AddChild(node1, new SimpleTreeNode<int>(7, node1));
            tree.AddChild(tree.Root, node1);

            SimpleTreeNode<int> node2 = new (3, tree.Root);
            tree.AddChild(node2, new SimpleTreeNode<int>(4, node2));
            tree.AddChild(tree.Root, node2);

            SimpleTreeNode<int> node3 = new (6, tree.Root);
            SimpleTreeNode<int> node3_1 = new (8, node3);
            tree.AddChild(node3_1, new SimpleTreeNode<int>(9, node3_1));
            tree.AddChild(node3_1, new SimpleTreeNode<int>(10, node3_1));
            tree.AddChild(node3, node3_1);
            
            tree.AddChild(tree.Root, node3);
            
            //Act
            List<int> res = tree.EvenTrees();
            
            //Assert
            Assert.Equal(4, res.Count);
            Assert.Equal(res, new List<int> {1, 3, 1, 6});
        }
    }
}
