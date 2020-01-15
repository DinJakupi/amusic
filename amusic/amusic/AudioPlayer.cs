using System;
using System.Collections.Generic;
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
using Plugin.SimpleAudioPlayer; 

namespace amusic
{
    public class AudioPlayer : MainActivity
    {
        public bool StartPlayer(MediaPlayer mediaPlayer)
        {
            //Start Android Media Player
            mediaPlayer.Start();
            return true;
        }

        public bool StopPlayer(MediaPlayer mediaPlayer)
        {
            mediaPlayer.Pause();
            return true; 
        }
    }
}