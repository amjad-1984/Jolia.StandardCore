using System;

namespace Jolia.Core.Attributes
{
    public class OrderAttribute : Attribute
    {
        private readonly int Number;
        internal int GetNumber() => Number;

        public OrderAttribute(int Number = int.MaxValue) {
            this.Number = Number;
        }
    }
}
