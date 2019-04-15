using Android.App;
using Android.Runtime;
using MvvmCross.Droid.Support.V7.AppCompat;
using System;
using Tasprof.Apps.MySpotify.Core;

namespace Tasprof.Apps.MySpotify.Droid.UI
{
    [Application]
    public class MainApplication : MvxAppCompatApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }
    }
}