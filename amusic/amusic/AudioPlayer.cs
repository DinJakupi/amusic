using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Plugin.SimpleAudioPlayer; 

namespace amusic
{
    public class AudioPlayer : MainActivity
    {

        public static MediaPlayer mediaPlayer;
        public bool StartPlayer()
        {
            //Start Android Media Player
            if(mediaPlayer != null)
            {
                mediaPlayer.Start();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StopPlayer()
        {
            //Stops the MediaPlayer
            try
            {
                mediaPlayer.Pause();
            }
            catch
            {
                //some error has occured
            }
            return true; 
        }

        public void CheckMediaPlayerIsPlaying(Context c, int id)
        {
            //checks if a MediaPlayer is already running
            mediaPlayer = MediaPlayer.Create(c, id);
            if (!mediaPlayer.IsPlaying)
            {
                StartPlayer();
            }
            else
            {
                StopPlayer();
            }
        }

    }
}