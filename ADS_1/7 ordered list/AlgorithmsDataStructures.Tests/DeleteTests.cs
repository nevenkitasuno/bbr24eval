using System.Collections.Generic;
using AlgorithmsDataStructures;
using Xunit;

namespace AlgorithmsDataStructuresTests {
    public class DeleteTests {
        [Fact]
        public void Delete_ExistingValue_RemovesValue()
        {
            var orderedList = new OrderedList<int>(true);
            orderedList.Add(5);
            orderedList.Add(3);
            orderedList.Add(2);
            Assert.Equal(2, orderedList.head.value);
            Assert.Equal(3, orderedList.head.next.value);
            Assert.Equal(5, orderedList.tail.value);
            Assert.Equal(3, orderedList.Count());
            orderedList.Delete(3);
            Assert.Null(orderedList.Find(3));
            Assert.Equal(2, orderedList.head.value);
            Assert.Equal(5, orderedList.tail.value);
            Assert.Equal(2, orderedList.Count());
        }
        
        [Fact]
        public void Delete_ExistingValue_DescList()
        {
            var orderedList = new OrderedList<int>(false);
            orderedList.Add(5);
            orderedList.Add(3);
            orderedList.Add(3);
            orderedList.Add(2);
            Assert.Equal(5, orderedList.head.value);
            Assert.Equal(3, orderedList.head.next.value);
            Assert.Equal(3, orderedList.tail.prev.value);
            Assert.Equal(2, orderedList.tail.value);
            Assert.Equal(4, orderedList.Count());
            orderedList.Delete(3);
            Assert.Equal(5, orderedList.head.value);
            Assert.Equal(2, orderedList.tail.value);
            Assert.Equal(3, orderedList.tail.prev.value);
            Assert.Equal(5, orderedList.tail.prev.prev.value);
            Assert.Equal(3, orderedList.Count());
        }

        [Fact]
        public void Delete_NonExistingValue_DoesNotChangeList()
        {
            var orderedList = new OrderedList<int>(true);
            orderedList.Add(5);
            orderedList.Add(3);
            orderedList.Add(2);
            Assert.Equal(2, orderedList.head.value);
            Assert.Equal(3, orderedList.head.next.value);
            Assert.Equal(5, orderedList.tail.value);
            Assert.Equal(3, orderedList.Count());
            orderedList.Delete(7);
            Assert.Null(orderedList.Find(7));
            Assert.Equal(2, orderedList.head.value);
            Assert.Equal(3, orderedList.head.next.value);
            Assert.Equal(5, orderedList.tail.value);
            Assert.Equal(3, orderedList.Count());
        }

        [Fact]
        public void Delete_ToEmpty()
        {
            var orderedList = new OrderedList<int>(true);
            orderedList.Add(5);
            orderedList.Add(3);
            orderedList.Add(2);
            Assert.Equal(2, orderedList.head.value);
            Assert.Equal(3, orderedList.head.next.value);
            Assert.Equal(5, orderedList.tail.value);
            Assert.Equal(3, orderedList.Count());
            orderedList.Delete(3);
            orderedList.Delete(2);
            orderedList.Delete(5);
            orderedList.Delete(7);
            Assert.Null(orderedList.Find(5));
            Assert.Null(orderedList.head);
            Assert.Null(orderedList.tail);
            Assert.Equal(0, orderedList.Count());
        }

        [Fact]
        public void Delete_Empty()
        {
            var orderedList = new OrderedList<int>(true);
            Assert.Equal(0, orderedList.Count());
            orderedList.Delete(3);
            orderedList.Delete(2);
            orderedList.Delete(5);
            orderedList.Delete(7);
            Assert.Null(orderedList.Find(5));
            Assert.Null(orderedList.head);
            Assert.Null(orderedList.tail);
            Assert.Equal(0, orderedList.Count());
        }
    }
}