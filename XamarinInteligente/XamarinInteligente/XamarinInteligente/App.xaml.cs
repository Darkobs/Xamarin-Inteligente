using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinInteligente.Views;

namespace XamarinInteligente
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ClientSearchPage();
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
