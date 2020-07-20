using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProjectDemo.Interfaces
{
    public enum Platform
    {
        Android,
        iOS
    }

    public interface IAppInfo
    {
        Platform GetPlatform { get; }
        string GetAppVersion { get; }
        string GetSystemVersion { get; }
    }
}
