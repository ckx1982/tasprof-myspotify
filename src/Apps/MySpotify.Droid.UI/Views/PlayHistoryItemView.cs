
//using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.ViewModels;
using Tasprof.Apps.MySpotify.Core.Enums;
using Tasprof.Apps.MySpotify.Core.Interactions;
using Tasprof.Apps.MySpotify.Core.ViewModels.PlayHistory;

namespace Tasprof.Apps.MySpotify.Droid.UI.Views
{
    [Activity(Label = "PlayHistoryItemView")]
    public class PlayHistoryItemView : MvxAppCompatActivity<PlayHistoryItemViewModel>
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //var set = this.CreateBindingSet<PlayHistoryItemView, PlayHistoryItemViewModel>();
            //set.Bind(this).For(view => view.Interaction).To(viewModel => viewModel.Interaction).OneWay();
            //set.Apply();

            //Intent intent = new Intent(Intent.ActionView);

            //intent.SetData(Android.Net.Uri.Parse(ViewModel.PlayHistoryItem.Track.Uri));

            //intent.PutExtra(Intent.ExtraReferrer,
            //                Android.Net.Uri.Parse("android-app://" + this.PackageName));

            //StartActivity(intent);

            //this.Finish();
        }


        //private IMvxInteraction<ContextMenuItemInteraction> _interaction;
        //public IMvxInteraction<ContextMenuItemInteraction> Interaction
        //{
        //    get => _interaction;
        //    set
        //    {
        //        if (_interaction != null)
        //            _interaction.Requested -= OnInteractionRequested;

        //        _interaction = value;
        //        _interaction.Requested += OnInteractionRequested;
        //    }
        //}

        //private async void OnInteractionRequested(object sender, MvxValueEventArgs<ContextMenuItemInteraction> e)
        //{
        //    var callback = e.Value;
        //    // show dialog
        //    //var status = await ShowDialog(0);
        //    await Task.Delay(1);
        //    callback.Callback(ContextMenuItem.Play);
        //}


    }
}
