using System;
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
        public delegate void ModeButtonClickHandler(object sender, ModeButtonClickEventArgs e);
        public event ModeButtonClickHandler modeButtonClick;

        public delegate void StartStopEventHandler(object sender, StartStopEventArgs e);
        public event StartStopEventHandler startStopEvent;

        private Services.ModeManager modeManager;

        public LoggerGui()
        {
            InitializeComponent();
        }
        
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
        public delegate void AddLogLineSafely(string logLine);
        /// <summary>
        /// Sets the isLastClicked status of a button. Setting enabled property is optional. 
        /// </summary>
        /// <param name="modeButton">Target button to change status.</param>
        /// <param name="isLastClicked">Specifies, if button will be highlighted as lastClicked.</param>
        /// <param name="isEnabled">Optionally specifies if button will be disabled.</param>
        /// <returns></returns>
        public void SetButtonStatus(Button modeButton, bool isLastClicked, bool isEnabled = true)
        {
            if (isLastClicked)
            {
                modeButton.BackColor = Color.PaleGreen;
            }
            else
            {
                modeButton.BackColor = SystemColors.Control;
            }
            if (isEnabled)
            {
                modeButton.Enabled = true;
            }
            else
            {
                modeButton.Enabled = false;
            }

        }
        public delegate void SetButtonStatusSafely(Button modeButton, bool isLastClicked, bool isEnabled = true);

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
