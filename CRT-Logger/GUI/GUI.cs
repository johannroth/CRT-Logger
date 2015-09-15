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

        // Event for the click of any modeButton
        public event modeButtonClickHandler modeButtonClick;
        public delegate void modeButtonClickHandler(string modeCode, EventArgs e);

        // Definition of delegates, so that external threads can call the methods
        public delegate void setUiClockTime(string time);

        // Variable to remember the last-clicked button
        private Button lastClicked = null;

        public Gui()
        {
            InitializeComponent();
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
        private void setLastClicked(Button button)
        {
            if (lastClicked != null)
            {
                lastClicked.BackColor = SystemColors.Control;
            }
            button.BackColor = Color.PaleGreen;
            lastClicked = button;
        }
        private void testMode1Button_Click(object sender, EventArgs e)
        {
            modeButtonClick("testMode1", null);
            setLastClicked(testMode1Button);
        }
        private void testMode2Button_Click(object sender, EventArgs e)
        {
            modeButtonClick("testMode2", null);
            setLastClicked(testMode2Button);
        }

        // Method to set the time of the clock
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

        private void resetModeCounters()
        {

        }
    }
}
    