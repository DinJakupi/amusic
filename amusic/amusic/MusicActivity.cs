using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace amusic
{
    [Activity(Label = "MusicActivity")]
    public class MusicActivity :  Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_music);
            // Create your application here
            ListView musicListView = FindViewById<ListView>(Resource.Id.musicListView);
            Music music = new Music();

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, music.MusicList());
            musicListView.Adapter = adapter;

            musicListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {
                AudioPlayer audioPlayer = new AudioPlayer(); 

                //This gets the Song Name & is starting the Media Player
                var songName = adapter.GetItem(e.Position);
                audioPlayer.CheckMediaPlayerIsPlaying(this, SetSong(songName));
                var activity = new Intent(this, typeof(MainActivity));
                StartActivity(typeof(MainActivity));
            }; 
        }

        public int SetSong(string songName)
        {
            //Set th Song who is going to play in the MediaPlayer
            MediaPlayer mediaPlayer = new MediaPlayer();
            switch (songName)
            {
                case "TheGrinch":
                    return Resource.Raw.TheGrinch;
                case "GangGang":
                    return Resource.Raw.GangGang;
                case "BackInBack":
                    return Resource.Raw.BackInBack;
                case "Darkness":
                    return Resource.Raw.Darkness;
                case "Kamikaze":
                    return Resource.Raw.Kamikaze;
                case "Thunderstuck":
                    return Resource.Raw.Thunderstuck;
                case "YouShookMeAllNight":
                    return Resource.Raw.YouShookMeAllNightLong;
            }

            return 0;
        }

    }
}