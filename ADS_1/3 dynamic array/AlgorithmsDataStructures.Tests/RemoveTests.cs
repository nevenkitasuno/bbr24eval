using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class RemoveTests
    {
        [Fact]
        public void Remove_RemovesItemFromArrayWhenIndexIsValid()
        {
            var dynArray = new DynArray<int>();
            dynArray.Append(1);
            dynArray.Append(2);
            dynArray.Append(3);

            dynArray.Remove(1);

            Assert.Equal(2, dynArray.count);
            Assert.Equal(1, dynArray.array[0]);
            Assert.Equal(3, dynArray.array[1]);
        }

        [Fact]
        public void Remove_ReducesBelowMinimumCapacity()
        {
            var dynArray = new DynArray<int>();
            for (int i = 1; i <= 16; i++) dynArray.Append(i);

            Assert.Equal(16, dynArray.capacity);
            Assert.Equal(16, dynArray.count);

            dynArray.Remove(10);

            Assert.Equal(16, dynArray.capacity);
            Assert.Equal(15, dynArray.count);
        }

        // for exercise

        [Fact]
        public void Remove_RemovesItemWhenCapacityNotFull()
        {
            var dynArray = new DynArray<int>();
            dynArray.Append(1);
            dynArray.Append(2);
            dynArray.Append(3);

            dynArray.Remove(1);

            Assert.Equal(2, dynArray.count);
            Assert.Equal(1, dynArray.array[0]);
            Assert.Equal(3, dynArray.array[1]);
            Assert.Equal(2, dynArray.count);
            Assert.Equal(16, dynArray.capacity);
        }

        [Fact]
        public void Remove_ReducesCapacityWhenNecessary()
        {
            var dynArray = new DynArray<int>();
            for (int i = 1; i <= 40; i++) dynArray.Append(i);

            for (int i = 1; i <= 20; i++) dynArray.Remove(10);

            Assert.Equal(28, dynArray.capacity);
            Assert.Equal(20, dynArray.count);
            Assert.Equal(40, dynArray.array[19]);
        }

        [Fact]
        public void Remove_ThrowsExceptionWhenTryingToRemoveAtInvalidIndex()
        {
            var dynArray = new DynArray<int>();
            dynArray.Append(1);
            dynArray.Append(2);

            Assert.Throws<IndexOutOfRangeException>(() => dynArray.Remove(3));
        }
    }
}