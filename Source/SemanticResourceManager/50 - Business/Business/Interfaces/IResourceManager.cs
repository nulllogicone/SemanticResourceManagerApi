using System.Globalization;

namespace SemanticResourceManager.Business.Interfaces
{
    public interface IResourceManager
    {
        string GetResource(string key, CultureInfo cultureInfo);

        void SaveResource(string key, string value, CultureInfo cultureInfo);
    }
}