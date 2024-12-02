public class Semaphore
{
    private int _count;

    public Semaphore(int initialCount)
    {
        _count = initialCount;
    }

    public void WaitOne()
    {
        while (_count == 0)
        {
        }
        _count--;
    }

    public void Release()
    {
        _count++;
    }
}
