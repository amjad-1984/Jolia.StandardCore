using System.Linq;

namespace Jolia.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static void CopyTo(this object Source, object Target, bool OnlyLinked = false)
        {
            var parentProperties = Source.GetType().GetProperties()
                .Where(p => OnlyLinked == false || p.IsLinked());

            var childProperties = Target.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType && childProperty.CanWrite)
                    {
                        childProperty.SetValue(Target, parentProperty.GetValue(Source));
                        break;
                    }
                }
            }
        }
    }
}