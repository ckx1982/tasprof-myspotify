using MvvmCross.ViewModels;

namespace Tasprof.Apps.MySpotify.Core.ViewModels
{
    public abstract class BaseViewModelParam<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
    {
        public abstract void Prepare(TParameter parameter);
    }
}
