using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Jolia.Core.Enums;
using Jolia.Core.Extensions;

namespace Jolia.Core.Results
{
    public class PR : Transferable
    {
        public PR(PS result, string message = null)
        {
            this.Result = result;
            this.Message = message;
            if (string.IsNullOrEmpty(this.Message))
            {
                this.Message = this.Result.ToDisplayName();
            }
        }

        public PR<T> AddData<T>(T data)
        {
            return new PR<T>(data, this.Result, this.Message);
        }

        public PS Result { get; set; }
        public string Message { get; set; }

        public bool IsSucceeded => Result == PS.Success;

        public ColorClasses ColorClass
        {
            get
            {
                switch (Result)
                {
                    case PS.Success:
                        return ColorClasses.Success;
                    case PS.Warning:
                        return ColorClasses.Warning;
                    case PS.Error:
                        return ColorClasses.Danger;
                    case PS.NotFound:
                        return ColorClasses.Warning;
                    case PS.Forbidden:
                        return ColorClasses.Danger;
                    case PS.BadRequest:
                        return ColorClasses.Warning;
                    default:
                        return ColorClasses.Info;
                }
            }
        }

        public WebResult WebResult(HttpStatusCode StatusCode, bool IsUserAuthenticated) => new WebResult(StatusCode, IsUserAuthenticated, Message);
    }

    public class PR<T> : PR
    {
        public PR(T Object, PS result, string message = null) : base(result, message)
        {
            this.Object = Object;
        }

        public T Object { get; set; }

        public WebResult WebResult(HttpStatusCode StatusCode, object ObjectDTO, bool IsUserAuthenticated) => 
            new WebResult(ObjectDTO, StatusCode, IsUserAuthenticated, Message);
    }
}