using System.Collections.Generic;
using static Jolia.Core.Enums;

namespace Jolia.Core.Structs
{
    public struct WebConfiguration
    {
        public int AutoLogoutMinutes;
        public bool ConfirmLogout;
        public List<WebFeatures> Features;

        public bool HasFeature(WebFeatures Feature)
        {
            return Features.Contains(Feature);
        }
    }
}