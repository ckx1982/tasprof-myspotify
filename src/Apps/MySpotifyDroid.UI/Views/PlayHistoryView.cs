using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views.Animations;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Tasprof.Apps.MySpotifyDroid.ViewModels;

namespace Tasprof.Apps.MySpotifyDroid.UI.Views
{
    [Activity(Label = "Play History")]
    public class PlayHistoryView : MvxAppCompatActivity<PlayHistoryViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PlayHistory);
         
            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.mvxRvPlayHistory);
            LinearLayoutManager layoutmanager = (LinearLayoutManager)recyclerView.GetLayoutManager();
            recyclerView.AddOnScrollListener(new MvxRecyclerViewOnScrollListener(layoutmanager, ViewModel));
            //var context = recyclerView.Context;
            //LayoutAnimationController controller;
            //controller = AnimationUtils.LoadLayoutAnimation(context, Resource.Animation.abc_fade_in);
            //recyclerView.LayoutAnimation = controller;
            //recyclerView.ScheduleLayoutAnimation();

        }
    }

    public class MvxRecyclerViewOnScrollListener : RecyclerView.OnScrollListener
    {
        private readonly LinearLayoutManager _layoutManager;
        private readonly PlayHistoryViewModel _viewModel;

        public MvxRecyclerViewOnScrollListener(LinearLayoutManager layoutManager, PlayHistoryViewModel viewModel)
        {
            _layoutManager = layoutManager;
            _viewModel = viewModel;
        }

        public override void OnScrollStateChanged(RecyclerView recyclerView, int newState)
        {
            base.OnScrollStateChanged(recyclerView, newState);
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            base.OnScrolled(recyclerView, dx, dy);
            var visibleItemCount = recyclerView.ChildCount;
            var totalItemCount = recyclerView.GetAdapter().ItemCount;
            var pastVisiblesItems = _layoutManager.FindFirstVisibleItemPosition();

            if ((visibleItemCount + pastVisiblesItems) >= totalItemCount)
            {
                _viewModel.LoadMoreItemsCommand.Execute();
            }
        }

    }

}