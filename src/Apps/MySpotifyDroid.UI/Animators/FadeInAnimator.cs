using Android.Animation;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views.Animations;

namespace Tasprof.Apps.MySpotifyDroid.UI.Animators
{
    public class FadeInAnimator : SimpleItemAnimator
    {
        Context context;
        public override bool IsRunning => false;


        public FadeInAnimator(Context context)
        {
            this.context = context;
        }

        public override bool AnimateAdd(RecyclerView.ViewHolder holder)
        {
            Animator set = AnimatorInflater.LoadAnimator(context, Resource.Animation.playhistoryitem_fade_in);
            set.SetInterpolator(new BounceInterpolator());
            set.SetTarget(holder.ItemView);
            set.Start();
            return true;
        }

        public override bool AnimateChange(RecyclerView.ViewHolder oldHolder, RecyclerView.ViewHolder newHolder, int fromLeft, int fromTop, int toLeft, int toTop)
        {
            return false;
        }

        public override bool AnimateMove(RecyclerView.ViewHolder holder, int fromX, int fromY, int toX, int toY)
        {
            return false;
        }

        public override bool AnimateRemove(RecyclerView.ViewHolder holder)
        {
            return false;
        }

        public override void EndAnimation(RecyclerView.ViewHolder item)
        {
           
        }

        public override void EndAnimations()
        {
           
        }

        public override void RunPendingAnimations()
        {
           
        }
    }
}