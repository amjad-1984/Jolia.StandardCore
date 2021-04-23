using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Attributes
{
    public class ImageRangeAttribute : RangeAttribute, IClientValidatable
    {
        public ImageRangeAttribute() :
            base
            (0,
             Convert.ToInt32(WebConfigurationManager.AppSettings["ImageUploadMax"]))
        { }


        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessageString, this.Maximum);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(this.ErrorMessage),
                ValidationType = "range",
            };
            rule.ValidationParameters.Add("min", this.Minimum);
            rule.ValidationParameters.Add("max", this.Maximum);
            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            if (String.IsNullOrEmpty(value.ToString()))
                return null;

            var val = Convert.ToInt32(value);
            if (val >= Convert.ToInt32(this.Minimum) && val <= Convert.ToInt32(this.Maximum))
                return null;

            return new ValidationResult(
                FormatErrorMessage(this.ErrorMessage)
            );
        }
    }
}
