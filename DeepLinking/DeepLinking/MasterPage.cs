using Xamarin.Forms;

namespace AppLinksDemo
{
    internal class MasterPage : ContentPage
    {
        public MasterPage()
        {
            Title = "Menu";

            var lv = new ListView
            {
                ItemsSource = App.Items
            };

            lv.ItemTapped += (sender, e) =>
            {
                ((MasterDetailPage)Application.Current.MainPage).Detail = new NavigationPage(new DetailPage(e.Item.ToString()));
                ((MasterDetailPage)Application.Current.MainPage).IsPresented = false;
            };

            Content = lv;
        }
    }
}