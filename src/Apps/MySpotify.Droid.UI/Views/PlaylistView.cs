using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Tasprof.Apps.MySpotify.Core.ViewModels.Playlists;

namespace Tasprof.Apps.MySpotify.Droid.UI.Views
{
    [Activity(Label = "Playlist")]
    public class PlaylistView: MvxAppCompatActivity<PlaylistViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Playlist);
        }
    }
}
