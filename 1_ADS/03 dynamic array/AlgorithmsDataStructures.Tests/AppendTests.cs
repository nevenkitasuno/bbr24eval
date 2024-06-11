using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class AppendTests
    {
        [Fact]
        public void Append_AppendsItemToArrayWhenCapacityIsNotFull()
        {
            var dynArray = new DynArray<int>();
            dynArray.Append(1);
            dynArray.Append(2);

            Assert.Equal(2, dynArray.count);
            Assert.Equal(1, dynArray.array[0]);
            Assert.Equal(2, dynArray.array[1]);
        }

        [Fact]
        public void Append_DoublesCapacityWhenFull()
        {
            var dynArray = new DynArray<int>();
            for (int i = 0; i < 16; i++)
            {
                dynArray.Append(i);
            }

            Assert.Equal(16, dynArray.capacity);
            Assert.Equal(16, dynArray.count);
        }
    }
}