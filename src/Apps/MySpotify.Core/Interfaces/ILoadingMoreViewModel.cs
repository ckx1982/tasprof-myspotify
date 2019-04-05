using System;
using System.Threading.Tasks;
using MvvmCross.Commands;

namespace Tasprof.Apps.MySpotify.Core.Interfaces
{
    public interface ILoadingMoreViewModel
    {
        IMvxAsyncCommand LoadMoreItemsCommand { get; }
    }
}
