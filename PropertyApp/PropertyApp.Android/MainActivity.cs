using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AndroidX.Core.Content;
using AndroidX.Core.App;
using System.Net;
using Plugin.Permissions;

namespace PropertyApp.Droid
{
    [Activity(Label = "PropertyApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            bool permission = ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.WriteExternalStorage) == Permission.Granted
           && ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.ReadExternalStorage) == Permission.Granted
           && ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessCoarseLocation) == Permission.Granted
           && ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessFineLocation) == Permission.Granted
           && ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.InstallPackages) == Permission.Granted
           && ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.RequestInstallPackages) == Permission.Granted;

            if (!permission)
            {
                ActivityCompat.RequestPermissions(this, new string[] {
                    Android.Manifest.Permission.ReadExternalStorage,
                    Android.Manifest.Permission.WriteExternalStorage,
                    Android.Manifest.Permission.AccessCoarseLocation,
                    Android.Manifest.Permission.AccessFineLocation,
                    Android.Manifest.Permission.InstallPackages,
                    Android.Manifest.Permission.RequestInstallPackages}, 549);
            }

            ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}