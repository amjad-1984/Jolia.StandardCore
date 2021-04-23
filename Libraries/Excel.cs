using System;
using System.IO;
using System.Net;
using System.Web;
using System.Data;
using ClosedXML;
using ClosedXML.Excel;
using System.Linq;
using Jolia.Core.ViewModels.Global;
using Jolia.Core.Extensions;
using Jolia.Core.Results;
using Jolia.Core.Resources;

namespace Jolia.Core.Libraries
{
    public static class Excel
    {
        public static byte[] GetExcel(TableReportViewModel model)
        {
            XLWorkbook wbook = new XLWorkbook();
            var ws = wbook.Worksheets.Add(model.Title.Shorten(25));
            ws.FirstCell().InsertTable(model.Table, false);

            ws.RightToLeft = model.IsRTL;

            // Borders
            var range = $"A1:{Logic.Ascii.NumberToLetter(model.Table.Columns.Count)}{ws.RowsUsed().Count()}";
            ws.Range(range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range(range).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            ws.Range(range).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Range(range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range(range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range(range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

            // AdjustToContents
            foreach (var column in ws.Columns())
            {
                column.AdjustToContents();
            }

            byte[] xlsInBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                wbook.SaveAs(ms);
                xlsInBytes = ms.ToArray();
            }

            return xlsInBytes;
        }

        public static string GetCellString(IXLCell cell)
        {
            if (cell.TryGetValue<string>(out string value))
            {
                return value;
            }
            else
            {
                return cell.CachedValue == null ? "" : cell.CachedValue.ToString();
            }
        }

        public static DataTable ImportToDataTable(string filePath)
        {
            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                IXLWorksheet workSheet = workBook.Worksheet(1);

                DataTable dt = new DataTable();

                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(GetCellString(cell));
                        }
                        firstRow = false;
                    }
                    else
                    {
                        if (row.FirstCellUsed() != null && row.LastCellUsed() != null)
                        {
                            dt.Rows.Add();
                            int i = 0;

                            foreach (IXLCell cell in row.Cells(row.FirstCellUsed().Address.ColumnNumber, row.LastCellUsed().Address.ColumnNumber))
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = GetCellString(cell);
                                i++;
                            }
                        }
                    }
                }

                return dt;
            }
        }
    }
}
