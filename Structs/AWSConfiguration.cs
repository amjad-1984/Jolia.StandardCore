using System.Collections.Generic;

namespace Jolia.Core.Structs
{
    public struct AWSConfiguration
    {
        public string AccessKey;
        public string SecretKey;
        public string Bucket;
        public Dictionary<string, string> Directories;
    }
}
