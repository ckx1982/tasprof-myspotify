using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace Tasprof.Apps.MySpotifyDroid.UI.Adapters
{
    public class AnimatorRecyclerAdapter : MvxRecyclerAdapter
    {
        public AnimatorRecyclerAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext)
        {

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return base.OnCreateViewHolder(parent, viewType);
           
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);

            holder.ItemView.Click += (s, e) =>
            {
                SetAnimation(holder.ItemView);
            };
        }

        private void SetAnimation(View itemView)
        {
            ScaleAnimation anim = new ScaleAnimation(0.0f, 1.0f, 0.0f, 1.0f, Dimension.RelativeToSelf, 0.5f, Dimension.RelativeToSelf, 0.5f);
            anim.Duration = 2000;
            itemView.StartAnimation(anim);
        }
    }
}