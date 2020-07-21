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

        }

        private void btnSearchClient_Clicked(object sender, EventArgs e)
        {

        }

        private void btnNewOrder_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {

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