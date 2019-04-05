using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Tasprof.Apps.MySpotify.Core.ViewModels.Main;

namespace Tasprof.Apps.MySpotify.Core
{
    public class App: MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<MainViewModel>();
        }
    }
}
