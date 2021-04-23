using System;

namespace Jolia.Core.Attributes
{
    public class PluralNameAttribute : Attribute
    {
        private readonly string Name;
        public PluralNameAttribute(string Name) => this.Name = Name;
        internal string GetName() => Name;
    }
}