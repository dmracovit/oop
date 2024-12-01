using System;

public class ArrayQueue<T> : IQueue<T>
{
    private T[] items;
    private int front;
    private int rear;
    private int capacity;

    public ArrayQueue(int capacity = 10)
    {
        this.capacity = capacity;
        items = new T[capacity];
        front = 0;
        rear = 0;
    }

    public void Enqueue(T item)
    {
        if ((rear + 1) % capacity == front)
            throw new InvalidOperationException("Queue is full");

        items[rear] = item;
        rear = (rear + 1) % capacity;
    }

    public T Dequeue()
    {
        if (front == rear)
            throw new InvalidOperationException("Queue is empty");

        T item = items[front];
        front = (front + 1) % capacity;
        return item;
    }

    public int Size()
    {
        return (rear - front + capacity) % capacity;
    }

    public bool IsEmpty()
    {
        return front == rear;
    }
}