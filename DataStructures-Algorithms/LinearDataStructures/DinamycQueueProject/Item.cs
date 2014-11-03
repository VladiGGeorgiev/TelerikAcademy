namespace DinamycQueueProject
{
    internal class Item<T>
    {
        internal T Element { get; set; }
        internal Item<T> NextElement { get; set; }

        internal Item(T element, Item<T> previous)
        {
            this.Element = element;
            this.NextElement = previous;
        }
    }
}
