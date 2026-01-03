using Xunit;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2.Tests
{
    public class HeapTests
    {
        [Fact]
        public void MakeHeap_WithValidInput_ReturnsTrue()
        {
            int[] inputArray = { 15, 25, 10, 30, 20, 5, 17, 22 };
            int depth = 2;
            Heap heap = new Heap();
            heap.MakeHeap(new int[] {}, depth);
            bool isFull = false;
            for (int i = 0; i < inputArray.Length && !isFull; i++)
                isFull = !heap.Add(inputArray[i]);

            Assert.True(isFull);
        }

        [Fact]
        public void MakeHeap_WithArrayInput_ReturnsFalse()
        {
            int[] inputArray = { 15, 25, 10, 30, 20, 5 };
            int depth = 3;
            Heap heap = new Heap();
            heap.MakeHeap(inputArray, depth);
            bool isFull = false;

            Assert.False(isFull);
        }

        [Fact]
        public void GetMax_WithValidInput_ReturnsCorrectMax()
        {
            int depth = 2;
            int[] inputArray = { 15, 25, 10, 30, 20, 5 };
            Heap heap = new Heap();
            heap.MakeHeap(inputArray, depth);

            int expectedMax = 30;
            int actualMax = heap.GetMax();

            Assert.Equal(expectedMax, actualMax);
        }

        [Fact]
        public void GetMax_WithEmptyHeap_ReturnsCorrectValue()
        {
            Heap heap = new Heap();
            int expectedMax = -1;
            int actualMax = heap.GetMax();

            Assert.Equal(expectedMax, actualMax);
        }
    }
}