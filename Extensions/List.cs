using Jolia.Core.Attributes;
using Jolia.Core.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Jolia.Core.Enums;

namespace Jolia.Core.Extensions
{
    public static class ListExtenstions
    {
        public static TimeSpan TotalPeriod(this IEnumerable<TimeSpan> TimeSpans)
        {
            return new TimeSpan(0, 0, (int)TimeSpans.Select(t => t.TotalSeconds).DefaultIfEmpty(0).Sum());
        }

        public static IEnumerable<T> Randomized<T>(this IEnumerable<T> List)
        {
            return List.OrderBy(l => Guid.NewGuid().ToString()).AsEnumerable();
        }

        public static IEnumerable<T> RandomItems<T>(this IEnumerable<T> List, int Count)
        {
            return List.Randomized().Take(Count);
        }

        public static T RandomItem<T>(this IEnumerable<T> List)
        {
            return List.Randomized().RandomItems(1).FirstOrDefault();
        }

        public static DataTable GetReportTable<T>(this List<T> items, ExportMethods Method) where T : class
        {
            var result = new DataTable();
            
            result.Columns.Add(RGlobal.TableIndex, typeof(string));
            foreach (var p in typeof(T).GetProperties().OrderBy(p => p.GetOrder()))
            {
                if ((Method == ExportMethods.PDF && p.GetIsExportedToPDF())
                    || (Method == ExportMethods.Excel && p.GetIsExportedToExcel()))
                {
                    result.Columns.Add(p.ToDisplayName(), typeof(string));
                }
            }

            var index = -1;
            foreach (var item in items)
            {
                index++;
                var values = new List<string>
                {
                    (index + 1).ToString()
                };
                foreach (var p in typeof(T).GetProperties().OrderBy(p => p.GetOrder()))
                {
                    if ((Method == ExportMethods.PDF && p.GetIsExportedToPDF())
                    || (Method == ExportMethods.Excel && p.GetIsExportedToExcel()))
                    {
                        var v = p.GetValue(item, null);
                        if (v == null) v = "";
                        values.Add(v.ToString());
                    }
                }

                result.Rows.Add(values.ToArray());
            }

            return result;
        }
    }
}
