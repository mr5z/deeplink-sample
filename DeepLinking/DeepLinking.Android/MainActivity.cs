using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android.AppLinks;

namespace AppLinksDemo.Droid
{
	// See: https://developer.android.com/training/app-links/index.html
	// Use to verify asset links file: https://digitalassetlinks.googleapis.com/v1/statements:list?source.web.site=https://csharxtest.azurewebsites.net&relation=delegate_permission/common.handle_all_urls
	// Try to start app via URL: adb shell am start -a android.intent.action.VIEW -c android.intent.category.BROWSABLE -d "http://csharxtest.azurewebsites.net/items/One"


	[Activity(Label = "AppLinksDemo.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

    // The following two are for deep links from the website.
	// ALL (!!) must be reachable via HTTPS to make direct app links work.
	[IntentFilter(new[] { Intent.ActionView },
		Categories = new[]
		{
			Intent.CategoryDefault,
			Intent.CategoryBrowsable
		},
		DataScheme = "http", DataPathPrefix = "/items/", DataHost = "csharxtest.azurewebsites.net", AutoVerify = true)]
	[IntentFilter(new[] { Intent.ActionView },
		Categories = new[]
		{
			Intent.CategoryDefault,
			Intent.CategoryBrowsable
    },
    DataScheme = "https", DataPathPrefix = "/items/", DataHost = "csharxtest.azurewebsites.net", AutoVerify = true)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            AndroidAppLinks.Init(this);

            LoadApplication(new App());
        }
    }
}
