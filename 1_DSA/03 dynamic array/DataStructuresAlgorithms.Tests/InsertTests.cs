using System;
using System.Collections.Generic;
using Xunit;

namespace DataStructuresAlgorithms.Tests
{
    public class InsertTests
    {
        [Fact]
        public void Insert_InsertsItemAtCorrectIndex()
        {
            var dynArray = new DynArray<int>();
            dynArray.Append(1);
            dynArray.Append(2);

            dynArray.Insert(3, 1);

            Assert.Equal(3, dynArray.array[1]);
            Assert.Equal(2, dynArray.array[2]);
            Assert.Equal(1, dynArray.array[0]);
        }

        [Fact]
        public void Insert_AtTail()
        {
            var dynArray = new DynArray<int>();
            dynArray.Append(1);
            dynArray.Append(2);

            dynArray.Insert(3, dynArray.count);
            Assert.Equal(3, dynArray.array[2]);
        }

        // For exercise

        [Fact]
        public void Insert_InsertsItemWhenCapacityNotFull()
        {
            var dynArray = new DynArray<int>();
            dynArray.Append(1);
            dynArray.Append(2);

            dynArray.Insert(3, 1);

            Assert.Equal(1, dynArray.array[0]);
            Assert.Equal(3, dynArray.array[1]);
            Assert.Equal(2, dynArray.array[2]);
            Assert.Equal(3, dynArray.count);
            Assert.Equal(16, dynArray.capacity);
        }

        [Fact]
        public void Insert_DoublesCapacityWhenFull()
        {
            var dynArray = new DynArray<int>();
            for (int i = 0; i < 16; i++)
            {
                dynArray.Append(i);
            }

            Assert.Equal(16, dynArray.capacity);
            Assert.Equal(16, dynArray.count);

            dynArray.Insert(16, 0);

            Assert.Equal(32, dynArray.capacity);
            Assert.Equal(17, dynArray.count);
        }

        [Fact]
        public void Insert_ThrowsExceptionWhenTryingToInsertAtInvalidIndex()
        {
            var dynArray = new DynArray<int>();
            dynArray.Append(1);
            dynArray.Append(2);

            Assert.Throws<IndexOutOfRangeException>(() => dynArray.Insert(3, 3));
        }
    }
}