public class LinkedListQueue<T> : IQueue<T>
{
    private LinkedList<T> items;

    public LinkedListQueue()
    {
        items = new LinkedList<T>();
    }

    public void Enqueue(T item)
    {
        items.AddLast(item);
    }

    public T Dequeue()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Queue is empty");

        T item = items.First.Value;
        items.RemoveFirst();
        return item;
    }

    public int Size()
    {
        return items.Count;
    }
}
