using Jolia.Core.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jolia.Core.Attributes
{
    public class GlobalRequiredAttribute : RequiredAttribute
    {
        public GlobalRequiredAttribute()
        {
            ErrorMessage = RGlobal.This_is_required;
            AllowEmptyStrings = false;
        }
    }
}
