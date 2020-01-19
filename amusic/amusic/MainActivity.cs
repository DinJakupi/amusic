using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Media;
using Android.Support.Design.Widget;
using Android.Webkit;
using System;

namespace amusic
{
    [Activity(Label = "amusic", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, Android.Hardware.ISensorEventListener
    {
        public AudioPlayer audioPlayer;
        public Music music;
        public MediaPlayer mediaPlayer;

        bool hasUpdated = false;
        DateTime lastUpdate;
        float last_x = 0.0f;
        float last_y = 0.0f;
        float last_z = 0.0f;

        const int ShakeDetectionTimeLapse = 200;
        const double ShakeThreshold = 200;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            FloatingActionButton playButton = FindViewById<FloatingActionButton>(Resource.Id.playButton);
            FloatingActionButton musicButton = FindViewById<FloatingActionButton>(Resource.Id.musicButton);

            var sensorManager = GetSystemService(SensorService) as Android.Hardware.SensorManager;
            var sensor = sensorManager.GetDefaultSensor(Android.Hardware.SensorType.Accelerometer);
            sensorManager.RegisterListener(this, sensor, Android.Hardware.SensorDelay.Game);

            playButton.Click += (sender, e) =>
            {
                //code to play music
                audioPlayer = new AudioPlayer();
                audioPlayer.StopPlayer(); 
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

        public void OnAccuracyChanged(Android.Hardware.Sensor sensor, Android.Hardware.SensorStatus accuracy)
        {
        }

        public void OnSensorChanged(Android.Hardware.SensorEvent e)
         {
            audioPlayer = new AudioPlayer(); 
            if (e.Sensor.Type == Android.Hardware.SensorType.Accelerometer)
            {
                float x = e.Values[0];
                float y = e.Values[1];
                float z = e.Values[2];

                DateTime curTime = DateTime.Now;
                if (hasUpdated == false)
                {
                    hasUpdated = true;
                    lastUpdate = curTime;
                    last_x = x;
                    last_y = y;
                    last_z = z;
                }
                else
                {
                    if ((curTime - lastUpdate).TotalMilliseconds > ShakeDetectionTimeLapse)
                    {
                        float diffTime = (float)(curTime - lastUpdate).TotalMilliseconds;
                        lastUpdate = curTime;
                        float total = x + y + z - last_x - last_y - last_z;
                        float speed = Math.Abs(total) / diffTime * 10000;

                        if (speed > ShakeThreshold)
                        {
                            Toast.MakeText(this, "shake detected w/ speed: " + speed, ToastLength.Short).Show();
                            audioPlayer.StartPlayer();
                        }
                        else
                        {
                            audioPlayer.StopPlayer();
                        }

                        last_x = x;
                        last_y = y;
                        last_z = z;
                    }
                }
            }
        }
    }
}