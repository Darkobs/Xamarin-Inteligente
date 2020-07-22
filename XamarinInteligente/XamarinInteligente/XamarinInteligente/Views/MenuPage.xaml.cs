using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinInteligente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void btnNextClient_Clicked(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).Detail = new NavigationPage(new NextClientPage());
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }

        private void btnSearchClient_Clicked(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).Detail = new NavigationPage(new ClientSearchPage());
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }

        private void btnNewOrder_Clicked(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).Detail = new NavigationPage(new OrderPage());
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.TabbedPage tabbedPage = new Xamarin.Forms.TabbedPage();
            tabbedPage.Children.Add(new LoginPage());
            tabbedPage.Children.Add(new SignUpPage());
            App.Current.MainPage = tabbedPage;
        }

        private void btnAbout_Clicked(object sender, EventArgs e)
        {
            if (App.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.Detail = new NavigationPage(new AboutPage());
                masterDetailPage.IsPresented = false;
            }
        }
    }
}