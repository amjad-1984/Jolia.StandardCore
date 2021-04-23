using System;
using System.Collections.Generic;
using System.Linq;

namespace Jolia.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToHTML(this string Text)
        {
            if (Text == null) 
                return "";

            return Text.Replace("\n", "<br>");
        }

        public static string Shorten(this string Text, int Length)
        {
            if (Text == null) 
                return "";

            return Text.Length < Length ? Text 
                : Text.Substring(0, Length) + " ..";
        }

        public static string ToFixedZeros(this string Text, int Length)
        {
            if (Text == null)
                return "";

            var result = "";
            for (int i = 0; i < Length - Text.Length - 1; i++)
            {
                result += "0";
            }
            result += Text;

            return result;
        }

        public static List<string> ToLinesList(this string Text)
        {
            if (Text == null)
                return new List<string>();

            return new List<string>(Text.Split(new string[] { "\r\n" },
                                       StringSplitOptions.RemoveEmptyEntries));
        }

        public static List<string> ToSeparatedCommaList(string Text)
        {
            if (Text == null)
                return new List<string>();

            return Text.Split(',')
                .Where(s => s.Length > 0)
                .ToList();
        }
    }
    
}
