using Jolia.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Jolia.Core.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static bool IsUnique(this PropertyInfo info)
        {
            var att = (UniqueAttribute)info.GetCustomAttributes(typeof(UniqueAttribute)).FirstOrDefault();
            return att != null;
        }

        public static bool IsLogged(this PropertyInfo info)
        {
            var att = (LoggedAttribute)info.GetCustomAttributes(typeof(LoggedAttribute)).FirstOrDefault();
            return att != null;
        }

        public static bool IsReference(this PropertyInfo info)
        {
            var att = (ReferenceAttribute)info.GetCustomAttributes(typeof(ReferenceAttribute)).FirstOrDefault();
            return att != null;
        }

        public static bool IsLinked(this PropertyInfo info)
        {
            var att = (LinkedAttribute)info.GetCustomAttributes(typeof(LinkedAttribute)).FirstOrDefault();
            return att != null;
        }

        public static int GetOrder(this PropertyInfo info)
        {
            var att = (OrderAttribute)info.GetCustomAttributes(typeof(OrderAttribute)).FirstOrDefault();
            if (att == null) return int.MaxValue;
            return att.GetNumber();
        }

        public static bool GetIsExportedToPDF(this PropertyInfo info)
        {
            var att = (ExportAttribute)info.GetCustomAttributes(typeof(ExportAttribute)).FirstOrDefault();
            if (att == null) return false;
            return att.GetPDF();
        }

        public static bool GetIsExportedToExcel(this PropertyInfo info)
        {
            var att = (ExportAttribute)info.GetCustomAttributes(typeof(ExportAttribute)).FirstOrDefault();
            if (att == null) return false;
            return att.GetExcel();
        }

        public static string ToDisplayName(this PropertyInfo info)
        {
            var att = (DisplayAttribute)info.GetCustomAttributes(typeof(DisplayAttribute)).FirstOrDefault();
            if (att == null) return info.Name;
            return att.GetName();
        }
    }
}