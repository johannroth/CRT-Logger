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
        public delegate void tickHandler(Ticker source);

        // Konstruktor des Tickers. tickInterval ist das Intervall in ms, in dem Ticks ausgegeben werden
        public Ticker(int tickInterval)
        {
            ticker = new System.Timers.Timer();
            ticker.Interval = tickInterval;
            ticker.Elapsed += onTick;
        }

        // Methode zum Starten des Tickers. 
        public void startTicker()
        {       
            ticker.Start();
            isRunning = true;
        }

        public void stopTicker()
        {
            ticker.Stop();
            isRunning = false;
        }

        public void toggleTicker()
        {
            if (isRunning)
            {
                stopTicker();
            }
            else
            {
                
                startTicker();
            }
        }

        private void onTick(Object source, System.Timers.ElapsedEventArgs e)
        {
            tick(this);
        }
    }
}
