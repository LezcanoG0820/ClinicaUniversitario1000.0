using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;

namespace ClinicaUniversitaria
{
    [Activity(Theme = "@style/Maui.SplashTheme",
              MainLauncher = true,
              LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.ScreenSize
                                 | ConfigChanges.Orientation
                                 | ConfigChanges.UiMode
                                 | ConfigChanges.ScreenLayout
                                 | ConfigChanges.SmallestScreenSize
                                 | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
