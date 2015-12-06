using System;
using System.Collections.Generic;
using System.Text;
using IrrKlang;
using System.Diagnostics;
using System.Threading;

namespace Day9CoacherPlayer
{
    internal class PlayerImplementation
    {
        internal PlayerImplementation(PlayerTimer timer)
        {
            m_playlist = new Playlist();
            m_timer = timer;
            m_soundEngine = new ISoundEngine();
            m_current_sound = null;
            m_state = PlayerState.STOPPED;

            m_soundEngine.SoundVolume = 0.5f;
        }

        public void SetPlaylist(Playlist playlist)
        {
            if (playlist != null)
            {
                if (m_state == PlayerState.PLAYING)
                {
                    StopPlayback();
                }
                m_playlist = playlist;
            }
        }

        public void StartPlayback()
        {
            if (m_state == PlayerState.STOPPED)
            {
                //Set current song index to 0
                m_current_song_index = 0;

                //Start playback
                StartPlaybackFromCurrentSong();

                //Set the state        
                m_state = PlayerState.PLAYING;
            }
        }

        public void StopPlayback()
        {
            if (m_state == PlayerState.PLAYING)
            {
                //Stop current playback
                StopCurrentPlayback();

                //Set current song index to 0
                m_current_song_index = 0;

                //Set the state
                m_state = PlayerState.STOPPED;
            }
        }

        public void PlayNextSong()
        {
            if (m_state == PlayerState.PLAYING)
            {
                //Stop current playback
                StopCurrentPlayback();

                //Increase song index
                m_current_song_index = (m_current_song_index + 1) % m_playlist.Count;

                //Start next song
                StartPlaybackFromCurrentSong();
            }
        }

        public void SetVolume(float volume)
        {
            m_soundEngine.SoundVolume = volume;
        }

        public void Close()
        {
            if (m_current_sound != null)
            {
                m_current_sound.Stop();
            }

            //Debug message
            Debug.WriteLine("PlayerImplementation CLOSED by thread with id [" + Thread.CurrentThread.ManagedThreadId + "]");
        }

        //Private interface
        private void StopCurrentPlayback()
        {
            //Stop playback
            if (m_current_sound != null)
            {
                m_current_sound.Stop();
            }

            //Stop timer
            m_timer.Stop();
        }

        private void StartPlaybackFromCurrentSong()
        {
            //Do something only if it makes sense
            if (m_current_song_index < m_playlist.Count)
            {
                //Get filename and slot duration
                string filePath = m_playlist[m_current_song_index].FilePath;
                double slotDurationInSeconds = m_playlist[m_current_song_index].SlotDurationInSeconds;

                //Star playback
                m_current_sound = m_soundEngine.Play2D(filePath, false);

                //Start countdown
                m_timer.Start((int)(1000.0 * slotDurationInSeconds));
            }
        }

        //Enums
        private enum PlayerState
        {
            PLAYING,
            STOPPED,
        }

        //Member variables
        private Playlist m_playlist;
        private PlayerTimer m_timer;
        private ISoundEngine m_soundEngine;
        private ISound m_current_sound;
        private PlayerState m_state;
        private int m_current_song_index;
    }
}
