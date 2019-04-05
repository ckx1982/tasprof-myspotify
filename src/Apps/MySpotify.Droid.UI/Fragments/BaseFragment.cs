using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.ViewModels;

namespace Tasprof.Apps.MySpotify.Droid.UI.Fragments
{

    public abstract class BaseFragment : MvxFragment
    {
        //private Toolbar _toolbar;
        //private MvxActionBarDrawerToggle _drawerToggle;

        //public MvxAppCompatActivity ParentActivity
        //{
        //    get
        //    {
        //        return (MvxAppCompatActivity)Activity;
        //    }
        //}

        protected BaseFragment()
        {
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(FragmentId, null);

            //_toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
            //if (_toolbar != null)
            //{
            //    ParentActivity.SetSupportActionBar(_toolbar);
            //    ParentActivity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            //    _drawerToggle = new MvxActionBarDrawerToggle(
            //        Activity,                               // host Activity
            //        (ParentActivity as INavigationActivity).DrawerLayout,  // DrawerLayout object
            //        _toolbar,                               // nav drawer icon to replace 'Up' caret
            //        Resource.String.drawer_open,            // "open drawer" description
            //        Resource.String.drawer_close            // "close drawer" description
            //    );
            //    _drawerToggle.DrawerOpened += (object sender, ActionBarDrawerEventArgs e) => (Activity as MainActivity)?.HideSoftKeyboard();
            //    (ParentActivity as INavigationActivity).DrawerLayout.AddDrawerListener(_drawerToggle);
            //}

            return view;
        }

        protected abstract int FragmentId { get; }

    }


        public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}