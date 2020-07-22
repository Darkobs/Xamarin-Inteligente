using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using XamarinInteligente.Views;

namespace XamarinInteligente
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            Xamarin.Forms.TabbedPage tabbedPage = new Xamarin.Forms.TabbedPage();
            tabbedPage.Children.Add(new LoginPage());
            tabbedPage.Children.Add(new SignUpPage());

            // Muestra los tabs en la parte inferior
            //tabbedPage.On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            //MainPage = tabbedPage;

            //MainPage = new MainMasterDetailPage();
            
            //Asignamos la página de pestañas como inicial, la envolvemos en un NavigationPage para tener a la vista la barra de navegación
            //MainPage = new NavigationPage(tabbedPage);
            MainPage = tabbedPage;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
