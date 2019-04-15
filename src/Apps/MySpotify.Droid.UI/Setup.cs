using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Droid.Support.V7.AppCompat;
using Tasprof.Apps.MySpotify.Core;
using Tasprof.Apps.MySpotify.Droid.UI.Bindings;
using Tasprof.Apps.MySpotify.Droid.UI.Widgets;

namespace Tasprof.Apps.MySpotify.Droid.UI
{
    public class Setup : MvxAppCompatSetup<App>
    {
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);
            registry.RegisterFactory(new MvxCustomBindingFactory<TrackQuickInfo>("Track", (x) => new TrackQuickInfoTargetBinding(x)));
        }
    }
}