using System;
using System.Collections.Generic;
using System.Text;
using SharedProjectDemo.Interfaces;

namespace SharedProjectDemo.Core.ConditionalCompilation
{
    class AppInfo : IAppInfo
    {

#if __ANDROID__
        public Platform GetPlatform => Platform.Android;
#elif __IOS__
        public Platform GetPlatform => Platform.iOS;
#endif
        public string GetAppVersion
        {
            get
            {
#if __ANDROID__
                Android.Content.PM.PackageInfo pInfo
                = Android.App.Application.Context.PackageManager.GetPackageInfo
                (Android.App.Application.Context.PackageName, 0);
                return pInfo.VersionName;
#elif __IOS__
                return Foundation.NSBundle.MainBundle
                    .InfoDictionary["CFBundleShortVersionString"].ToString();
#endif
            }
        }

        public string GetSystemVersion =>
#if __ANDROID__
            Android.OS.Build.VERSION.Release;
#elif __IOS__
            UIKit.UIDevice.CurrentDevice.SystemVersion;
#endif

    }
}
