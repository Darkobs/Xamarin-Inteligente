using SharedProjectDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharedProjectDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            IAppInfo appInfo = (Application.Current as App).AppInfo;
            lbPlatform.Text = $"Plataform {appInfo.GetPlatform.ToString()}";
            lbAppVersion.Text = $"App Version {appInfo.GetAppVersion}";
            lbSystemVersion.Text = $"System Version {appInfo.GetSystemVersion}";
        }
    }
}
