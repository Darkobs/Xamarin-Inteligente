using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace XamarinInteligente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreenPage : ContentPage
    {
        public SplashScreenPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ViewModels.SplashScreenViewModel splashScreenViewModel = new ViewModels.SplashScreenViewModel();

            var isLoggedIn = await splashScreenViewModel.Login();

            if(isLoggedIn)
            {
                App.Current.MainPage = new MainMasterDetailPage();
            }
            else
            {
                Xamarin.Forms.TabbedPage tabbedPage = new Xamarin.Forms.TabbedPage();
                tabbedPage.Children.Add(new LoginPage());
                tabbedPage.Children.Add(new SignUpPage());
                tabbedPage.On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
                App.Current.MainPage = new NavigationPage(tabbedPage);
            }
        }
    }
}