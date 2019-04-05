using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Tasprof.Apps.MySpotify.Droid.UI.Adapters;
using Tasprof.Apps.MySpotify.Droid.UI.Listeners;
using Tasprof.Apps.MySpotify.Core.ViewModels.PlayHistory;

namespace Tasprof.Apps.MySpotify.Droid.UI.Views
{
    [Activity(Label = "Play History")]
    public class PlayHistoryView : MvxAppCompatActivity<PlayHistoryViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PlayHistory);
         
            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.mvxRvPlayHistory);
            recyclerView.Adapter = new AnimatorMvxRecyclerAdapter((IMvxAndroidBindingContext)BindingContext);
            LinearLayoutManager layoutmanager = (LinearLayoutManager)recyclerView.GetLayoutManager();
            recyclerView.AddOnScrollListener(new MvxRecyclerViewOnScrollListener(layoutmanager, ViewModel));
        }
    }


}