using System;
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
            loggerGui.modeButtonClick += OnModeButtonClick;
            loggerGui.startStopEvent += OnStartStopEvent;
            secTicker.tick += OnTick;

            // Create new mode manager and tell view that it can initialize its modes.
            modeManager = new Services.ModeManager();
            loggerGui.InitializeModes(modeManager);
        }

        private void OnTick(object source, EventArgs e)
        {
            
        }
        private void OnStartStopEvent(object sender, StartStopEventArgs e)
        {
            Button button = e.startStopButton;
            bool start = e.start;
            Console.Beep();

            // Code for start routine

            // Code for stop routine
        }
        private void OnModeButtonClick(object sender, ModeButtonClickEventArgs e)
        {
            Button button = e.modeButton;
            // test!
            loggerGui.SetButtonStatus(button, true);

        }

        private void EnableUiModeButtons(bool enable)
        {

        }
    }
}
