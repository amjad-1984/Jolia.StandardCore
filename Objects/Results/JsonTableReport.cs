using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jolia.Core.Results
{
    public class JsonTableReport
    {
        public string Title { get; set; }
        public JArray Headers { get; set; }
        public JArray Rows { get; set; }

        public DataTable GetDataTable()
        {
            var result = new DataTable();
            foreach (string header in Headers)
            {
                result.Columns.Add(header);
            }

            foreach (JArray row in Rows)
            {
                result.Rows.Add(row.Select(r => r.ToString()).ToArray());
            }

            return result;
        }
    }
}
