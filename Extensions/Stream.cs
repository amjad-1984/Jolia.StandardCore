using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Jolia.Core.Extensions
{
    public static class StreamExtensions
    {
        public static HttpResponseMessage GetAsHttpResponseMessage(this Stream stream, string MediaType)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue(MediaType);
            return result;
        }
    }
}