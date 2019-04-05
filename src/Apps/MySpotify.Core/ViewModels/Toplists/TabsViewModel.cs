namespace Tasprof.Apps.MySpotify.Core.ViewModels.Toplists
{
    public class TabsViewModel: BaseViewModel
    {
        private string _top= "Top";
        public string Top
        {
            get { return _top; }
            set { SetProperty(ref _top, value); }
        }
    }
}
