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

        [Fact]
        public void Collision()
        {
            /*
            this test relies heavily on current implementation

            sum of letter indexes are equal
            and my hash fun using this sum regardless of order
            */

            HashTable hashTable = new HashTable(3, 2);
            Assert.Equal(hashTable.HashFun("cat"), hashTable.HashFun("cta"));
            Assert.Equal(0, hashTable.HashFun("cat"));
            Assert.Equal(0, hashTable.HashFun("atc"));
            Assert.Equal(0, hashTable.Put("cat"));
            Assert.Equal(2, hashTable.Put("cta"));

            Assert.Equal("cat", hashTable.slots[0]);
            Assert.Equal("cta", hashTable.slots[2]);
            Assert.Null(hashTable.slots[1]);

            Assert.Equal(2, hashTable.HashFun("cata"));
            Assert.Equal(1, hashTable.Put("cata"));
            Assert.Equal("cata", hashTable.slots[1]);

            Assert.Equal(0, hashTable.Find("cat"));
            Assert.Equal(2, hashTable.Find("cta"));
            Assert.Equal(1, hashTable.Find("cata"));
        }

        [Fact]
        public void Collision_IterateMoreThanOnceToPut()
        {
            // this test relies heavily on current implementation

            HashTable hashTable = new HashTable(2, 2);
            Assert.Equal(hashTable.HashFun("cat"), hashTable.HashFun("cta"));
            Assert.Equal(1, hashTable.HashFun("cat"));
            Assert.Equal(1, hashTable.HashFun("atc"));
            Assert.NotEqual(-1, hashTable.Put("cat"));
            Assert.Null(hashTable.slots[0]);
            Assert.NotEqual(-1, hashTable.Put("cta"));

            Assert.Equal("cat", hashTable.slots[1]);
            Assert.Equal("cta", hashTable.slots[0]);

            Assert.Equal(1, hashTable.Find("cat"));
            Assert.Equal(0, hashTable.Find("cta"));
        }
    }
}
