using System;
using System.Linq;
using Xunit;

namespace DataStructuresAlgorithms.Tests
{
    public class CacheTests
    {
        [Fact]
        public void TestPutGet()
        {
            var cache = new NativeCache<int>(10);

            Assert.Equal(default, cache.Get("a"));
            Assert.Equal(0, cache.hits.ToList().Sum());
            cache.Put("a", 1);
            Assert.Equal(0, cache.hits.ToList().Sum());
            Assert.Equal(1, cache.Get("a"));
            Assert.Equal(1, cache.hits.ToList().Sum());
            Assert.Equal(2, cache.hits.ToList().Distinct().Count());

            cache.Put("b", 2);
            Assert.Equal(2, cache.Get("b"));

            cache.Put("c", 3);
            Assert.Equal(3, cache.Get("c"));
            Assert.Equal(3, cache.hits.ToList().Sum());
            Assert.Equal(2, cache.hits.ToList().Distinct().Count());

            cache.Get("c");
            Assert.Equal(3, cache.hits.ToList().Distinct().Count());
            cache.Get("b");
            cache.Get("b");
            Assert.Equal(4, cache.hits.ToList().Distinct().Count());
            Assert.Equal(6, cache.hits.ToList().Sum());
            Assert.Equal(3, cache.hits.ToList().Max());

            // rewrite
            cache.Put("b", 2);
            Assert.Equal(2, cache.Get("b"));
            Assert.Equal(3, cache.hits.ToList().Distinct().Count());
            Assert.Equal(2, cache.hits.ToList().Max());
        }

        [Fact]
        public void Overflow_ShouldReplaceLeastUsed()
        {
            var cache = new NativeCache<int>(2);
            cache.Put("a", 1);
            cache.Put("b", 2);
            cache.Get("a");
            cache.Put("c", 3);
            Assert.Equal(default, cache.Get("b"));
            Assert.Equal(1, cache.Get("a"));
            Assert.Equal(3, cache.Get("c"));

            cache = new NativeCache<int>(2);
            cache.Put("a", 1);
            cache.Put("b", 2);
            cache.Get("a");
            cache.Get("b");
            cache.Put("c", 3);
            Assert.True(cache.IsKey("a") || cache.IsKey("b"));
            Assert.False(cache.IsKey("a") && cache.IsKey("b"));
            Assert.Equal(3, cache.Get("c"));
        }
    }
}
