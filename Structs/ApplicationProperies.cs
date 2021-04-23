using static Jolia.Core.Enums;

namespace Jolia.Core.Structs
{
    public struct ApplicationProperies
    {
        public string CodeName;
        public string Title;
        public string Description;
        public bool DevelopmentMode;
        public bool LocalMode;

        public string DatabaseConnectionString;

        public string EmptyImagePath;
        public string MaleAvatarImagePath;
        public string FemaleAvatarImagePath;

        public string DefaultPDFFontFilePath;
        public LayoutDirections DefaultLayoutDirection;
    }
}
