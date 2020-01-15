using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
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
                var songName = adapter.GetItem(e.Position);
            }; 
        }
    }
}