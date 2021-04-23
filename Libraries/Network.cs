using System;
using System.IO;
using System.Net;
using System.Web;

namespace Jolia.Core.Libraries
{
    public static class Network
    {
        public static string Get(string URL)
        {
            try
            {
                string response = "";
                HttpWebRequest httpwc = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse httpwr = (HttpWebResponse)httpwc.GetResponse();
                StreamReader streader = new StreamReader(httpwr.GetResponseStream());
                response = streader.ReadLine();
                streader.Close();
                
                return response;
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public static string Post(string URL, string PostData)
        {
            HttpWebRequest req = (HttpWebRequest)
                WebRequest.Create(URL);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            
            req.ContentLength = PostData.Length;

            StreamWriter stOut = new
            StreamWriter(req.GetRequestStream(),
            System.Text.Encoding.ASCII);
            stOut.Write(PostData);
            stOut.Close();

            string strResponse;
            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            strResponse = stIn.ReadToEnd();
            stIn.Close();

            return strResponse;
        }
    }
}
