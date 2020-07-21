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
            Master = new NavigationPage(new MenuPage())
            { Title = "Menú Principal"};

            Detail = new NavigationPage(new NextClientPage());
        }
    }
}
