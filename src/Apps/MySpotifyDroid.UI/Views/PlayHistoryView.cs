using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Tasprof.Apps.MySpotifyDroid.UI.Adapters;
using Tasprof.Apps.MySpotifyDroid.UI.Listeners;
using Tasprof.Apps.MySpotifyDroid.ViewModels;

namespace Tasprof.Apps.MySpotifyDroid.UI.Views
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