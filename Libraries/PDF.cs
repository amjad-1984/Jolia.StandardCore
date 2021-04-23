using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Jolia.Core.ViewModels.Global;

namespace Jolia.Core.Libraries
{
    public static class PDF
    {
        public static byte[] GetPdf(TableReportViewModel model)
        {
            byte[] xlsInBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                var Size = model.IsLandscape ? PageSize.A4.Rotate() : PageSize.A4;
                Document document = new Document(Size, 
                    model.GetLeftRightMargin(), model.GetLeftRightMargin(), 
                    model.GetTopBottomMargin(), model.GetTopBottomMargin());

                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                BaseFont bf = BaseFont.CreateFont(model.FontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                Font f = new Font(bf, 12);
                Font boldf = new Font(bf, 14, Font.BOLD);
                Font f18 = new Font(bf, 18);
                Font f16 = new Font(bf, 16);
                Font f14 = new Font(bf, 14);


                // Title
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                var headerCell = new PdfPCell(new Phrase(model.Title, f18))
                {
                    Border = 0,
                    Padding = 10,
                    MinimumHeight = 25,
                    VerticalAlignment = Element.ALIGN_CENTER,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };

                headerTable.AddCell(headerCell);

                //var subHeaderTable = new PdfPCell(new Phrase(model.SubTitle, f14))
                //{
                //    Border = 0,
                //    Padding = 10,
                //    MinimumHeight = 50,
                //    VerticalAlignment = Element.ALIGN_CENTER,
                //    HorizontalAlignment = Element.ALIGN_CENTER
                //};

                //headerTable.AddCell(subHeaderTable);

                document.Add(headerTable);

                // Table
                PdfPTable table = new PdfPTable(model.Table.Columns.Count)
                {
                    RunDirection = PdfWriter.RUN_DIRECTION_RTL
                };

                foreach (System.Data.DataColumn column in model.Table.Columns)
                {
                    var cell = new PdfPCell(new Phrase(column.ColumnName, f14))
                    {
                        //BackgroundColor = new BaseColor(249, 249, 249),
                        MinimumHeight = 30,
                        Padding = 5,
                        BorderColor = new BaseColor(221, 221, 221),
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_CENTER,
                        BorderWidth = 1
                    };
                    table.AddCell(cell);
                }

                var rowIndex = -1;
                foreach (System.Data.DataRow row in model.Table.Rows)
                {
                    rowIndex++;
                    for (int i = 0; i < model.Table.Columns.Count; i++)
                    {
                        var cell = new PdfPCell(new Phrase(row[i].ToString(), f))
                        {
                            MinimumHeight = 25,
                            Padding = 5,
                            BorderColor = new BaseColor(221, 221, 221),
                            BorderWidth = 1,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_CENTER
                        };

                        if (rowIndex % 2 == 0)
                        {
                            cell.BackgroundColor = new BaseColor(249, 249, 249);
                        }

                        table.AddCell(cell);
                    }
                }

                if (model.Widths != null)
                {
                    table.SetWidths(model.Widths);
                }

                document.Add(table);


                document.Close();
                writer.Close();

                xlsInBytes = ms.ToArray();
            }

            return xlsInBytes;
        }
    }
}
