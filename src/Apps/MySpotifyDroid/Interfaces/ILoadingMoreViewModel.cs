using System;
using System.Threading.Tasks;
using MvvmCross.Commands;

namespace Tasprof.Apps.MySpotifyDroid.Interfaces
{
    public interface ILoadingMoreViewModel
    {
        IMvxAsyncCommand LoadMoreItemsCommand { get; }
    }
}
