using System.Collections.Generic;
using Xunit;

namespace DataStructuresAlgorithms.Tests
{
    public class PowerSetTests
    {
        [Fact]
        public void TestPowerSetBasics()
        {
            var powerSet = new PowerSet<string>();

            Assert.Equal(0, powerSet.Size());
            powerSet.Put("1");
            Assert.Equal(1, powerSet.Size());

            powerSet.Put("2");
            Assert.Equal(2, powerSet.Size());

            powerSet.Put("3");
            Assert.Equal(3, powerSet.Size());

            powerSet.Put("2");
            Assert.Equal(3, powerSet.Size());

            Assert.False(powerSet.Remove("4"));
            Assert.Equal(3, powerSet.Size());

            Assert.True(powerSet.Remove("2"));
            Assert.Equal(2, powerSet.Size());

            Assert.False(powerSet.Remove("2"));
            Assert.Equal(2, powerSet.Size());

            Assert.True(powerSet.Get("3"));
            Assert.False(powerSet.Get("2"));

            Assert.True(powerSet.Remove("3"));
            Assert.True(powerSet.Remove("1"));
            Assert.Equal(0, powerSet.Size());
            Assert.False(powerSet.Remove("1"));
        }

        [Fact]
        public void TestPowerSetIntersection()
        {
            var set1 = new PowerSet<string>();
            var set2 = new PowerSet<string>();

            set1.Put("1");
            set1.Put("2");
            set1.Put("3");

            set2.Put("2");
            set2.Put("3");
            set2.Put("4");

            var intersection = set1.Intersection(set2);
            Assert.Equal(2, intersection.Size());
            Assert.True(intersection.Get("2"));
            Assert.True(intersection.Get("3"));
            Assert.False(intersection.Get("1"));
            Assert.False(intersection.Get("4"));
        }

        [Fact]
        public void TestPowerSetIntersection_EmptyResult()
        {
            var set1 = new PowerSet<string>();
            var set2 = new PowerSet<string>();

            set1.Put("1");
            set1.Put("2");

            set2.Put("3");
            set2.Put("4");

            var intersection = set1.Intersection(set2);
            Assert.Equal(0, intersection.Size());
            Assert.False(intersection.Get("2"));
            Assert.False(intersection.Get("3"));
            Assert.False(intersection.Get("1"));
            Assert.False(intersection.Get("4"));
        }

        [Fact]
        public void TestPowerSetDifference()
        {
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();

            set1.Put(1);
            set1.Put(2);
            set1.Put(3);

            set2.Put(2);
            set2.Put(3);
            set2.Put(4);

            var difference = set1.Difference(set2);
            Assert.Equal(2, difference.Size());
            Assert.True(difference.Get(1));
            Assert.False(difference.Get(2));
            Assert.False(difference.Get(3));
            Assert.True(difference.Get(4));
        }

        [Fact]
        public void TestPowerSetDifference_EmptyResult()
        {
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();

            set1.Put(2);
            set1.Put(3);

            set2.Put(2);
            set2.Put(3);

            var difference = set1.Difference(set2);
            Assert.Equal(0, difference.Size());
            Assert.False(difference.Get(2));
            Assert.False(difference.Get(3));
        }

        [Fact]
        public void TestPowerSetUnion()
        {
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();

            set1.Put(1);
            set1.Put(2);

            set2.Put(3);
            set2.Put(4);

            var union = set1.Union(set2);
            Assert.Equal(4, union.Size());
            Assert.True(union.Get(1));
            Assert.True(union.Get(2));
            Assert.True(union.Get(3));
            Assert.True(union.Get(4));
        }

        [Fact]
        public void TestPowerSetUnion_OneSetIsEmpty()
        {
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();

            set1.Put(1);
            set1.Put(2);

            var union = set1.Union(set2);
            Assert.Equal(2, union.Size());
            Assert.True(union.Get(1));
            Assert.True(union.Get(2));
            Assert.False(union.Get(3));
        }

        [Fact]
        public void TestPowerSetIsSubset()
        {
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();

            set1.Put(1);
            set1.Put(2);
            set1.Put(3);

            set2.Put(2);
            set2.Put(3);

            Assert.True(set1.IsSubset(set2));
            Assert.False(set2.IsSubset(set1));
        }

        [Fact]
        public void TestPowerSetIsSubset_OneIsEmpty()
        {
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();

            set1.Put(1);
            set1.Put(2);
            set1.Put(3);

            Assert.True(set1.IsSubset(set2));
            Assert.False(set2.IsSubset(set1));
        }

        [Fact]
        public void TestPowerSetIsSubset_NotASubset()
        {
            var set1 = new PowerSet<int>();
            var set2 = new PowerSet<int>();

            set1.Put(1);
            set1.Put(2);
            set1.Put(3);

            set2.Put(2);
            set2.Put(3);
            set2.Put(4);

            Assert.False(set1.IsSubset(set2));
            Assert.False(set2.IsSubset(set1));
        }

        [Fact]
        public void Test20k()
        {
            var set1 = new PowerSet<string>();
            var set2 = new PowerSet<string>();
            int i;

            for (i = 0; i < 15000; i++) set1.Put(i.ToString());
            for (i = 5000; i < 20000; i++) set2.Put(i.ToString());

            var intersection = set1.Intersection(set2);
            Assert.Equal(10000, intersection.Size());

            var union = set1.Union(set2);
            Assert.Equal(20000, union.Size());

            var difference = set1.Difference(set2);
            Assert.Equal(5000, difference.Size());
        }
    }
}