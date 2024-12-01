// using System;
// using Xunit;

// namespace Task1.Test
// {
//     public class QueueTests
//     {
//         [Fact]
//         public void TestEnqueueDequeue()
//         {
//             // Arrange
//             IQueue<Car> queue = new LinkedListQueue<Car>();

//             // Create mock car data with all required parameters
//             Car car1 = new Car(1, "ELECTRIC", "PEOPLE", false, 14);
//             Car car2 = new Car(2, "GAS", "PEOPLE", false, 20);

//             // Act
//             queue.Enqueue(car1);
//             queue.Enqueue(car2);

//             // Assert
//             Assert.Equal(2, queue.Size()); // Queue should contain two cars

//             // Dequeue and check if the first car is dequeued
//             Car dequeuedCar = queue.Dequeue();
//             Assert.Equal(car1.Id, dequeuedCar.Id); // Check if the correct car is dequeued

//             // After dequeue, queue should have one car
//             Assert.Equal(1, queue.Size());
//         }

//         [Fact]
//         public void TestQueueSizeAfterEnqueueDequeue()
//         {
//             // Arrange
//             IQueue<Car> queue = new ArrayQueue<Car>(5);

//             // Create mock car data with all required parameters
//             Car car1 = new Car(1, "ELECTRIC", "PEOPLE", false, 14);
//             Car car2 = new Car(2, "GAS", "PEOPLE", false, 20);

//             // Act
//             queue.Enqueue(car1);
//             queue.Enqueue(car2);

//             // Assert size after enqueuing
//             Assert.Equal(2, queue.Size());

//             // Dequeue one car
//             queue.Dequeue();

//             // Assert size after dequeuing one car
//             Assert.Equal(1, queue.Size());
//         }

//         [Fact]
//         public void TestQueueEmpty()
//         {
//             // Arrange
//             IQueue<Car> queue = new LinkedListQueue<Car>();

//             // Assert that the queue is empty initially
//             Assert.True(queue.IsEmpty(), "Queue should be empty initially.");

//             // Act - Try to dequeue from an empty queue and expect an exception
//             var exception = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
//             Assert.Equal("Queue is empty", exception.Message);
//         }

//         [Fact]
//         public void TestEnqueueDequeueWithMultipleTypes()
//         {
//             // Arrange
//             IQueue<int> intQueue = new ArrayQueue<int>(5);
//             IQueue<string> stringQueue = new ArrayQueue<string>(5);

//             // Enqueue different types of data
//             intQueue.Enqueue(1);
//             intQueue.Enqueue(2);
//             stringQueue.Enqueue("Hello");
//             stringQueue.Enqueue("World");

//             // Assert for int queue
//             Assert.Equal(2, intQueue.Size());
//             Assert.Equal(1, intQueue.Dequeue());
//             Assert.Equal(1, intQueue.Size());

//             // Assert for string queue
//             Assert.Equal(2, stringQueue.Size());
//             Assert.Equal("Hello", stringQueue.Dequeue());
//             Assert.Equal(1, stringQueue.Size());
//         }
//     }
// }
