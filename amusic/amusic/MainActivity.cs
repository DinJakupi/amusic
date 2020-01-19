using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Media;
using Android.Support.Design.Widget;
using Android.Webkit;

namespace amusic
{
    [Activity(Label = "amusic", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public AudioPlayer audioPlayer;
        public MediaPlayer mediaPlayer;
        public Music music;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            FloatingActionButton playButton = FindViewById<FloatingActionButton>(Resource.Id.playButton);
            FloatingActionButton musicButton = FindViewById<FloatingActionButton>(Resource.Id.musicButton);

            playButton.Click += (sender, e) =>
            {
                //code to play music
                audioPlayer = new AudioPlayer();
                try
                {
                    if (!mediaPlayer.IsPlaying)
                    {
                        audioPlayer.StartPlayer(mediaPlayer);
                    }
                    else
                    {
                        audioPlayer.StopPlayer(mediaPlayer);
                    }
                }
                catch
                {
                    audioPlayer.StopPlayer(mediaPlayer);
                }

            };

            musicButton.Click += (sender, e) =>
            {
                StartActivity(typeof(MusicActivity));
            }; 

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}