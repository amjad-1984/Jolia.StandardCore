namespace Jolia.Core.Bindings
{
    public class ObjectWithCountBinding<T> : Transferable
    {
        public T Object { get; set; }
        public long Count { get; set; }
    }
}
