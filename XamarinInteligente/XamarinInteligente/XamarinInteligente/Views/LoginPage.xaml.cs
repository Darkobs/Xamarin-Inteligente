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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        //private void BtnSignUp_Clicked(object sender, EventArgs e)
        //{
        //    //var tabbedPage = (App.Current.MainPage as NavigationPage).CurrentPage as TabbedPage;
        //    var tabbedPage = App.Current.MainPage as TabbedPage;
        //    tabbedPage.SelectedItem = tabbedPage.Children[1];
        //}

        //private void BtnLogin_Clicked(object sender, EventArgs e)
        //{
        //    App.Current.MainPage = new MainMasterDetailPage();
        //}
    }
}