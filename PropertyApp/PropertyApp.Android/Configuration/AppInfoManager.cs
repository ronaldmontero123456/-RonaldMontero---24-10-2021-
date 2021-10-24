using Android.Content;
using PropertyApp.Abstraction;
using PropertyApp.Droid.Configuration;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppInfoManager))]
namespace PropertyApp.Droid.Configuration
{
    public class AppInfoManager : IAppInfo
    {
        public string DatabasePath()
        {
            var path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/external_sd/";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}