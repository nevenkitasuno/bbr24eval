using System;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class UnitTest1
    {
        [Fact] 
        public void GeneralTest()
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
        }
    }
}
