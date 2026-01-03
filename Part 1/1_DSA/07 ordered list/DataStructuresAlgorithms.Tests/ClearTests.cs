using System.Collections.Generic;
using Xunit;

namespace DataStructuresAlgorithms.Tests {
    public class ClearTests {
        [Fact]
        public void Clear_WithTrueAscending_RemovesAllValuesAtAscendingOrder()
        {
            var orderedList = new OrderedList<int>(true);
            orderedList.Add(5);
            orderedList.Add(3);
            orderedList.Add(2);
            Assert.Equal(2, orderedList.head.value);
            Assert.Equal(3, orderedList.head.next.value);
            Assert.Equal(5, orderedList.tail.value);
            Assert.Equal(3, orderedList.Count());
            orderedList.Clear(true);
            Assert.Null(orderedList.head);
            Assert.Equal(0, orderedList.Count());
            
            orderedList.Add(5);
            orderedList.Add(3);
            Assert.Equal(3, orderedList.head.value);
            Assert.Equal(2, orderedList.Count());
        }

        [Fact]
        public void Clear_WithFalseAscending_RemovesAllValuesAtAscendingOrder()
        {
            var orderedList = new OrderedList<int>(false);
            orderedList.Add(5);
            orderedList.Add(2);
            orderedList.Add(3);
            Assert.Equal(3, orderedList.tail.prev.value);
            Assert.Equal(2, orderedList.tail.value);
            Assert.Equal(5, orderedList.head.value);
            Assert.Equal(3, orderedList.Count());
            orderedList.Clear(false);
            Assert.Null(orderedList.tail);
            Assert.Null(orderedList.tail);
            Assert.Equal(0, orderedList.Count());
            
            orderedList.Add(5);
            orderedList.Add(3);
            Assert.Equal(5, orderedList.head.value);
            Assert.Equal(2, orderedList.Count());
        }

        [Fact]
        public void Clear_Empty()
        {
            var orderedList = new OrderedList<int>(false);
            orderedList.Clear(true);
            Assert.Null(orderedList.head);
            Assert.Equal(0, orderedList.Count());
            
            orderedList.Add(5);
            orderedList.Add(3);
            Assert.Equal(3, orderedList.head.value);
            Assert.Equal(2, orderedList.Count());
        }
    }
}