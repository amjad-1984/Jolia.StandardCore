using Jolia.Core.Extensions;
using System;
using System.Data;

namespace Jolia.Core.Bindings
{
    public class ImportBinding : Transferable
    {
        public DataTable GetTemplateTable()
        {
            var result = new DataTable();

            foreach (var p in GetType().GetProperties())
            {
                result.Columns.Add(p.ToDisplayName(), typeof(string));
            }

            return result;
        }
    }
}
