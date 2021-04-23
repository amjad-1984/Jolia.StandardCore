using Jolia.Core.Extensions;
using System.Text;

namespace Jolia.Core.Logic
{
    public static class Unicode
    {
        public static string ConvertToUnicode(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            string result = string.Empty;

            for (int i = 0; i < value.Length; i++)
            {
                result += ToChar(System.Convert.ToChar(value.Substring(i, 1)));
            }

            return result;
        }

        private static string ToChar(char ch)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] bytes = encoding.GetBytes(System.Convert.ToString(ch));

            return ToHexaDecimal(bytes[1] + bytes[0].ToString("X"));
        }

        private static string ToHexaDecimal(string messg)
        {
            string temp = string.Empty;

            switch (messg.Length)
            {
                case 1: temp = "000" + messg; break;
                case 2: temp = "00" + messg; break;
                case 3: temp = "0" + messg; break;
                case 4: temp = messg; break;
            }

            return temp;
        }
    }
}
