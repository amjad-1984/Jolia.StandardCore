using System;
using System.Collections.Generic;

namespace Jolia.Core.Logic
{
    public static class Html
    {
        public static string PutTextInParagraph(string value, bool IsRTL)
        {
            var direction = IsRTL ? "rtl" : "ltr";
            var alignment = IsRTL ? "right" : "left";
            return "<p dir=\"" + direction + "\" style=\"text-align: " + alignment + ";\">" + value + "</p>";
        }

        public static string ListToJavaArray(List<string> list, bool WithQutations)
        {
            string result = "[";

            foreach (var item in list)
            {
                result += WithQutations ? "'" + item + "'," : item + ",";
            }

            if (result.EndsWith(","))
            {
                result = result.TrimEnd(',');
            }

            result += "]";
            return result;
        }

        public static string RemoveAllAttributesInNode(string html, string node)
        {
            try
            {
                var htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(html);
                foreach (var eachNode in htmlDocument.DocumentNode.SelectNodes("//" + node))
                    eachNode.Attributes.RemoveAll();
                html = htmlDocument.DocumentNode.OuterHtml;
            }
            catch (Exception)
            {

            }

            return html;
        }
    }
}
