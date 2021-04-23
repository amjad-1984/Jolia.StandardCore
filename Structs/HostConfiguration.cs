namespace Jolia.Core.Structs
{
    public struct HostConfiguration
    {
        public string Domain;
        public string VirtualDirectory;
        public int ServerMinutesSpan;
        public string TimeZoneById;

        public bool HasVirtualDirectory => !string.IsNullOrEmpty(VirtualDirectory);

        public string BaseUrl => Domain + (HasVirtualDirectory ? "/" + VirtualDirectory : "");

        public string GetUrl(string Path) => BaseUrl + "/" + Path;
    }
}
