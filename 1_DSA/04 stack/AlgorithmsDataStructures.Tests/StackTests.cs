using System;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class StackTests
    {
        [Fact]
        public void TestAll()
        {
            Stack<int> stack = new Stack<int>();

            Assert.Equal(0, stack.Size());

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.Equal(3, stack.Size());

            Assert.Equal(30, stack.Peek());
            Assert.Equal(30, stack.Pop());
            Assert.Equal(20, stack.Pop());
            Assert.Equal(10, stack.Pop());

            Assert.Equal(0, stack.Size());
            Assert.Equal(default, stack.Peek());
            Assert.Equal(default, stack.Pop());
            Assert.Equal(default, stack.Peek());
            Assert.Equal(default, stack.Pop());
        }
    }
}
