using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace amusic
{
    public class Music : MainActivity
    {
        public ArrayAdapter<string> adapter;
        public List<String> songList;

        public List<String> MusicList() 
        {
            var allSongs = typeof(Resource.Raw).GetFields();
            songList = new List<String>();

            foreach(var song in allSongs)
            {
                songList.Add(song.Name);
            }
            return songList;
        }

        public MediaPlayer MediaPlayerSong(MediaPlayer mediaPlayer, Resource.Raw raw)
        {
            return mediaPlayer; 
        }

    }
}