using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Tasprof.Apps.MySpotify.Core.ViewModels.PlayHistory;

namespace Tasprof.Apps.MySpotify.Droid.UI.Dialogs
{
    public class PlayHistoryItemDetailsView : MvxAppCompatDialogFragment<PlayHistoryItemDetailsViewModel>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.EnsureBindingContextIsSet();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.PlayHistoryItemDetails, null);
            //var view = inflater.Inflate(Resource.Layout.PlayHistoryItemDetails, null);
            //view.FindViewById<TextView>(Resource.Id.textView1).Text = ViewModel.Text;
            return view;
        }

    }
}
