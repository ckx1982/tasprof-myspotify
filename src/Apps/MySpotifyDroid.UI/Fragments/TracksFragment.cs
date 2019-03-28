using Tasprof.Apps.MySpotifyDroid.ViewModels;

namespace Tasprof.Apps.MySpotifyDroid.UI.Fragments
{
    public class TracksFragment : BaseFragment<TracksViewModel>
    {
        protected override int FragmentId => Resource.Layout.Tracks;
    }
}