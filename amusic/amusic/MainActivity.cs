using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;

namespace amusic
{
    [Activity(Label = "amusic", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button playButton = FindViewById<Button>(Resource.Id.playButton);
            Button backButton = FindViewById<Button>(Resource.Id.backButton);
            Button skipButton = FindViewById<Button>(Resource.Id.skipButton);

            playButton.Click += (sender, e) =>
            {
                //code to play music
            };

            backButton.Click += (sender, e) =>
            {
                //code to go back an song
            };

            skipButton.Click += (sender, e) =>
            {
                //code to  skip a song
            }; 

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}