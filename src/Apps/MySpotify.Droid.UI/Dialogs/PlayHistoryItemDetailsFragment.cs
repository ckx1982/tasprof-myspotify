using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using Tasprof.Apps.MySpotify.Core.ViewModels.PlayHistory;

namespace Tasprof.Apps.MySpotify.Droid.UI.Dialogs
{
    public class PlayHistoryItemDetailsFragment : MvxDialogFragment<PlayHistoryItemViewModel>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

             base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.PlayHistoryItemDetailsDialog, container, false);
        }
    }
}
