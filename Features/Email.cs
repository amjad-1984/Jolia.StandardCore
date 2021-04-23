using Jolia.Core.Extensions;
using Jolia.Core.Resources;
using Jolia.Core.Results;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using static Jolia.Core.Enums;

namespace Jolia.Core.Features
{
    public static class Email
    {
        public static PR SendEmail(string ToAddress, string Title, string Body)
        {
            if (!Application.Configurations.EmailConfiguration.EmailEnabled)
                return new PR(PS.Warning, RFeatures.EmailDisabled);

            if (string.IsNullOrEmpty(ToAddress))
                return new PR(PS.Warning, RFeatures.EmailAddressNotSpecified);

            MailAddress from = new MailAddress(Application.Configurations.EmailConfiguration.SenderEmail, Application.Configurations.EmailConfiguration.SenderName, Encoding.UTF8);
            MailAddress to = new MailAddress(ToAddress);
            MailMessage message = new MailMessage(from, to)
            {
                Subject = Title,
                SubjectEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = true,
                Body = Body.ToHTML(),
                BodyEncoding = Encoding.UTF8
            };

            var client = GetClient();
            if (client == null)
                return new PR<string>(ToAddress, PS.Warning, RFeatures.EmailServiceNotSpecified);

            try
            {
                client.Send(message);
                return new PR(PS.Success);
            }
            catch (Exception e)
            {
                return new PR(PS.Error, e.ToString());
            }
        }

        public static PR<Dictionary<string, PR>> SendEmails(List<string> Emails, string title, string body)
        {
            var result = new Dictionary<string, PR>();
            foreach (var Email in Emails)
            {
                var sendResult = SendEmail(Email, title, body);
                result.Add(Email, sendResult);
            }
            return new PR<Dictionary<string, PR>>(result, PS.Success);
        }

        private static SmtpClient GetClient()
        {
            switch (Application.Configurations.EmailConfiguration.EmailService)
            {
                case EmailServices.Gmail:
                    return new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(Application.Configurations.GoogleConfiguration.Email, Application.Configurations.GoogleConfiguration.Password)
                    };
                case EmailServices.SecureServer:
                    return new SmtpClient("relay-hosting.secureserver.net", 25)
                    {
                        EnableSsl = false
                    };
                case EmailServices.AmazonWebServices:
                    return new System.Net.Mail.SmtpClient("email-smtp.us-east-1.amazonaws.com", 25)
                    {
                        Credentials = new System.Net.NetworkCredential(Application.Configurations.EmailConfiguration.UserName, Application.Configurations.EmailConfiguration.Password),
                        EnableSsl = true
                    };
                case EmailServices.Custom:
                    return new SmtpClient
                    {
                        Host = Application.Configurations.EmailConfiguration.Host,
                        Port = Application.Configurations.EmailConfiguration.Port,
                        EnableSsl = Application.Configurations.EmailConfiguration.EnableSsl,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(Application.Configurations.EmailConfiguration.UserName, Application.Configurations.EmailConfiguration.Password)
                    };
                default:
                    return null;
            }
        }
    }
}


