using System;

namespace Jolia.Core.Attributes
{
    public class WebIconAttribute : Attribute
    {
        private readonly string Name;
        public WebIconAttribute(string Name) => this.Name = Name;
        internal string GetName() => Name;
    }
}
