using System;
using System.IO;
using static Jolia.Core.Enums;

namespace Jolia.Core.Libraries
{
    public static class IO
    {
        public static string GetRandomFileName(string FileName, bool KeepFileName = false)
        {
            var guid = Guid.NewGuid().ToString().Replace("-", "");
            string fileName = guid;
            if (KeepFileName)
            {
                fileName += "-" + Path.GetFileNameWithoutExtension(FileName);
            }
            fileName += Path.GetExtension(FileName);
            return fileName;
        }

        public static FileTypes GetFileExtensionFileType(string extension)
        {
            extension = extension.Replace(".", "");

            var FileType = FileTypes.File;

            if (extension == "pdf")
            {
                return FileTypes.PDF;
            }
            else if (extension == "doc" || extension == "docx")
            {
                return FileTypes.DOC;
            }
            else if (extension == "xls" || extension == "xlsx")
            {
                return FileTypes.XLS;
            }
            else if (extension == "ppt" || extension == "pptx")
            {
                return FileTypes.PPT;
            }
            else if (extension == "txt" || extension == "txt")
            {
                return FileTypes.TXT;
            }
            else if (extension == "png" || extension == "bmp" || extension == "jpg" || extension == "jpeg" || extension == "gif")
            {
                return FileTypes.IMG;
            }

            return FileType;
        }
    }
}
