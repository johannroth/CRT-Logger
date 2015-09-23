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
        private Services.Ticker modeSecTicker;
        private Services.Ticker measurementSecTicker;
        private Services.Clock clock;
        private DateTime measurementStartTime;

        public LoggerController(LoggerGui loggerGui)
        {
            this.loggerGui = loggerGui;
            secTicker = new Services.Ticker(1000);
            modeSecTicker = new Services.Ticker(1000);
            measurementSecTicker = new Services.Ticker(1000);
            clock = new Services.Clock();

            // Listen to ButtonClick Events in GUI.
            loggerGui.modeButtonClick += OnModeButtonClick;
            loggerGui.startStopEvent += OnStartStopEvent;
            // Listen to Tick Events of Ticker.
            secTicker.tick += OnTick;
            modeSecTicker.tick += OnTick;
            measurementSecTicker.tick += OnTick;

            // Create new mode manager and listen to its Events.
            modeManager = new Services.ModeManager();
            modeManager.newActiveModeEvent += OnNewActiveModeEvent;
            // Initialize all modes in gui.
            loggerGui.InitializeModes(modeManager);

            // Disable all mode buttons at start of software.
            loggerGui.EnableModeButtons(false);
            loggerGui.EnableStartStopButtons(true);
            loggerGui.ResetModeCounters();
            loggerGui.ResetTimeInMode();
            loggerGui.ResetLog();

            // Start the ticker to get current time
            secTicker.StartTicker();
        }

        /// <summary>
        /// Creates the string for a new log line without newline command.
        /// Writes this string to TxtFile and TextBox on Gui.
        /// </summary>
        private void CreateLogLine(Services.Mode mode)
        {
            string time = clock.GetDateTime().ToString("HH:mm:ss.fff");
            string runningFor = clock.GetTimeSinceStringLong(measurementStartTime);
            string logId = mode.GetLogId();

            string logLine = String.Format("{0}, {1}, {2}", time,
                runningFor, logId);

            loggerGui.AddLogLine(logLine);
        }
        private string CreateLogLineString(string customLogNote)
        {
            string time = clock.GetDateTime().ToString("HH:mm:ss.fff");
            string runningFor = clock.GetTimeSinceStringLong(measurementStartTime);

            return String.Format("{0}, {1}, {2}", time, runningFor, customLogNote);
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
            if (secTicker == source as Services.Ticker)
            {
                loggerGui.SetCurrentTime(clock.GetDateTime());
            }
            else if (modeSecTicker == source as Services.Ticker)
            {
                loggerGui.IncreaseTimeInMode();
            }
            else if (measurementSecTicker == source as Services.Ticker)
            {
                string time = clock.GetTimeSinceStringShort(measurementStartTime);
                loggerGui.SetTimeInMeasurement(time);
            }
            
        }
        private void OnStartStopEvent(object sender, StartStopEventArgs e)
        {
            Button button = e.startStopButton;
            bool start = e.start;
            if(!start)
            {
                string stopLogLine = CreateLogLineString("STOP");
                if (MessageBox.Show("Do you really want to finish measurement? Timers will be reset!",
                "End Measurement", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    // Code for stop routine.
                    loggerGui.AddLogLine(stopLogLine);
                    modeSecTicker.StopTicker();
                    measurementSecTicker.StopTicker();
                    loggerGui.ResetTimeInMode();
                    modeManager.SetNoModeActive();
                    loggerGui.EnableModeButtons(start);
                    loggerGui.EnableStartStopButtons(!start);
                    loggerGui.ResetModeCounters();
                    loggerGui.SetTimeInMeasurement("00:00:00");
                    loggerGui.SetRecordingStatus(start);
                    measurementRunning = false;
                }
            }
            else
            {
                // Check if a valid file path was selected before.
                if (loggerGui.FilePathOk())
                {
                    // Code for start routine.
                    measurementStartTime = clock.GetDateTime();
                    measurementSecTicker.StartTicker();
                    measurementRunning = true;
                    modeManager.SetNoModeActive();
                    loggerGui.EnableModeButtons(start);
                    loggerGui.EnableStartStopButtons(!start);
                    loggerGui.SetRecordingStatus(start);
                    loggerGui.ResetLog();
                    loggerGui.AddLogLine(CreateLogLineString("START"));
                }                
                else
                {
                    MessageBox.Show("Select a valid folder first!", "Folder missing", MessageBoxButtons.OK);
                }
            }
        }
        private void OnModeButtonClick(object sender, ModeButtonClickEventArgs e)
        {
            Button button = e.modeButton;
            Services.Mode mode = modeManager.GetMode(button);
            Label counter = mode.GetCounter();
            TextBox textBox = mode.GetTextBox();

            // Read custom text, if custom mode button was clicked.
            if (mode.IsCustom())
            {
                string logId = loggerGui.GetCustomText(textBox);

                // If no custom Text is entered, text will be "custom".
                if (logId == "")
                {
                    logId = "custom";
                }

                // For custom modes that are not annotations,
                // logId will contain the modeType aswell.
                if (!mode.IsAnnotation())
                {
                    logId = mode.GetModeType() + " " + logId;
                }
                // Annotations will get the additional string "NOTE "
                else
                {
                    logId = "NOTE '" + logId + "'";
                }
                
                mode.SetLogId(logId);
            }
            
            // Immediately create logLine for Custom annotations
            if (mode.IsAnnotation() && mode.IsCustom())
            {
                CreateLogLine(mode);
            }
            // For all other mode buttons check if button was already clicked.
            else if (modeManager.GetActiveMode() != mode)
            {
                CreateLogLine(mode);
                
                // Set mode and button as active. Increase Count.
                modeManager.SetActiveMode(button);
                int count = mode.IncreaseCount();
                if (counter != null)
                {
                    loggerGui.SetModeCounter(counter, count, mode.IsOverLimit());
                }

                // Reset the time in Mode Ticker.
                modeSecTicker.ResetTicker();
                loggerGui.ResetTimeInMode();
            }
        }
    }
}
