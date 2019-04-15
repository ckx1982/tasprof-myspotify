using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using FFImageLoading.Cross;

namespace Tasprof.Apps.MySpotify.Droid.UI.Widgets
{
    public class TrackQuickInfo : LinearLayout
    {
        private MvxCachedImageView _image;
        private TextView _artist;
        private TextView _track;

        public TrackQuickInfo(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Init(attrs);
        }

        public string ImageUrl { get => _image.ImagePath; set => _image.ImagePath = value; }
        public string Artist { get => _artist.Text; set => _artist.Text = value; }
        public string Title { get => _track.Text; set => _track.Text = value; }

        private void Init(IAttributeSet attrs)
        {
            var inflater = LayoutInflater.From(Context);
            var layout = inflater.Inflate(Resource.Layout.TrackQuickInfo, this);

            _image = layout.FindViewById<MvxCachedImageView>(Resource.Id.imageViewCover);
            _artist = layout.FindViewById<TextView>(Resource.Id.textViewArtist);
            _track = layout.FindViewById<TextView>(Resource.Id.textViewTrack);
        }
    }
}
