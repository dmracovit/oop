using Xunit;

public class QueueTests
{
    [Fact]
    public void TestEnqueueDequeue()
    {
        // Arrange
        var queue = new LinkedListQueue<int>();

        // Act
        queue.Enqueue(1);
        var result = queue.Dequeue();

        // Assert
        Assert.Equal(1, result); 
    }

    [Fact]
    public void TestEnqueueMultipleItems()
    {
        // Arrange
        var queue = new LinkedListQueue<int>();

        // Act
        queue.Enqueue(1);
        queue.Enqueue(2);
        var first = queue.Dequeue();
        var second = queue.Dequeue();

        // Assert
        Assert.Equal(1, first);
        Assert.Equal(2, second);
    }
}
