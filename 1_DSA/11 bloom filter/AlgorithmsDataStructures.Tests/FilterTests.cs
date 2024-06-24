using System;
using System.Collections;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class FilterTests
    {
        private string GetTestStrings(int rotatePosition)
        {
            string InitStr = "0123456789";
            int rot = rotatePosition % 10;
            if (rot < 0) rot *= -1;
            return InitStr.Substring(rot, InitStr.Length - rot) + InitStr.Substring(0, rotatePosition % 10);
        }
        [Fact]
        public void GetTestStringTest()
        {
            Assert.Equal("0123456789", GetTestStrings(0));
            Assert.Equal("0123456789", GetTestStrings(10));
            Assert.Equal("1234567890", GetTestStrings(1));
            Assert.Equal("1234567890", GetTestStrings(11));
            Assert.Equal("5678901234", GetTestStrings(5));
            Assert.Equal("7890123456", GetTestStrings(7));
            Assert.Equal("9012345678", GetTestStrings(9));
        }

        [Fact]
        public void FilterTest()
        {
            BloomFilter filter = new BloomFilter(32);

            Assert.False(filter.IsValue(GetTestStrings(2)));
            filter.Add(GetTestStrings(0));
            Assert.True(filter.IsValue(GetTestStrings(0)));
            // Assert.False(filter.IsValue(GetTestStrings(2))); - true. expected error
            Assert.False(filter.IsValue(GetTestStrings(3)));

            filter.Add(GetTestStrings(2));
            filter.Add(GetTestStrings(1));
            Assert.True(filter.IsValue(GetTestStrings(2)));
            Assert.True(filter.IsValue(GetTestStrings(2)));
            Assert.True(filter.IsValue(GetTestStrings(1)));

            for (int i = 3; i <= 10; i++) filter.Add(GetTestStrings(i));
            for (int i = 3; i <= 10; i++) Assert.True(filter.IsValue(GetTestStrings(i)));
        }
    }
}
