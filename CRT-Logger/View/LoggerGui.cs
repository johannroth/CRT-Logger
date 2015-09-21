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

        public LoggerGui()
        {
            InitializeComponent();
        }

        public Button getButton(){
            return startButton;
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





    }
}
