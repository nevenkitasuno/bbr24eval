using Xunit;
using AlgorithmsDataStructures2;

public class BalancedBSTTests
{
    [Fact]
    public void GenerateTree_Test()
    {
        BalancedBST bst = new BalancedBST();
        int[] array = { 1, 2, 3, 4, 5 };
        bst.GenerateTree(array);

        Assert.NotNull(bst.Root);
        Assert.Equal(3, bst.Root.NodeKey);
        Assert.Equal(2, bst.Root.LeftChild.NodeKey);
        Assert.Equal(5, bst.Root.RightChild.NodeKey);
    }

    [Fact]
    public void IsBalanced_Test()
    {
        BalancedBST bst = new BalancedBST();
        int[] array1 = { 1, 2, 3, 4, 5 };
        int[] array2 = { 1, 2, 3, 4, 5, 6, 7 };
        int[] array3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        bst.GenerateTree(array1);
        Assert.True(bst.IsBalanced(bst.Root));
        bst.GenerateTree(array2);
        Assert.True(bst.IsBalanced(bst.Root));
        bst.GenerateTree(array3);
        Assert.True(bst.IsBalanced(bst.Root));
    }

    [Fact]
    public void IsBalanced_NotBalanced_Test()
    {
        BalancedBST bst = new BalancedBST
        {
            Root = new BSTNode(3, null)
        };
        bst.Root.LeftChild = new BSTNode(2, bst.Root);
        bst.Root.RightChild = new BSTNode(4, bst.Root);
        bst.Root.LeftChild.LeftChild = new BSTNode(0, bst.Root.LeftChild);
        bst.Root.LeftChild.LeftChild.RightChild = new BSTNode(1, bst.Root.LeftChild.LeftChild);

        Assert.False(bst.IsBalanced(bst.Root));
    }
}