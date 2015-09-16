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
    public partial class Gui : Form
    {
        // Event to toggle external ticker
        public event tickerToggleButtonClickHandler tickerToggleButtonClick;
        public delegate void tickerToggleButtonClickHandler(Object source, EventArgs e);

        // Event to add a Mode
        public event modeAddHandler modeAdd;
        public delegate void modeAddHandler(object sender, string modeID, string modeLogID,
            Label modeCounterLabel, Button modeButton, bool referenceMode, EventArgs e);

        // Event for the click of any modeButton
        public event modeButtonClickHandler modeButtonClick;
        public delegate void modeButtonClickHandler(string modeCode, EventArgs e);

        // Definition of delegates, so that external threads can call the methods
        public delegate void setUiClockTime(string time);
        public delegate void setUiModeCount(Label modeCounterLabel, int modeCount, bool isDone);
        public delegate void setUiModeStatus(Button modeButton, bool lastClicked);

        public Gui()
        {
            InitializeComponent();
        }

        // Method to initialize Modes. Careful when changing oder adding modeIDs, remember to change
        // modeID in buttonClick event too!
        // (sender, modeID, modeLogID, modeCounterLabel, modeButton, referenceMode, e)
        public void initializeModes()
        {
            modeAdd(this, "Idle", "Idle", null, modeIdleButton, false, null);
            modeAdd(this, "AV40", "AV 40", modeAV40Label, modeAV40Button, false, null);
            modeAdd(this, "AV80", "AV 80", modeAV80Label, modeAV80Button, false, null);
            modeAdd(this, "AV120", "AV 120", modeAV120Label, modeAV120Button, true, null);
        }

        // Test buttons in gui
        private void tickerToggleButton_Click(object sender, EventArgs e)
        {
            tickerToggleButtonClick(this, null);
        }
        private void timeToStringButton_Click(object sender, EventArgs e)
        {
            timeLabel.Text = System.DateTime.Now.ToString("dd.MM. HH:mm:ss.fff");
        }

        // Buttons to select modes
        private void modeIdleButton_Click(object sender, EventArgs e)
        {
            modeButtonClick("Idle", null);
        }
        private void modeAV40Button_Click(object sender, EventArgs e)
        {
            modeButtonClick("AV40", null);
        }
        private void modeAV80Button_Click(object sender, EventArgs e)
        {
            modeButtonClick("AV80", null);
        }
        private void modeAV120Button_Click(object sender, EventArgs e)
        {
            modeButtonClick("AV120", null);
        }

        // Methods to set GUI elements (safe to call from external threads).
        public void setClockTime(string time)
        {
            if (clockTimeLabel.InvokeRequired)
            {
                setUiClockTime d = new setUiClockTime(setClockTime);
                Invoke(d, new object[] { time });
            }
            else
            {
                clockTimeLabel.Text = time;
            }
        }
        public void setModeCount(Label modeCounterLabel, int modeCount, bool isDone)
        {
            if (modeCounterLabel.InvokeRequired)
            {
                setUiModeCount d = new setUiModeCount(setModeCount);
                Invoke(d, new object[] { modeCounterLabel, modeCount, isDone});
            }
            else
            {
                modeCounterLabel.Text = modeCount.ToString();
                if (isDone)
                {
                    modeCounterLabel.BackColor = Color.PaleGreen;
                }
                else
                {
                    modeCounterLabel.BackColor = SystemColors.Control;
                }
            }
        }
        public void setModeStatus(Button modeButton, bool lastClicked)
        {
            if (modeButton.InvokeRequired)
            {
                setUiModeStatus d = new setUiModeStatus(setModeStatus);
                Invoke(d, new object[] { modeButton, lastClicked });
            }
            else
            {
                if (lastClicked)
                {
                    modeButton.BackColor = Color.PaleGreen;
                }
                else
                {
                    modeButton.BackColor = SystemColors.Control;
                }
            }
        }
    }
}
    