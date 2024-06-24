using System.Collections.Generic;
using Xunit;

namespace DataStructuresAlgorithms.Tests
{
    public class MakeArrayTests
    {
        [Fact]
        public void MakeArray_InitializesArrayWithCorrectCapacity()
        {
            var dynArray = new DynArray<int>();
            Assert.Equal(16, dynArray.capacity);
        }

        [Fact]
        public void MakeArray_ChangesCapacityWhenCalledWithNewValue()
        {
            var dynArray = new DynArray<int>();
            dynArray.MakeArray(32);
            Assert.Equal(32, dynArray.capacity);
        }
    }
}