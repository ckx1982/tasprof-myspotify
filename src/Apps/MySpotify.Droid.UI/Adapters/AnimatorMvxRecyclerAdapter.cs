using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace Tasprof.Apps.MySpotify.Droid.UI.Adapters
{
    public class AnimatorMvxRecyclerAdapter : MvxRecyclerAdapter
    {
        private int lastPosition = -1;

        public AnimatorMvxRecyclerAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext)
        {

        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);

            if (position > lastPosition)
            {
                lastPosition = position;
                SetAnimation(holder.ItemView);
            }
        }

        private void SetAnimation(View itemView)
        {
            Animation anim = AnimationUtils.LoadAnimation(itemView.Context, Resource.Animation.item_animation_fall_down);
            itemView.StartAnimation(anim);
        }
    }
}