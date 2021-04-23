using System.Data;
using static Jolia.Core.Enums;

namespace Jolia.Core.ViewModels.Global
{
    public class TableReportViewModel
    {
        public TableReportViewModel()
        {
            FontPath = Application.Properies.DefaultPDFFontFilePath;
            IsRTL = Application.Properies.DefaultLayoutDirection == LayoutDirections.RTL;
        }

        public string Title { get; set; }
        public string SubTitle { get; set; }

        public DataTable Table { get; set; }

        public string FontPath { get; set; }
        public float[] Widths { get; set; }
        public bool IsRTL { get; set; }
        public bool IsLandscape { get; set; }

        public LayoutMarginsPatterns LayoutMarginsPattern { get; set; }

        public float GetLeftRightMargin()
        {
            if (LayoutMarginsPattern == LayoutMarginsPatterns.Wide)
            {
                return 10;
            }
            else if (LayoutMarginsPattern == LayoutMarginsPatterns.Narrow)
            {
                return 5;
            }
            else
            {
                return 15;
            }
        }

        public float GetTopBottomMargin()
        {
            if (LayoutMarginsPattern == LayoutMarginsPatterns.Wide)
            {
                return 15;
            }
            else if (LayoutMarginsPattern == LayoutMarginsPatterns.Narrow)
            {
                return 5;
            }
            else
            {
                return 20;
            }
        }
    }
}