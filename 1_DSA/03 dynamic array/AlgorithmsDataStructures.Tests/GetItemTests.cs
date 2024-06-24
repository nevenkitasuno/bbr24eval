using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class GetItemTests
    {
        [Fact]
        public void GetItem_ReturnsCorrectValueWhenIndexIsValid()
        {
            var dynArray = new DynArray<int>();
            dynArray.Append(1);
            dynArray.Append(2);
            dynArray.Append(3);

            Assert.Equal(2, dynArray.GetItem(1));
        }

        [Fact]
        public void GetItem_ReturnsDefaultValueWhenIndexIsOutOfBounds()
        {
            var dynArray = new DynArray<int>();
            dynArray.Append(1);
            dynArray.Append(2);
            dynArray.Append(3);

            Assert.Throws<IndexOutOfRangeException>(() => dynArray.GetItem(3));
        }
    }
}