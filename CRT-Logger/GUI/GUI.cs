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

        public event tickerToggleButtonClickHandler tickerToggleButtonClick;
        public delegate void tickerToggleButtonClickHandler(Object source, EventArgs e);

        // Definition of delegate, so that external threads can call the method
        public delegate void setUiClockTime(string time);
        public setUiClockTime setUiClockTimeDelegate;

        public Gui()
        {
            InitializeComponent();
            setUiClockTimeDelegate = new setUiClockTime(setClockTime);
        }

        private void tickerToggleButton_Click(object sender, EventArgs e)
        {
            tickerToggleButtonClick(this, null);
        }

        private void timeToStringButton_Click(object sender, EventArgs e)
        {
            timeLabel.Text = System.DateTime.Now.ToString("dd.MM. HH:mm:ss.fff");
        }

        private void setClockTime(string time)
        {
            clockTimeLabel.Text = time;
        }

    }
}
