using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRT_Logger.Control
{
    public class LoggerController
    {
        private LoggerGui loggerGui;
        private Services.ModeManager modeManager;
        private bool measurementRunning;
        private Services.Ticker secTicker;
        private DateTime measurementStartTime;

        public LoggerController(LoggerGui loggerGui)
        {
            this.loggerGui = loggerGui;
            secTicker = new Services.Ticker(1000);

            // Listen to ButtonClick Events in GUI.
            loggerGui.modeButtonClick += OnModeButtonClick;
            loggerGui.startStopEvent += OnStartStopEvent;
            // Listen to Tick Events of Ticker.
            secTicker.tick += OnTick;

            // Create new mode manager and listen to its Events.
            modeManager = new Services.ModeManager();
            modeManager.newActiveModeEvent += OnNewActiveModeEvent;
            // Initialize all modes in gui.
            loggerGui.InitializeModes(modeManager);

            // Disable all mode buttons at start of software.
            loggerGui.EnableModeButtons(false);
            loggerGui.EnableStartStopButtons(true);
            loggerGui.ResetModeCounters();
        }

        private void OnNewActiveModeEvent(object sender, NewActiveModeEventArgs e)
        {
            if (e.lastActive != null)
            {
                loggerGui.SetButtonStatus(e.lastActive, false);
            }
            if (e.newActive != null)
            {
                loggerGui.SetButtonStatus(e.newActive, true);
            }
        }
        private void OnTick(object source, EventArgs e)
        {
            
        }
        private void OnStartStopEvent(object sender, StartStopEventArgs e)
        {
            Button button = e.startStopButton;
            bool start = e.start;
            if(!start)
            {
                if (MessageBox.Show("Do you really want to finish measurement? Timers will be reset!",
                "End Measurement", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    // Code for stop routine.
                    modeManager.SetNoModeActive();
                    loggerGui.EnableModeButtons(start);
                    loggerGui.EnableStartStopButtons(!start);
                    loggerGui.ResetModeCounters();
                }
            }
            else
            {
                // Code for start routine.
                modeManager.SetNoModeActive();
                loggerGui.EnableModeButtons(start);
                loggerGui.EnableStartStopButtons(!start);
            }

        }
        private void OnModeButtonClick(object sender, ModeButtonClickEventArgs e)
        {
            Button button = e.modeButton;
            Services.Mode mode = modeManager.GetMode(button);
            Label counter = mode.GetCounter();

            if (modeManager.GetActiveMode() != mode)
            {
                modeManager.SetActiveMode(button);
                int count = mode.IncreaseCount();
                if (counter != null)
                {
                    loggerGui.SetModeCounter(counter, count, mode.IsOverLimit());
                }
            }
        }
    }
}
