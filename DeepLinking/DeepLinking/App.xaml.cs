using System;
using System.Linq;
using Xamarin.Forms;

namespace AppLinksDemo
{
    public partial class App : Application
    {
		// This must match the intent filter on the Activity for Android! Otherwise Android app links won't work
		// (directly opening the app from a URL).
        internal const string AppLinkUri = "https://csharxtest.azurewebsites.net/items/{0}";
        internal static string[] Items = new string[] { "One", "Two", "Three", "Four", "Five" };

        public App()
        {
            InitializeComponent();

            MainPage = new MasterDetailPage
            {
                Master = new MasterPage(),
                Detail = new NavigationPage(new DetailPage("App Links Demo"))
            };
        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            base.OnAppLinkRequestReceived(uri);

            var query = uri.PathAndQuery.Trim(new[] { '/' });
            var matchedItem = Items.FirstOrDefault(x => query.EndsWith(x, StringComparison.OrdinalIgnoreCase));
            if(matchedItem != null)
            {
                ((MasterDetailPage)MainPage).Detail = new NavigationPage(new DetailPage(matchedItem));
            }
        }
    }
}
