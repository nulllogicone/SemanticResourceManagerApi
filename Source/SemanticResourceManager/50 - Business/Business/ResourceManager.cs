using System;
using System.Globalization;
using SemanticResourceManager.Business.Interfaces;
using SemanticResourceManager.Common;
using SemanticResourceManager.DataAccess;

namespace SemanticResourceManager.Business
{
    public class ResourceManager : IResourceManager
    {
        private const int DefaultMaximumResourceLookupDepth = 5;

        private readonly int _maximumResourceLookupDepth;

        public ResourceManager(int maximumResourceLookupDepth = DefaultMaximumResourceLookupDepth)
        {
            _maximumResourceLookupDepth = maximumResourceLookupDepth;
        }

        private readonly IRepository<Translation> _context = DependencyFactory.Resolve<IRepository<Translation>>();

        public string GetResource(string resourceKey, CultureInfo cultureInfo)
        {
            var lookupDepth = 1;
            while (lookupDepth < _maximumResourceLookupDepth)
            {
                if (cultureInfo == null)
                {
                    return string.Empty;
                }

                var translation = GetTranslation(resourceKey, cultureInfo);
                if (translation != null)
                {
                    return translation.Value;
                }
                cultureInfo = cultureInfo.Parent;
                lookupDepth++;
            }
            return string.Empty;
        }

        public void SaveResource(string resourceKey, string value, CultureInfo cultureInfo)
        {
            var translation = GetTranslation(resourceKey, cultureInfo) ?? new Translation(Guid.NewGuid(), resourceKey, value, cultureInfo);
            translation.Value = value;
            _context.SaveChanges();
        }

        public string GetResource(string resourceKey) => GetResource(resourceKey, CultureInfo.CurrentCulture);

        private Translation GetTranslation(string key, CultureInfo cultureInfo) => _context
            .Retrieve(translation => translation.ResourceKey == key && Equals(translation.CultureInfo, cultureInfo));
    }
}