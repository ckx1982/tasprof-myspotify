using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Tasprof.Apps.MySpotifyDroid.ViewModels;

namespace Tasprof.Apps.MySpotifyDroid.UI.Views
{
    [Activity(Label = "My Playlists")]
    public class PlaylistsView : MvxAppCompatActivity<PlaylistsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Playlists);

        }
    }

   
}
