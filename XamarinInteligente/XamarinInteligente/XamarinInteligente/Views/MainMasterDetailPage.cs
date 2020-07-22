using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinInteligente.Views
{
    class MainMasterDetailPage : MasterDetailPage
    {
        public MainMasterDetailPage()
        {
            MasterBehavior = MasterBehavior.Popover;
            Master = new NavigationPage(new MenuPage())
            { Title = "Menú Principal"};

            Detail = new NavigationPage(new NextClientPage());
        }

        protected override bool OnBackButtonPressed()
        {
            Xamarin.Forms.TabbedPage tabbedPage = new Xamarin.Forms.TabbedPage();
            tabbedPage.Children.Add(new LoginPage());
            tabbedPage.Children.Add(new SignUpPage());
            App.Current.MainPage = tabbedPage;

            //return base.OnBackButtonPressed();
            return true;
        }
    }
}
