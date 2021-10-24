using Foundation;
using PropertyApp.Abstraction;
using PropertyApp.iOS.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppInfoManager))]
namespace PropertyApp.iOS.Configuration
{
    public class AppInfoManager : IAppInfo
    {
        public string DatabasePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
        }
    }
}