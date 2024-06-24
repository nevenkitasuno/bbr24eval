using System;
using Xunit;

namespace DataStructuresAlgorithms {
    public class ExercisesTests {
        [Fact]
        public void TestIsPalindrome() {
            Assert.True(Exercises.IsPalindrome("racecar"));
            Assert.True(Exercises.IsPalindrome("madam"));
            Assert.True(Exercises.IsPalindrome("12321"));
            Assert.False(Exercises.IsPalindrome("hello"));
            Assert.False(Exercises.IsPalindrome("12345"));
        }
    }
}