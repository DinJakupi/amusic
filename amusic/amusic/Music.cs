using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ArrayAdapter<string> adapter;
        public List<String> songList;
        public string songName; 

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

        public void ListViewMusic(ListView musicListView)
        {
            try
            {
                adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, songList);
                musicListView.Adapter = adapter;
            } 
            catch
            {
            }
        }


    }
}