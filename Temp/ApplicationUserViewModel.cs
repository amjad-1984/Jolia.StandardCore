using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Jolia.Core.ViewModels.Accounts
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "الاسم")]
        public string Name { get; set; }

        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }

        [Display(Name = "رقم الجوال")]
        public string PhoneNumber { get; set; }

        [Display(Name = "صورة الملف الشخصي")]
        public string Avatar { get; set; }

        public HttpPostedFileBase AvatarFile { get; set; }

        public string AvatarUrl => string.IsNullOrEmpty(Avatar) ?
                    Constants.Images.DefaultAvatarUrl
                    : Avatar;

        public override string ToString()
        {
            return Name;
        }
    }
}
