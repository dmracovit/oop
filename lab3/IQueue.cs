public interface IQueue<T>
{
    void Enqueue(T item); // add item
    T Dequeue();          // remove and retur
    int Size();             
}
