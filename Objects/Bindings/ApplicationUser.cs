using Jolia.Core.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jolia.Core.Bindings
{
    public class ApplicationUserBinding
    {
        public string Id { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(RAccount))]
        public string UserName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(RAccount))]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(RAccount))]
        public string PhoneNumber { get; set; }

        [Display(Name = "Name", ResourceType = typeof(RAccount))]
        public virtual string Name { get; set; }

        [Display(Name = "AvatarUrl", ResourceType = typeof(RAccount))]
        public string AvatarUrl { get; set; }
    }
}