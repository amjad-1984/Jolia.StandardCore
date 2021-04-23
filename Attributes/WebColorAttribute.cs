using System;

namespace Jolia.Core.Attributes
{
    public class WebColorAttribute : Attribute
    {
        private readonly string Name;
        private readonly bool IsLight;

        public WebColorAttribute(string Name, bool IsLight = false)
        {
            this.Name = Name;
            this.IsLight = IsLight;
        }

        internal string GetName() => Name;
        internal bool GetIsLight() => IsLight;
    }
}
