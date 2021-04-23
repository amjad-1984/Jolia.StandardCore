using Jolia.Core.Structs;
using System;
using System.Collections.Generic;
using static Jolia.Core.Enums;

namespace Jolia.Core
{
    public static class Application
    {
        public static ApplicationProperies Properies { get; set; }
        public static HostConfiguration Host { get; set; }

        public static class Configurations
        {
            public static GoogleConfiguration GoogleConfiguration { get; set; }
            public static SaveImageConfiguration AvatarConfiguration { get; set; }
            public static EmailConfiguration EmailConfiguration;
            public static SMSConfiguration SMSConfiguration;
            public static FCMConfiguration FCMConfiguration;
            public static AWSConfiguration AWSConfiguration;
            public static SecurityConfiguration SecurityConfiguration;
            public static WebConfiguration WebConfiguration;

            public static void ConfigureWeb(List<WebFeatures> Features, int AutoLogoutMinutes, bool ConfirmLogout)
            {
                WebConfiguration.Features = Features;
                WebConfiguration.AutoLogoutMinutes = AutoLogoutMinutes;
                WebConfiguration.ConfirmLogout = ConfirmLogout;
            }

            public static void ConfigureSecurity(bool NameIsUnique, bool PhoneNumberRequired, bool ConfirmingPhoneNumber, bool EmailRequired, bool ConfirmingEmail, bool LoginRequiresConfirmation)
            {
                SecurityConfiguration.ConfirmingPhoneNumber = ConfirmingPhoneNumber;
                SecurityConfiguration.ConfirmingEmail = ConfirmingEmail;
                SecurityConfiguration.PhoneNumberRequired = PhoneNumberRequired;
                SecurityConfiguration.EmailRequired = EmailRequired;
                SecurityConfiguration.NameIsUnique = NameIsUnique;
                SecurityConfiguration.LoginRequiresConfirmation = LoginRequiresConfirmation;
            }

            public static void ConfigureEmail(bool EmailEnabled, EmailServices EmailService, string SenderName, string SenderEmail, string UserName, string Password, string Host, int Port, bool EnableSsl)
            {
                EmailConfiguration.EmailEnabled = EmailEnabled;
                EmailConfiguration.SenderName = SenderName;
                EmailConfiguration.SenderEmail = SenderEmail;
                EmailConfiguration.EmailService = EmailService;
                EmailConfiguration.UserName = UserName;
                EmailConfiguration.Password = Password;
                EmailConfiguration.Host = Host;
                EmailConfiguration.EnableSsl = EnableSsl;
                EmailConfiguration.Port = Port;
            }

            public static void ConfigureSMS(bool SMSEnabled, string Sender, string UserName, string Password, string DefaultCountryCode, SMSProviders Provider, string ProviderUrl)
            {
                SMSConfiguration.SMSEnabled = SMSEnabled;
                SMSConfiguration.Sender = Sender;
                SMSConfiguration.UserName = UserName;
                SMSConfiguration.Password = Password;
                SMSConfiguration.DefaultCountryCode = DefaultCountryCode;
                SMSConfiguration.Provider = Provider;
                SMSConfiguration.ProviderUrl = ProviderUrl; // TODO: http://www.mobily.ws/api/msgSend.php
            }

            public static void ConfigureFCM(bool FCMEnabled, string FCMSenderKey, string FCMSenderId)
            {
                FCMConfiguration.FCMEnabled = FCMEnabled;
                FCMConfiguration.FCMSenderKey = FCMSenderKey;
                FCMConfiguration.FCMSenderId = FCMSenderId;
            }

            public static void ConfigAWS(string AccessKey, string SecretKey, string Bucket, Dictionary<string, string> Directories)
            {
                AWSConfiguration.AccessKey = AccessKey;
                AWSConfiguration.SecretKey = SecretKey;
                AWSConfiguration.Bucket = Bucket;
                AWSConfiguration.Directories = Directories;
            }
        }

        public static DateTime Now => 
            TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(Host.TimeZoneById));
    }
}
