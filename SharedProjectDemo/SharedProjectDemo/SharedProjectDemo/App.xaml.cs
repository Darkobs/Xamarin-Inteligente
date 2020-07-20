using SharedProjectDemo.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharedProjectDemo
{
    public partial class App : Application
    {
        public IAppInfo AppInfo { get; set; }

        public App(IAppInfo appInfo)
        {
            AppInfo = appInfo;
            InitializeComponent();

            MainPage = new MainPage();
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
