using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Tasprof.Apps.MySpotifyDroid.UI.Views
{
    [Activity(Label = "MySpotify", MainLauncher =true, NoHistory =true, Icon = "@mipmap/ic_launcher_round" )]
    public class SplashScreenActivity : MvxSplashScreenAppCompatActivity
    {
        public SplashScreenActivity() : base(Resource.Layout.SplashScreen)
        {

        }
        
    }
}