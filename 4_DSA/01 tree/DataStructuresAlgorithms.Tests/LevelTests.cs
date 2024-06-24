using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class SimpleTreeNodeLevelTests
    {
        [Fact]
        public void TestInitialLevelAtAcreation()
        {
            var node = new SimpleTreeNode<int>(1, null);
            Assert.Equal(0, node.Level);
        }

        [Fact]
        public void TestChildLevelAtAcreationAtAcreation()
        {
            var parent = new SimpleTreeNode<int>(1, null);
            var child = new SimpleTreeNode<int>(2, parent);
            Assert.Equal(1, child.Level);
        }

        [Fact]
        public void TestDescendantLevelAtAcreationAtAcreation()
        {
            var parent = new SimpleTreeNode<int>(1, null);
            var child = new SimpleTreeNode<int>(2, parent);
            var grandchild = new SimpleTreeNode<int>(3, child);
            Assert.Equal(2, grandchild.Level);
        }
    }
}