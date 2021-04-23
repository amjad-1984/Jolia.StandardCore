using Jolia.Core.Attributes;
using Jolia.Core.Bindings;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jolia.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDisplayName(this System.Enum value)
        {
            var attributes = (DisplayAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false);
            return attributes.Length > 0 ? attributes[0].GetName() : value.ToString();
        }

        public static string GetWebColor(this System.Enum value)
        {
            var attributes = (WebColorAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(WebColorAttribute), false);
            return attributes.Length > 0 ? attributes[0].GetName() : value.ToString();
        }

        public static bool GetIsWebColorLight(this System.Enum value)
        {
            var attributes = (WebColorAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(WebColorAttribute), false);
            return attributes.Length > 0 ? attributes[0].GetIsLight() : false;
        }

        public static string GetWebIcon(this System.Enum value)
        {
            var attributes = (WebIconAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(WebIconAttribute), false);
            return attributes.Length > 0 ? attributes[0].GetName() : value.ToString();
        }

        public static string GetPluralName(this System.Enum value)
        {
            var attributes = (PluralNameAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(PluralNameAttribute), false);
            return attributes.Length > 0 ? attributes[0].GetName() : value.ToString();
        }

        public static EnumBinding<T> Bind<T>(this T value)
        {
            var e = value as Enum;

            return new EnumBinding<T>
            {
                Number = Convert.ToInt32(e),
                Name = e.ToString(),
                Text = e.ToDisplayName(),
                Color = e.GetWebColor(),
                Icon = e.GetWebIcon(),
                Value = value
            };
        }
    }
}