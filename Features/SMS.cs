using Jolia.Core.Libraries;
using Jolia.Core.Logic;
using Jolia.Core.Resources;
using Jolia.Core.Results;
using System;
using System.Collections.Generic;
using static Jolia.Core.Enums;

namespace Jolia.Core.Features
{
    public static class SMS
    {
        public static PR SendSMS(string Number, string Message, string CountryCode = null, bool Force = false)
        {
            if (!Force && !Application.Configurations.SMSConfiguration.SMSEnabled)
            {
                return new PR(PS.Success);
            }
            if (CountryCode == null) CountryCode = Application.Configurations.SMSConfiguration.DefaultCountryCode;

            Number = PhoneNumbers.EnsureCountryCode(Number, CountryCode);
            Message = Unicode.ConvertToUnicode(Message);

            switch (Application.Configurations.SMSConfiguration.Provider)
            {
                case SMSProviders.PostToUrl:
                    return SendByPostToUrl(Number, Message);
                case SMSProviders.GetUrl:
                    return SendByGetUrl(Number, Message);
                case SMSProviders.GetUrl2:
                    return SendByGetUrl2(Number, Message);
                default:
                    return new PR(PS.Warning);
            }
        }

        public static PR<Dictionary<string, PR>> SendSMS(List<string> Numbers, string Message, string CountryCode = null, bool Force = false)
        {
            var result = new Dictionary<string, PR>();
            foreach (var Number in Numbers)
            {
                var sendResult = SendSMS(Number, Message, CountryCode, Force);
                result.Add(Number, sendResult);
            }
            return new PR<Dictionary<string, PR>>(result, PS.Success);
        }

        private static PR SendByPostToUrl(string Number, string Message)
        {
            string PostData = $"mobile={Application.Configurations.SMSConfiguration.UserName}&password={Application.Configurations.SMSConfiguration.Password}&numbers={Number}&sender={Application.Configurations.SMSConfiguration.Sender}&msg={Message}&applicationType=59";

            try
            {
                var response = Network.Post(Application.Configurations.SMSConfiguration.ProviderUrl, PostData);
                if (response == "1")
                {
                    return new PR(PS.Success);
                }
                else
                {
                    return new PR(PS.Warning);
                }
            }
            catch (Exception ex)
            {
                return new PR(PS.Error, ex.Message);
            }

        }

        private static PR SendByGetUrl(string Number, string Message)
        {
            string GetData = "?username=" + Application.Configurations.SMSConfiguration.UserName 
                + "&password=" + Application.Configurations.SMSConfiguration.Password 
                + "&mobile=" + Number
                + "&unicode=" + "U" 
                + "&message=" + Message
                + "&sender=" + Application.Configurations.SMSConfiguration.Sender;

            try
            {
                var response = Network.Get(Application.Configurations.SMSConfiguration.ProviderUrl + GetData);
                
                switch (response)
                {
                    case "0":
                        return new PR(PS.Success);
                    case "101":
                        return new PR(PS.Warning, RSMS.Result_BadParameters);
                    case "104":
                        return new PR(PS.Warning, RSMS.Result_BadLogin);
                    case "105":
                        return new PR(PS.Warning, RSMS.Result_NoCard);
                    case "106":
                        return new PR(PS.Warning, RSMS.Result_BadUnicode);
                    case "107":
                        return new PR(PS.Warning, RSMS.Result_SenderNotAllowed);
                    case "108":
                        return new PR(PS.Warning, RSMS.Result_SenderNotFound);
                    default:
                        return new PR(PS.Warning);
                }
            }
            catch (Exception ex)
            {
                return new PR(PS.Error, ex.Message);
            }

        }

        private static PR SendByGetUrl2(string Number, string Message)
        {
            string GetData = "?username=" + Application.Configurations.SMSConfiguration.UserName
                + "&password=" + Application.Configurations.SMSConfiguration.Password
                + "&numbers=" + Number
                + "&unicode=" + "U"
                + "&message=" + Message
                + "&sender=" + Application.Configurations.SMSConfiguration.Sender;

            try
            {
                var response = Network.Get(Application.Configurations.SMSConfiguration.ProviderUrl + GetData);

                switch (response)
                {
                    case "100":
                        return new PR(PS.Success);
                    default:
                        return new PR(PS.Warning);
                }
            }
            catch (Exception ex)
            {
                return new PR(PS.Error, ex.Message);
            }

        }
    }
}