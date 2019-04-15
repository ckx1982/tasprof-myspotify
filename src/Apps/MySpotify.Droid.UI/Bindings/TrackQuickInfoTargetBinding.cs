using MvvmCross.Binding;
using MvvmCross.Platforms.Android.Binding.Target;
using System;
using Tasprof.Apps.MySpotify.Core.Models;
using Tasprof.Apps.MySpotify.Droid.UI.Widgets;

namespace Tasprof.Apps.MySpotify.Droid.UI.Bindings
{
    public class TrackQuickInfoTargetBinding : MvxAndroidTargetBinding
    {
        public TrackQuickInfoTargetBinding(TrackQuickInfo trackQuickInfo) : base(trackQuickInfo)
        {

        }

        private TrackQuickInfo TrackQuickInfo => (TrackQuickInfo)this.Target;

        public override Type TargetType => typeof(Track);

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        protected override void SetValueImpl(object target, object value)
        {
            this.TrackQuickInfo.Title = ((Track)value).Title;
            this.TrackQuickInfo.Artist = ((Track)value).MainArtist.Name;
            this.TrackQuickInfo.ImageUrl = ((Track)value).MainArtist.MainImage.Url;

        }
    }
}