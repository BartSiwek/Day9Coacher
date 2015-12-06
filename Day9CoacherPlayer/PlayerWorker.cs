using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Day9CoacherPlayer
{
    internal class PlayerWorker
    {
        public PlayerWorker(BlockingQueue<PlayerWorkerTask> queue)
        {
            m_queue_ = queue;
            m_thread_ = new Thread(new ThreadStart(WorkerMain));
        }

        public void Start()
        {
            m_thread_.Start();
        }

        private void WorkerMain()
        {
            Debug.WriteLine("Player worker started [" + Thread.CurrentThread.ManagedThreadId + "]");

            PlayerWorkerTask task;
            while (m_queue_.TryDequeue(out task))
            {
                task();
            }

            Debug.WriteLine("Player worker finished [" + Thread.CurrentThread.ManagedThreadId + "]");
        }

        private Thread m_thread_;
        private BlockingQueue<PlayerWorkerTask> m_queue_;
    }
}
