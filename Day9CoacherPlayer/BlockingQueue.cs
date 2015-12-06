using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Day9CoacherPlayer
{
    internal class BlockingQueue<T>
    {
        public void Enqueue(T item)
        {
            lock (m_lock_)
            {
                m_queue_.Enqueue(item);
                if (m_queue_.Count == 1)
                {
                    Monitor.PulseAll(m_lock_);
                }
            }
        }

        public bool TryDequeue(out T item)
        {
            lock (m_lock_)
            {
                while (m_queue_.Count == 0)
                {
                    if (m_closing_)
                    {
                        item = default(T);
                        return false;
                    }
                    Monitor.Wait(m_lock_);
                }
                item = m_queue_.Dequeue();
                return true;
            }
        }

        public void Close()
        {
            //Debug message
            Debug.WriteLine("BlockingQueue CLOSED by thread with id [" + Thread.CurrentThread.ManagedThreadId + "]");

            lock (m_lock_)
            {
                m_closing_ = true;
                Monitor.PulseAll(m_lock_);
            }
        }

        private readonly Queue<T> m_queue_ = new Queue<T>();
        private readonly object m_lock_ = new object();
        private bool m_closing_ = false;
    }
}
