using static Jolia.Core.Enums;

namespace Jolia.Core.Structs
{
    public struct SMSConfiguration
    {
        public bool SMSEnabled;
        public string Sender;
        public string UserName;
        public string Password;
        public string DefaultCountryCode;
        public SMSProviders Provider;
        public string ProviderUrl;
    }
}
