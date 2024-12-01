public class ArrayQueue<T> : IQueue<T>
{
    private T[] items;
    private int front;
    private int rear;
    private int capacity;

    public ArrayQueue(int initialCapacity = 100)
    {
        this.capacity = initialCapacity;
        items = new T[capacity];
        front = 0;
        rear = 0;
    }

    public void Enqueue(T item)
    {
        if ((rear + 1) % capacity == front)
        {
            Resize(capacity * 2);
        }

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

    private void Resize(int newCapacity)
    {
        T[] newItems = new T[newCapacity];
        int size = Size();

        for (int i = 0; i < size; i++)
        {
            newItems[i] = items[(front + i) % capacity];
        }

        items = newItems;
        front = 0;
        rear = size;
        capacity = newCapacity;
    }
}
    