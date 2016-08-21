using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Common
{
    public static class DependencyFactory
    {
        static DependencyFactory()
        {
            var container = new UnityContainer();
            var section = (UnityConfigurationSection) ConfigurationManager.GetSection("unity");
            section?.Configure(container);
            Container = container;
        }

        public static IUnityContainer Container { get; }

        public static T Resolve<T>() => Container.IsRegistered(typeof(T)) ? Container.Resolve<T>() : default(T);
    }
}