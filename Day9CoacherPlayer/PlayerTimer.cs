using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Day9CoacherPlayer
{
    internal class PlayerTimer
    {
        internal PlayerTimer()
        {
            m_player = null;
            m_timer = new Timer(IntervalElapsed);
            m_state = PlayerTimerState.STOPPED;
        }

        public void Start(int timeoutInMiliseconds)
        {
            if (m_state == PlayerTimerState.STOPPED)
            {
                //Start the timers
                m_timer.Change(timeoutInMiliseconds, Timeout.Infinite);

                //Set the state
                m_state = PlayerTimerState.RUNNING;

                //Debug message
                Debug.WriteLine("Timer started by thread with id [" + Thread.CurrentThread.ManagedThreadId + "]");
            }
            else //RUNNING
            {
                //Do nothing
            }
        }

        public void Stop()
        {
            if (m_state == PlayerTimerState.RUNNING)
            {
                //Stop the timers
                m_timer.Change(Timeout.Infinite, Timeout.Infinite);

                //Set the state
                m_state = PlayerTimerState.STOPPED;

                //Debug message
                Debug.WriteLine("Timer stoped by thread with id [" + Thread.CurrentThread.ManagedThreadId + "]");
            }
            else //STOPPED
            {
                //Do nothing
            }
        }

        //Internal methods
        internal void Close()
        {
            //Closing actions
            m_timer.Change(Timeout.Infinite, Timeout.Infinite);
            m_state = PlayerTimerState.STOPPED;
            m_timer.Dispose();

            //Debug message
            Debug.WriteLine("Timer CLOSED by thread with id [" + Thread.CurrentThread.ManagedThreadId + "]");
        }

        internal Player Player
        {
            get
            {
                return m_player;
            }
            set
            {
                m_player = value;
            }
        }

        //Private mehtods
        private void IntervalElapsed(object stateInfo)
        {
            if (m_player != null)
            {
                m_player.PlayNextSong();
            }
        }

        //Enums
        private enum PlayerTimerState
        {
            RUNNING,
            STOPPED,
        };

        //Member variables - timer state
        private PlayerTimerState m_state;

        //Member variables - player
        private Player m_player;

        //Member variables = timers etc.
        private Timer m_timer;
    }
}
