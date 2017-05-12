using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Invengo.Audio;

namespace Invengo.Sample
{
    public class UiReadSound
    {
        private Thread threadProc;
        private static object objSync = new object();
        private bool _continue = false;
        //
        private object objLock = new object();
        private AutoResetEvent waitNotify;
        //
        private int tickStart = 0;
        private int tickEnd = 0;

        public UiReadSound()
        {
            waitNotify = new AutoResetEvent(false);
        }

        public bool Start()
        {
            if (_continue)
                return true;
            _continue = true;
            try
            {
                threadProc = new Thread(new ThreadStart(Proc));
                threadProc.IsBackground = true;
                threadProc.Priority = ThreadPriority.Normal;
                threadProc.Start();
                return true;
            }
            catch { }

            return false;
        }

        public void Set()
        {
            waitNotify.Set();
        }

        private void Proc()
        {
            tickStart = Environment.TickCount;
            while (_continue)
            {
                //lock (objLock)
                {
                    if (!waitNotify.WaitOne(1000, false))
                        continue;
                }
                tickEnd = Environment.TickCount;
                int mis = tickEnd - tickStart;
                if (mis > 50)   //80
                {
                    tickStart = tickEnd;
                    SoundScan();
                }
                Thread.Sleep(5);
            }
        }

        public void Stop()
        {
            _continue = false;
            try
            {
                if (threadProc != null)
                    threadProc.Abort();
            }
            catch { }

            waitNotify.Reset();
        }

        /// <summary>
        /// play success voice;
        /// </summary>
        public virtual void SoundScan()
        {
            //SoundPlayer.PlayWAV(@"\Windows\bing.wav");
            SoundPlayer.PlayWAV(@"\Windows\startup.wav");
        }
    }
}
