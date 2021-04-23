using System;
using System.Collections.Generic;

namespace Jolia.Core.Bindings
{
    public class DataTableBinding : Jolia.Core.Transferable
    {
        public List<string[]> Rows { get; set; }
    }
}