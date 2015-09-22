using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT_Logger.Services
{
    public class Ticker
    {
        private System.Timers.Timer ticker;
        private bool isRunning = false;

        public event tickHandler tick;
        public delegate void tickHandler(object source, EventArgs e);

        public Ticker(int tickInterval)
        {
            ticker = new System.Timers.Timer();
            ticker.Interval = tickInterval;
            ticker.Elapsed += OnTick;
        }
        public void StartTicker()
        {       
            ticker.Start();
            isRunning = true;
        }
        public void StopTicker()
        {
            ticker.Stop();
            isRunning = false;
        }
        public void ToggleTicker()
        {
            if (isRunning)
            {
                StopTicker();
            }
            else
            {
                StartTicker();
            }
        }

        private void OnTick(Object source, System.Timers.ElapsedEventArgs e)
        {
            tick(this, null);
        }
    }
}
