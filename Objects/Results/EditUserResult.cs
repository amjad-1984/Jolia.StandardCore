using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jolia.Core.Results
{
    public class EditUserResult
    {
        public bool PhoneNumberCodeSend { get; set; }
        public bool ToVerifyEmail { get; set; }
        public bool ToVerifyPhoneNumber { get; set; }
        public string EmailVerificationCode { get; set; }
        public string PhoneNumberVerificationCode { get; set; }
    }
}
