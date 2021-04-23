using System;

namespace Jolia.Core.Attributes
{
    public class ExportAttribute : Attribute
    {
        private readonly bool PDF;
        internal bool GetPDF() => PDF;

        private readonly bool Excel;
        internal bool GetExcel() => Excel;

        public ExportAttribute(bool PDF = false, bool Excel = false) {
            this.PDF = PDF;
            this.Excel = Excel;
        }
    }
}
