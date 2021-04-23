using Jolia.Core.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Jolia.Core.Extensions
{
    public static class ClassExtensions
    {
        public static PR<ICollection<ValidationResult>> Validate<T>(this T model) where T : class
        {
            var result = new List<ValidationResult>();
            var IsValid = Validator.TryValidateObject(model, new ValidationContext(model), result, true);

            return new PR<ICollection<ValidationResult>>(result, IsValid ? Enums.PS.Success : Enums.PS.Warning);
        }

        public static string GetPropertyDisplayName<TModel>(this TModel model, Expression<Func<TModel, object>> expression) where TModel : class
        {
            string _ReturnValue = string.Empty;

            Type type = typeof(TModel);

            string propertyName = null;
            string[] properties = null;
            IEnumerable<string> propertyList;

            switch (expression.Body.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    var ue = expression.Body as UnaryExpression;
                    propertyList = (ue != null ? ue.Operand : null).ToString().Split(".".ToCharArray()).Skip(1);
                    break;
                default:
                    propertyList = expression.Body.ToString().Split(".".ToCharArray()).Skip(1);
                    break;
            }

            propertyName = propertyList.Last();
            properties = propertyList.Take(propertyList.Count() - 1).ToArray();

            Expression expr = null;
            foreach (string property in properties)
            {
                PropertyInfo propertyInfo = type.GetProperty(property);
                expr = Expression.Property(expr, type.GetProperty(property));
                type = propertyInfo.PropertyType;
            }

            DisplayAttribute attr;
            attr = (DisplayAttribute)type.GetProperty(propertyName).GetCustomAttributes(typeof(DisplayAttribute), true).SingleOrDefault();

            //if (attr == null)
            //{
            //    MetadataTypeAttribute metadataType = (MetadataTypeAttribute)type.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault();
            //    if (metadataType != null)
            //    {
            //        var property = metadataType.MetadataClassType.GetProperty(propertyName);
            //        if (property != null)
            //        {
            //            attr = (DisplayAttribute)property.GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
            //        }
            //    }
            //}

            if (attr != null && attr.ResourceType != null)
                _ReturnValue = attr.ResourceType.GetProperty(attr.Name).GetValue(attr).ToString();
            else if (attr != null)
                _ReturnValue = attr.Name;

            return _ReturnValue;
        }
    }
}