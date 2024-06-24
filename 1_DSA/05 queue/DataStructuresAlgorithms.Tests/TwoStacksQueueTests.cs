using System.Collections.Generic;
using Xunit;

namespace DataStructuresAlgorithms.Tests
{
    public class TwoStacksQueueTests
    {
        [Fact]
        public void TestTwoStacksQueueEnqueueAndDequeue()
        {
            TwoStacksQueue<int> queue = new TwoStacksQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(3, queue.Size());

            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());

            Assert.Equal(0, queue.Size());
        }
    }
}