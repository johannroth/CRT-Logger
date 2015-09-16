using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace CRT_Logger
{
    public class Controller
    {
        private Gui gui;
        private Services.Clock clock;
        private Services.Ticker secondTicker;
        private Button lastClickedButton = null;
        private Hashtable modes;

        public Controller(Gui gui)
        {
            this.gui = gui;

            // Eventhandler for ButtonClick events
            gui.tickerToggleButtonClick += OnTickerToggleButtonClick;
            gui.modeButtonClick += OnModeButtonClick;
            // Eventhandler for adding a Mode
            gui.modeAdd += OnModeAdd;
            // Start a new clock
            clock = new Services.Clock();

            // Start a new ticker
            secondTicker = new Services.Ticker(1000);
            secondTicker.tick += OnTick;

            // Initialize Hashtable for saving used modes.
            modes = new Hashtable();
            // Initialize gui Modes.
            gui.initializeModes();
        }

        // Eventhandlers
        private void OnTickerToggleButtonClick(object o, EventArgs e)
        {
            Console.Beep();
            secondTicker.toggleTicker();
        }
        private void OnTick(Services.Ticker source)
        {
            if (source == secondTicker)
            {
                setGuiTime();
            }
            
        }
        private void OnModeAdd(object sender, string modeID, string modeLogID, Label modeCounterLabel,
                               Button modeButton, bool referenceMode, EventArgs e)
        {
            Services.Mode newMode = new Services.Mode(modeCounterLabel, modeButton, modeID, modeLogID, referenceMode);
            modes.Add(modeID, newMode);
        }
        private void OnModeButtonClick(string modeID, EventArgs e)
        {
            Services.Mode mode = (Services.Mode)modes[modeID];
            Button modeButton = mode.getModeButton();

            // Increase Mode Counter.
            // Only if not already clicked and only if not idle mode, idle mode
            // does not have a counter thus no label.
            if (modeID != "Idle" && (modeButton != lastClickedButton))
            {
                Label modeLabel = mode.getModeCounterLabel();
                int count = mode.increaseModeCount();

                // Checks if mode is no reference mode and colors it, if needed.
                bool isDone = false;
                if (!mode.isReferenceMode())
                {
                    isDone = (count >= 3);
                }

                // Write back increased mode count and done-flag.
                gui.setModeCount(modeLabel, count, isDone);
            }
            
            // Register clicked mode button as last clicked button
            // and send current clicked-status to GUI.
            if (lastClickedButton != null)
            {
                gui.setModeStatus(lastClickedButton, false);
            }
            lastClickedButton = mode.getModeButton();
            gui.setModeStatus(lastClickedButton, true);

            // Write line in log
        }

        // Gets Time from clock and pushes it to gui
        private void setGuiTime()
        {
            string time = clock.getDateTime().ToString("dd.MM. HH:mm:ss");
            gui.setClockTime(time);
        }
        // Resets all ModeCounters for all Modes in modes Hashtable.
        private void resetModeCounters()
        {
            foreach (DictionaryEntry entry in modes)
            {
                Services.Mode mode = (Services.Mode)entry.Value;
                mode.resetModeCount();
                Label modeCounterLabel = mode.getModeCounterLabel();
                if (modeCounterLabel != null)
                {
                    gui.setModeCount(modeCounterLabel, 0, false);
                }
            }
        }
    }
}
