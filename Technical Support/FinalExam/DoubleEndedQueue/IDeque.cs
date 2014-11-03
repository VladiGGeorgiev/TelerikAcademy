namespace DoubleEndedQueue
{
    public interface IDeque<T>
    {
        int Count { get; }

        void PushFirst(T element);

        void PushLast(T element);

        T PopFirst();

        T PopLast();

        T PeekFirst();

        T PeekLast();

        void Clear();

        bool Contains(T element);
    }
}
