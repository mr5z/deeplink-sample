using System;
using Xamarin.Forms;

namespace AppLinksDemo
{
    internal class DetailPage : ContentPage
    {
        public DetailPage(string title)
        {
            Title = title;
            Content = new Label
            { 
                Text = title,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var browserItem = new ToolbarItem
            {
                Text = "Browse"
            };
            browserItem.Clicked += (sender, e) => Device.OpenUri(new Uri("https://csharxtest.azurewebsites.net"));
            ToolbarItems.Add(browserItem);
        }

        AppLinkEntry _appLink;

		protected override void OnAppearing()
		{
			base.OnAppearing();
			// See details at: https://developer.xamarin.com/guides/xamarin-forms/platform-features/deep-linking/
            _appLink = new AppLinkEntry
			{
                // It's not really clear why this must be a URI. At least on iOS it is just used as a unique identifier
                // and the URI is turned into a string again. Maybe for Android?
                AppLinkUri = new Uri(string.Format(App.AppLinkUri, Title).Replace(" ", "_")),
				Thumbnail = ImageSource.FromFile("Xamagon.png"),
                Description = string.Format($"This is item {Title}"),
                Title = string.Format($"Item {Title}"),
                // Mark this as the current activity. This will for instance allow handoff operations on iOS.
                IsLinkActive = true
			};

			Application.Current.AppLinks.RegisterLink(_appLink);
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            _appLink.IsLinkActive = false;
            Application.Current.AppLinks.RegisterLink(_appLink);
		}

	}
}