using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jolia.Core.Results
{
    [DataContract]
    public class RecaptchaResult
    {
        [DataMember(Name = "success")]
        public bool Success;

        [DataMember(Name = "error-codes")]
        public List<string> ErrorCodes;

        public RecaptchaResult Bind(object db, string UserId)
        {
            return this;
        }
    }
}
