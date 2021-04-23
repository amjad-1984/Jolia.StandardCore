namespace Jolia.Core.Bindings
{
    public class EnumBinding<T> : Transferable
    {
        public T Value { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
    }
}