using static Jolia.Core.Enums;

namespace Jolia.Core.Structs
{
    public struct EmailConfiguration
    {
        public bool EmailEnabled;
        public EmailServices EmailService;
        public string SenderName;
        public string SenderEmail;
        public string UserName;
        public string Password;

        public string Host;
        public int Port;
        public bool EnableSsl;
    }
}
