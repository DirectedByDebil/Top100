using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Views;
using Microsoft.Maui;

namespace Top100
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | 
        ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            UpdateStatusBarColor();
        }

        private void UpdateStatusBarColor()
        {
            var isDarkTheme = (Resources.Configuration.UiMode & UiMode.NightMask) == UiMode.NightYes;

            if (isDarkTheme)
            {
                Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#2E2C38")); // #2E2C38
                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.Visible;
            }
            else
            {
                Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#FFFFFF"));
                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
            }
        }

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            UpdateStatusBarColor();
        }
    }
}
