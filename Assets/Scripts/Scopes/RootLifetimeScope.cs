using GlobalServices;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SceneLoaderService>(Lifetime.Singleton);
        }
    }
}