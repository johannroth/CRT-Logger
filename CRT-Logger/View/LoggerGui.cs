﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRT_Logger
{
    public partial class LoggerGui : Form
    {
        private int timeInMode = 0;

        public delegate void ModeButtonClickHandler(object sender, ModeButtonClickEventArgs e);
        public event ModeButtonClickHandler modeButtonClick;

        public delegate void StartStopEventHandler(object sender, StartStopEventArgs e);
        public event StartStopEventHandler startStopEvent;

        private Services.ModeManager modeManager;

        public LoggerGui()
        {
            InitializeComponent();
        }

        // Delegates to ensure thread safety.
        public delegate void AddLogLineSafely(string logLine);
        public delegate void SetButtonStatusSafely(Button modeButton, bool isLastClicked);
        public delegate void EnableStartStopButtonsSafely(bool enable);
        public delegate void EnableModeButtonsSafely(bool enable);
        public delegate void SetModeCounterSafely(Label modeCounter,
            int count, bool isOverLimit);
        public delegate void ResetModeCountersSafely();
        public delegate void SetCurrentTimeSafely(DateTime time);
        public delegate void IncreaseTimeInModeSafely();
        public delegate void ResetTimeInModeSafely();
        public delegate void SetTimeInMeasurementSafely(string time);
        public delegate void SetRecordingStatusSafely(bool isRecording);

        /// <summary>
        /// Adds the specified string with a following NewLine-command to the logTextBox. 
        /// </summary>
        /// <param name="logLine">New line to write into the current log file.</param>
        /// <returns></returns>
        public void AddLogLine(string logLine)
        {
            if (logTextBox.InvokeRequired)
            {
                AddLogLineSafely d = new AddLogLineSafely(AddLogLine);
                Invoke(d, new object[] { logLine });
            }
            else
            {
                string newLine = logLine + Environment.NewLine;
                logTextBox.Text += newLine;
                logTextBox.SelectionStart = logTextBox.TextLength;
                logTextBox.ScrollToCaret();
            }
        }
        /// <summary>
        /// Sets the isLastClicked status of a button. 
        /// </summary>
        /// <param name="modeButton">Target button to change status.</param>
        /// <param name="isLastClicked">Specifies, if button will be highlighted as lastClicked.</param>
        public void SetButtonStatus(Button modeButton, bool isLastClicked)
        {
            if (modeButton.InvokeRequired)
            {
                SetButtonStatusSafely d = new SetButtonStatusSafely(SetButtonStatus);
                Invoke(d, new object[] { modeButton, isLastClicked });
            }
            else
            {
                if (isLastClicked)
                {
                    modeButton.BackColor = Color.PaleGreen;
                }
                else
                {
                    modeButton.BackColor = SystemColors.Control;
                }
            }
        }
        /// <summary>
        /// Enables or disables all mode buttons
        /// </summary>
        public void EnableModeButtons(bool enable)
        {
            if (this.InvokeRequired)
            {
                EnableModeButtonsSafely d = new EnableModeButtonsSafely( EnableModeButtons );
                Invoke(d, new object[] { enable });
            }
            else
            {
                foreach (DictionaryEntry mode in modeManager.GetModeHashtable())
                {
                    Button modeButton = mode.Key as Button;
                    modeButton.Enabled = enable;
                }
            }
        }
        /// <summary>
        /// Enables or disables Start and Stop buttons
        /// </summary>
        public void EnableStartStopButtons(bool enableStart)
        {
            if (this.InvokeRequired)
            {
                EnableStartStopButtonsSafely d = new EnableStartStopButtonsSafely(EnableStartStopButtons);
                Invoke(d, new object[] { enableStart });
            }
            else
            {
                startButton.Enabled = enableStart;
                stopButton.Enabled = !enableStart;
            }
        }
        /// <summary>
        /// Sets mode count and colors it, if its count is over the limit.
        /// </summary>
        /// <param name="modeCounter">Label of the label associated with the mode.</param>
        /// <param name="count">New count.</param>
        /// <param name="isOverLimit">Bool to specify, if limit is reached.</param>
        public void SetModeCounter(Label modeCounter, int count, bool isOverLimit)
        {
            if (modeCounter.InvokeRequired)
            {
                SetModeCounterSafely d = new SetModeCounterSafely(SetModeCounter);
                Invoke(d, new object[] { modeCounter, count, isOverLimit });
            }
            else
            {
                modeCounter.Text = count.ToString();
                if (isOverLimit)
                {
                    modeCounter.BackColor = Color.PaleGreen;
                }
                else
                {
                    modeCounter.BackColor = SystemColors.Control;
                }
            }
        }
        /// <summary>
        /// Resets mode Counters to zero
        /// </summary>
        public void ResetModeCounters()
        {
            if (logTextBox.InvokeRequired)
            {
                ResetModeCountersSafely d = new ResetModeCountersSafely(ResetModeCounters);
                Invoke(d, new object[] { });
            }
            else
            {
                foreach (DictionaryEntry modeEntry in modeManager.GetModeHashtable())
                {
                    Services.Mode mode = modeEntry.Value as Services.Mode;
                    Label modeCounter = mode.GetCounter();
                    if (modeCounter != null)
                    {
                        modeCounter.BackColor = SystemColors.Control;
                        modeCounter.Text = "0";
                    }
                    mode.ResetCount();
                }
            }
        }
        /// <summary>
        /// Sets current time
        /// </summary>
        /// <param name="time">DateTime object.</param>
        public void SetCurrentTime(DateTime time)
        {
            if (this.InvokeRequired)
            {
                SetCurrentTimeSafely d = new SetCurrentTimeSafely(SetCurrentTime);
                Invoke(d, new object[] { time });
            }
            else
            {
                currentTimeStatusLabel.Text = time.ToString("dd.MM.yyyy HH:mm:ss");
            }
        }
        /// <summary>
        /// Increase Time in current mode.
        /// </summary>
        /// <param name="time">Time in </param>
        public void IncreaseTimeInMode()
        {
            if (this.InvokeRequired)
            {
                IncreaseTimeInModeSafely d = new IncreaseTimeInModeSafely(IncreaseTimeInMode);
                Invoke(d, new object[] {  });
            }
            else
            {
                timeInMode++;
                timeInCurrentModeLabel.Text = timeInMode.ToString();
                if (timeInMode < 10)
                {
                    timeInCurrentModeLabel.BackColor = SystemColors.Control;
                }
                else
                {
                    timeInCurrentModeLabel.BackColor = Color.PaleGreen;
                    if ((timeInMode == 10) && beepCheckBox.Checked)
                    {
                        Console.Beep();
                    }
                }

            }
        }
        /// <summary>
        /// Reset time in mode to 0.
        /// </summary>
        /// <param name="time">Time in </param>
        public void ResetTimeInMode()
        {
            if (this.InvokeRequired)
            {
                ResetTimeInModeSafely d = new ResetTimeInModeSafely(ResetTimeInMode);
                Invoke(d, new object[] { });
            }
            else
            {
                timeInMode = 0;
                timeInCurrentModeLabel.Text = "0";
                timeInCurrentModeLabel.BackColor = SystemColors.Control;
            }
        }
        /// <summary>
        /// Sets time in measurement.
        /// </summary>
        /// <param name="time">Time in measurement as string.</param>
        public void SetTimeInMeasurement(string time)
        {
            if (this.InvokeRequired)
            {
                SetTimeInMeasurementSafely d = new SetTimeInMeasurementSafely(SetTimeInMeasurement);
                Invoke(d, new object[] { time });
            }
            else
            {
                recordingStatusLabel.Text = "Recording (" + time + ")";
            }
        }
        /// <summary>
        /// Sets recording status.
        /// </summary>
        /// <param name="isRecording">Recording status.</param>
        public void SetRecordingStatus(bool isRecording)
        {
            if (this.InvokeRequired)
            {
                SetRecordingStatusSafely d = new SetRecordingStatusSafely(SetRecordingStatus);
                Invoke(d, new object[] { isRecording });
            }
            else
            {
                if (isRecording)
                {
                    recordingStatusLabel.Text = "Recording";
                    recordingStatusLabel.BackColor = Color.LightSalmon;
                }
                else
                {
                    recordingStatusLabel.Text = "Not Recording";
                    recordingStatusLabel.BackColor = Color.PaleGreen;
                }
                
            }
        }

        public void InitializeModes(Services.ModeManager modeManager)
        {
            this.modeManager = modeManager;
            modeManager.AddMode(new Services.Mode("AV 40", modeAV40Button, modeAV40Counter));
            modeManager.AddMode(new Services.Mode("AV 80", modeAV80Button, modeAV80Counter));
            modeManager.AddMode(new Services.Mode("AV 100", modeAV100Button, modeAV100Counter));
            modeManager.AddMode(new Services.Mode("AV 120", modeAV120Button, modeAV120Counter, 99));
            modeManager.AddMode(new Services.Mode("AV 140", modeAV140Button, modeAV140Counter));
            modeManager.AddMode(new Services.Mode("AV 160", modeAV160Button, modeAV160Counter));
            modeManager.AddMode(new Services.Mode("AV 200", modeAV200Button, modeAV200Counter));
            modeManager.AddMode(new Services.Mode("AV 240", modeAV240Button, modeAV240Counter));
            modeManager.AddMode(new Services.Mode("AV 280", modeAV280Button, modeAV280Counter));
            modeManager.AddMode(new Services.Mode("AV 320", modeAV320Button, modeAV320Counter));
            modeManager.AddMode(new Services.Mode("VV -80", modeVVn80Button, modeVVn80Counter));
            modeManager.AddMode(new Services.Mode("VV -60", modeVVn60Button, modeVVn60Counter));
            modeManager.AddMode(new Services.Mode("VV -40", modeVVn40Button, modeVVn40Counter));
            modeManager.AddMode(new Services.Mode("VV -20", modeVVn20Button, modeVVn20Counter));
            modeManager.AddMode(new Services.Mode("VV 0", modeVV0Button, modeVV0Counter, 99));
            modeManager.AddMode(new Services.Mode("VV 20", modeVV20Button, modeVV20Counter));
            modeManager.AddMode(new Services.Mode("VV 40", modeVV40Button, modeVV40Counter));
            modeManager.AddMode(new Services.Mode("VV 60", modeVV60Button, modeVV60Counter));
            modeManager.AddMode(new Services.Mode("VV 80", modeVV80Button, modeVV80Counter));
            modeManager.AddMode(new Services.Mode("AVc 00", modeAVc1Button, modeAVc1Counter, modeAVc1TextBox, "AV"));
            modeManager.AddMode(new Services.Mode("AVc 00", modeAVc2Button, modeAVc2Counter, modeAVc2TextBox, "AV"));
            modeManager.AddMode(new Services.Mode("VVc 00", modeVVc1Button, modeVVc1Counter, modeVVc1TextBox, "VV"));
            modeManager.AddMode(new Services.Mode("VVc 00", modeVVc2Button, modeVVc2Counter, modeVVc2TextBox, "VV"));
            modeManager.AddMode(new Services.Mode("Idle", modeIdleButton));
            modeManager.AddMode(new Services.Mode("Note", modeCustomNoteButton, modeCustomNoteTextBox));
        }
        /// <summary>
        /// Returns text of custom note textbox.
        /// </summary>
        /// <param name="textBox">Textbox whose Text will be returned.</param>
        public string GetCustomNoteText(TextBox textBox)
        {
            return textBox.Text;
        }

        // Eventhandlers
        private void LoggerGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit? All unsaved data will be lost.",
                "Exit CRT-Logger",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            StartStopEventArgs args = new StartStopEventArgs();
            args.start = true;
            args.startStopButton = sender as Button;
            startStopEvent(this, args);
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            StartStopEventArgs args = new StartStopEventArgs();
            args.start = false;
            args.startStopButton = sender as Button;
            startStopEvent(sender, args);
        }
        private void AnyModeButton_Click(object sender, EventArgs e)
        {
            ModeButtonClickEventArgs args = new ModeButtonClickEventArgs();
            args.modeButton = sender as Button;
            modeButtonClick(sender, args);
        }





    }
}
