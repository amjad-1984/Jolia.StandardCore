using Jolia.Core.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Jolia.Core.Features
{
    public static class FCM
    {
        public static PR NotifyUser(string body, string deviceId, dynamic extraInfo)
        {
            if (!Application.Configurations.FCMConfiguration.FCMEnabled)
                return new PR(Enums.PS.Success);

            try
            {
                
                List<string> DeviceIdList = new List<string>
                {
                    deviceId
                };

                var data = new
                {
                    registration_ids = DeviceIdList,
                    notification = new
                    {
                        body = body,
                        sound = "Enabled",
                    },
                    data = extraInfo,
                    priority = "high"
                };

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                byte[] byteArray = Encoding.UTF8.GetBytes(json);


                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", Application.Configurations.FCMConfiguration.FCMSenderKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", Application.Configurations.FCMConfiguration.FCMSenderId));
                tRequest.ContentLength = byteArray.Length;
                tRequest.UseDefaultCredentials = true;
                tRequest.PreAuthenticate = true;
                tRequest.Credentials = CredentialCache.DefaultCredentials;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                string sResponseFromServer = tReader.ReadToEnd();
                                return new PR(Enums.PS.Success, sResponseFromServer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new PR(Enums.PS.Error, ex.Message);
            }
        }
    }
}
