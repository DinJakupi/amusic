using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace amusic
{
    public class Music : MainActivity
    {
        public List<String> songList;
        public void MusicList() 
        {
            var allSongs = typeof(Resource.Raw).GetFields();
            songList = new List<String>();

            foreach(var song in allSongs)
            {
                songList.Add(song.Name);
            }
        }
    }
}