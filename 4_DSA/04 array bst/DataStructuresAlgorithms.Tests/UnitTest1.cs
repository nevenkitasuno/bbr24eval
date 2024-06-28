using Xunit;
using AlgorithmsDataStructures2;

public class aBSTTests {
    [Fact]
    public void GeneralTests()
    {
        var aBST = new aBST(2);
        Assert.Equal(0, aBST.AddKey(3));
        Assert.Equal(1, aBST.AddKey(1));
        Assert.Equal(2, aBST.AddKey(5));
        Assert.Equal(3, aBST.AddKey(0));
        Assert.Equal(4, aBST.AddKey(2));
        Assert.Equal(5, aBST.AddKey(4));
        Assert.Equal(6, aBST.AddKey(6));
        Assert.Equal(-1, aBST.AddKey(7));
        Assert.Equal(2, aBST.AddKey(5));
        Assert.Equal(3, aBST.FindKeyIndex(0).Value);
    }
}