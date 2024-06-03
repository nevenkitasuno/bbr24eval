using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class NativeDictionaryTests
    {
        [Fact]
        public void TestPutGet()
        {
            var nativeDictionary = new NativeDictionary<int>(10);

            Assert.Equal(default, nativeDictionary.Get("a"));
            nativeDictionary.Put("a", 1);
            Assert.Equal(1, nativeDictionary.Get("a"));

            nativeDictionary.Put("b", 2);
            Assert.Equal(2, nativeDictionary.Get("b"));

            nativeDictionary.Put("c", 3);
            Assert.Equal(3, nativeDictionary.Get("c"));
        }

        [Fact]
        public void TestIsKey()
        {
            var nativeDictionary = new NativeDictionary<int>(10);

            Assert.False(nativeDictionary.IsKey("a"));
            nativeDictionary.Put("a", 1);
            Assert.True(nativeDictionary.IsKey("a"));

            nativeDictionary.Put("b", 2);
            Assert.True(nativeDictionary.IsKey("b"));

            nativeDictionary.Put("c", 3);
            Assert.True(nativeDictionary.IsKey("c"));
        }

        [Fact]
        public void TestNonExistentKey()
        {
            var nativeDictionary = new NativeDictionary<int>(10);

            Assert.Equal(default, nativeDictionary.Get("a"));
            Assert.Equal(default, nativeDictionary.Get("b"));
            Assert.Equal(default, nativeDictionary.Get("c"));
        }

        [Fact]
        public void Rewrite()
        {
            var nativeDictionary = new NativeDictionary<int>(10);

            Assert.False(nativeDictionary.IsKey("a"));
            nativeDictionary.Put("a", 1);
            Assert.Equal(1, nativeDictionary.Get("a"));

            nativeDictionary.Put("a", 2);
            Assert.Equal(2, nativeDictionary.Get("a"));
        }

        [Fact]
        public void Collision_IterateMoreThanOnceToPut()
        {
            // this test relies heavily on current implementation

            NativeDictionary<int> nativeDictionary = new NativeDictionary<int>(3);
            Assert.Equal(nativeDictionary.HashFun("cat"), nativeDictionary.HashFun("cta"));
            Assert.Equal(0, nativeDictionary.HashFun("cat"));
            Assert.Equal(0, nativeDictionary.HashFun("atc"));
            nativeDictionary.Put("cat", 1);
            Assert.Null(nativeDictionary.slots[1]);
            nativeDictionary.Put("cta", 2);

            Assert.Equal("cat", nativeDictionary.slots[0]);
            Assert.Equal("cta", nativeDictionary.slots[1]);

            Assert.True(nativeDictionary.IsKey("cat"));
            Assert.True(nativeDictionary.IsKey("cta"));
        }
    }
}