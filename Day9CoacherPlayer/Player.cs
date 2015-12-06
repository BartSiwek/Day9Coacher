using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Day9CoacherPlayer
{   
    public class Player
    {
        //Constructor
        internal Player(BlockingQueue<PlayerWorkerTask> queue, PlayerImplementation implementation)
        {
            m_queue_ = queue;
            m_implementation_ = implementation;
        }

        //Part of the interface used by UI
        public void SetPlaylist(Playlist playlist)
        { 
            m_queue_.Enqueue(delegate() {
                Debug.WriteLine("SetPlaylist task executed by [" + Thread.CurrentThread.ManagedThreadId + "]");
                m_implementation_.SetPlaylist(playlist);
            });
        }

        public void StartPlayback()
        {
            m_queue_.Enqueue(delegate()
            {
                Debug.WriteLine("StartPlayback task executed by [" + Thread.CurrentThread.ManagedThreadId + "]");
                m_implementation_.StartPlayback();
            });
        }

        public void StopPlayback()
        {
            m_queue_.Enqueue(delegate()
            {
                Debug.WriteLine("StopPlayback task executed by [" + Thread.CurrentThread.ManagedThreadId + "]");
                m_implementation_.StopPlayback();
            }); 
        }

        public void SetVolume(float volume)
        {
            m_queue_.Enqueue(delegate()
            {
                Debug.WriteLine("SetVolume task executed by [" + Thread.CurrentThread.ManagedThreadId + "]");
                m_implementation_.SetVolume(volume);
            });
        }

        //Part of the interface used by timer
        internal void PlayNextSong()
        {
            m_queue_.Enqueue(delegate()
            {
                Debug.WriteLine("PlayNextSong task executed by [" + Thread.CurrentThread.ManagedThreadId + "]");
                m_implementation_.PlayNextSong();
            });
        }

        //Implementation of Singleton pattern
        public static Player Instance
        {
            get
            {
                if (s_player_ == null)
                {
                    //Create everuthing and wire it togeather
                    s_queue_ = new BlockingQueue<PlayerWorkerTask>();
                    s_timer_ = new PlayerTimer();
                    s_player_implementation_ = new PlayerImplementation(s_timer_);
                    s_worker_ = new PlayerWorker(s_queue_);
                    s_player_ = new Player(s_queue_, s_player_implementation_);

                    //Set the player for the timer
                    s_timer_.Player = s_player_;

                    //Start the worker thread
                    s_worker_.Start();
                }

                return s_player_;
            }
        }

        public static void Close()
        {
            if (s_player_ != null)
            {
                //Close queue and timer
                s_queue_.Close();
                s_timer_.Close();
                s_player_implementation_.Close();

                //Disconnect the player form timer
                s_timer_.Player = null;

                //Set everything to null
                s_queue_ = null;
                s_timer_ = null;
                s_player_implementation_ = null;
                s_worker_ = null;
                s_player_ = null;
            }
        }

        //Static variables
        private static BlockingQueue<PlayerWorkerTask> s_queue_ = null;
        private static PlayerTimer s_timer_ = null;
        private static PlayerImplementation s_player_implementation_ = null;
        private static PlayerWorker s_worker_ = null;
        private static Player s_player_ = null;

        //Member variables
        private BlockingQueue<PlayerWorkerTask> m_queue_;
        private PlayerImplementation m_implementation_;
    }
}
