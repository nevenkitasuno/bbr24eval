using System;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class HashTableTests
    {
        [Fact]
        public void GeneralTest()
        {
            HashTable hashTable = new HashTable(32, 3);
            Assert.Equal(-1, hashTable.Find("cat"));
            Assert.NotEqual(-1, hashTable.Put("cat"));
            Assert.NotEqual(-1, hashTable.Put("bat"));
            Assert.NotEqual(-1, hashTable.Put("rat"));
            Assert.NotEqual(-1, hashTable.Put("dog"));
            Assert.NotEqual(-1, hashTable.Put("foo"));
            Assert.NotEqual(-1, hashTable.Put("bar"));

            Assert.NotEqual(-1, hashTable.Find("cat"));
            Assert.Equal(-1, hashTable.Find("lalala"));
        }

        [Fact]
        public void AddEqual_ShouldNotOverflow()
        {
            HashTable hashTable = new HashTable(3, 2);
            Assert.NotEqual(-1, hashTable.Put("cat"));
            Assert.NotEqual(-1, hashTable.Put("dog"));
            Assert.NotEqual(-1, hashTable.Put("dog"));
            Assert.NotEqual(-1, hashTable.Put("dog"));
            Assert.NotEqual(-1, hashTable.Put("dog"));
            Assert.NotEqual(-1, hashTable.Put("dog"));

            Assert.NotEqual(-1, hashTable.Find("cat"));
            Assert.NotEqual(-1, hashTable.Find("dog"));
            Assert.Equal(-1, hashTable.Find("lalala"));
        }

        [Fact]
        public void AddMany_ShouldOverflow()
        {
            HashTable hashTable = new HashTable(3, 2);
            Assert.NotEqual(-1, hashTable.Put("cat"));
            Assert.NotEqual(-1, hashTable.Put("bat"));
            Assert.NotEqual(-1, hashTable.Put("rat"));
            Assert.Equal(-1, hashTable.Put("dog"));
            Assert.Equal(-1, hashTable.Put("foo"));
            Assert.Equal(-1, hashTable.Put("bar"));

            Assert.NotEqual(-1, hashTable.Find("cat"));
        }
    }
}
