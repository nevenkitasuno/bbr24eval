using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests {
    public class AddTests {

        [Fact]
        public void Add_ToEmptyList_AddsValueAtAHead()
        {
            var orderedList = new OrderedList<int>(true);
            Assert.Equal(0, orderedList.Count());
            Assert.Null(orderedList.head);
            Assert.Null(orderedList.tail);
            orderedList.Add(5);
            Assert.Equal(5, orderedList.head.value);
            Assert.Equal(5, orderedList.tail.value);
            Assert.Equal(1, orderedList.Count());
            Assert.Null(orderedList.head.prev);
            Assert.Null(orderedList.tail.next);
        }

        [Fact]
        public void Add_ToSortedList_AddsValueAtAProperPosition()
        {
            var orderedList = new OrderedList<int>(true);
            orderedList.Add(3);
            orderedList.Add(5);
            orderedList.Add(5);

            Assert.Null(orderedList.head.prev);
            Assert.Null(orderedList.tail.next);

            orderedList.Add(2);

            Assert.Equal(2, orderedList.head.value);
            Assert.Equal(3, orderedList.head.next.value);
            Assert.Equal(5, orderedList.head.next.next.value);
            Assert.Equal(5, orderedList.head.next.next.next.value);

            Assert.Equal(5, orderedList.tail.value);
            Assert.Equal(5, orderedList.tail.prev.value);
            Assert.Equal(3, orderedList.tail.prev.prev.value);
            Assert.Equal(2, orderedList.tail.prev.prev.prev.value);

            Assert.Null(orderedList.head.prev);
            Assert.Null(orderedList.tail.next);

            Assert.Equal(4, orderedList.Count());
        }

        [Fact]
        public void Add_ToDescendingList_AddsValueAtAProperPosition()
        {
            var orderedList = new OrderedList<int>(false);
            orderedList.Add(5);
            orderedList.Add(3);

            Assert.Null(orderedList.head.prev);
            Assert.Null(orderedList.tail.next);

            orderedList.Add(3);
            orderedList.Add(2);

            Assert.Equal(5, orderedList.head.value);
            Assert.Equal(3, orderedList.head.next.value);
            Assert.Equal(3, orderedList.head.next.next.value);
            Assert.Equal(2, orderedList.head.next.next.next.value);

            Assert.Equal(2, orderedList.tail.value);
            Assert.Equal(3, orderedList.tail.prev.value);
            Assert.Equal(3, orderedList.tail.prev.prev.value);
            Assert.Equal(5, orderedList.tail.prev.prev.prev.value);

            Assert.Null(orderedList.head.prev);
            Assert.Null(orderedList.tail.next);

            Assert.Equal(4, orderedList.Count());
        }

        [Fact]
        public void Add_WithStringValues_Asc()
        {
            var orderedList = new OrderedList<string>(true);
            orderedList.Add("bat");
            orderedList.Add("cat");
            orderedList.Add("ant");
            Assert.Equal("ant", orderedList.head.value);
            Assert.Equal("bat", orderedList.head.next.value);
            Assert.Equal("cat", orderedList.tail.value);
        }

        [Fact]
        public void Add_WithStringValues_Desc()
        {
            var orderedList = new OrderedList<string>(false);
            orderedList.Add("bat");
            orderedList.Add("cat");
            orderedList.Add("ant");
            Assert.Equal("cat", orderedList.head.value);
            Assert.Equal("bat", orderedList.head.next.value);
            Assert.Equal("ant", orderedList.tail.value);
        }
    }
}