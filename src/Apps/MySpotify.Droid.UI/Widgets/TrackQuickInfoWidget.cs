
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using FFImageLoading.Cross;
using MvvmCross.Binding.Attributes;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;

namespace Tasprof.Apps.MySpotify.Droid.UI.Widgets
{
    public class TrackQuickInfoWidget : LinearLayout
    {
        private MvxCachedImageView _image;
        private TextView _artist;
        private TextView _track;
        private readonly IMvxAndroidBindingContext _bindingContext;

        public TrackQuickInfoWidget(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Init(attrs);
        }

        public string ImageUrl { get => _image.ImagePath; set => _image.ImagePath = value; }
        public string Artist { get => _artist.Text; set => _artist.Text = value; }
        public string Track { get => _track.Text; set => _track.Text = value; }

        private void Init(IAttributeSet attrs)
        {
            var inflater = LayoutInflater.From(Context);
            var layout = inflater.Inflate(Resource.Layout.TrackQuickInfoWidget, this);
 
            _image = layout.FindViewById<MvxCachedImageView>(Resource.Id.imageViewCover);
            _artist = layout.FindViewById<TextView>(Resource.Id.textViewArtist);
            _track = layout.FindViewById<TextView>(Resource.Id.textViewTrack);
        }
    }
}
