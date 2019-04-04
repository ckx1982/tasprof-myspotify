using Android.Support.V7.Widget;
using Tasprof.Apps.MySpotifyDroid.Interfaces;

namespace Tasprof.Apps.MySpotifyDroid.UI.Listeners
{
    public class MvxRecyclerViewOnScrollListener : RecyclerView.OnScrollListener
    {
        private readonly LinearLayoutManager _layoutManager;
        private readonly ILoadingMoreViewModel _viewModel;

        public MvxRecyclerViewOnScrollListener(LinearLayoutManager layoutManager, ILoadingMoreViewModel viewModel)
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
