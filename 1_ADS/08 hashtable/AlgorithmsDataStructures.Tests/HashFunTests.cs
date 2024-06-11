using System;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class HashFunTests
    {
        [Fact]
        public void Equal_And_Different()
        {
            HashTable hashTable = new HashTable(32, 3);
            Assert.Equal(hashTable.HashFun("cat"), hashTable.HashFun("cat"));
            Assert.NotEqual(hashTable.HashFun("cat"), hashTable.HashFun("dog"));
        }
    }
}
