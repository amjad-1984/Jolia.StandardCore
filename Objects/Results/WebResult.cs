using System.Net;

namespace Jolia.Core.Results
{
    public class WebResult : Transferable
    {
        public WebResult(HttpStatusCode StatusCode, bool IsUserAuthenticated, string Message = "")
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.IsUserAuthenticated = IsUserAuthenticated;
        }

        public WebResult(object ObjectDTO, HttpStatusCode StatusCode, bool IsUserAuthenticated, string Message = "")
            : this(StatusCode, IsUserAuthenticated, Message)
        {
            this.Object = ObjectDTO;
        }

        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object Object { get; set; }
        public bool IsUserAuthenticated { get; set; }

        public int Status => (int)StatusCode;
    }
}
