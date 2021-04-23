using Jolia.Core.Results;
using static Jolia.Core.Enums;

namespace Jolia.Core.Logic
{
    public static class PhoneNumbers
    {
        public static string EnsureCountryCode(string number, string CountryCode)
        { 
            number = number.Trim();
            number = number.Replace("+", "00");

            if (!number.StartsWith("00") && number.StartsWith("0"))
                number = number.Substring(1, number.Length - 1);

            if (number.StartsWith(CountryCode.Replace("0",""))) number = "00" + number;

            if (!number.StartsWith(CountryCode))
                number = CountryCode + number;

            return number;
        }

        public static PR<string> EnsurePhoneNumber(string PhoneNumber, string CountryCode)
        {
            if (!string.IsNullOrEmpty(PhoneNumber))
            {
                PhoneNumber = PhoneNumber.Trim();

                if (!long.TryParse(PhoneNumber, out _))
                {
                    return new PR<string>(PhoneNumber, PS.Warning, "يجب إدخال أرقام فقط في رقم الجوال");
                }
                else
                {
                    PhoneNumber = EnsureCountryCode(PhoneNumber, CountryCode);
                    if (PhoneNumber.Length != 14)
                    {
                        return new PR<string>(PhoneNumber, PS.Warning, "يرجى التحقق من صحة الرقم");
                    }
                }
            }

            return new PR<string>(PhoneNumber, PS.Success);
        }
    }
}
