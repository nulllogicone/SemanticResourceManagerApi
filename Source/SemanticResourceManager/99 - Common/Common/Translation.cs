using System;
using System.Globalization;

namespace SemanticResourceManager.Common
{
    public class Translation
    {
        public Translation()
        {
            
        }

        public Translation(Guid guid, string resourceKey, string value, CultureInfo cultureInfo)
        {
            CultureInfo = cultureInfo;
            Guid = guid;
            ResourceKey = resourceKey;
            Value = value;
        }

        public CultureInfo CultureInfo { get; set; }
        public Guid Guid { get; set; }
        public string ResourceKey { get; set; }
        public string Value { get; set; }
    }
}