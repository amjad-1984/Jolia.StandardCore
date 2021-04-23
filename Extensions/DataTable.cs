using Jolia.Core.Bindings;
using System.Collections.Generic;
using System.Data;

namespace Jolia.Core.Extensions
{
    public static class DataTableExtensions
    {
        public static DataTableBinding Bind(this DataTable table)
        {
            var result = new DataTableBinding { Rows = new List<string[]>() };
            foreach (DataRow row in table.Rows)
            {
                string[] r = new string[table.Columns.Count];
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    r.SetValue(row[i].ToString(), i);
                }

                result.Rows.Add(r);
            }

            return result;
        }
    }
}