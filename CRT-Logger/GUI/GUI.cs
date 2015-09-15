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

        public event testButtonClickHandler tickerToggleButtonClick;
        public delegate void testButtonClickHandler(Object source, EventArgs e);

        public Gui()
        {
            InitializeComponent();
        }

        private void tickerToggleButton_Click(object sender, EventArgs e)
        {
            tickerToggleButtonClick(this, null);
        }

        private void timeToStringButton_Click(object sender, EventArgs e)
        {
            timeLabel.Text = System.DateTime.Now.ToString("dd.MM. HH:mm:ss.fff");
        }

        public void setClockTime(string time)
        {
            clockTimeLabel.Text = time;
        }

    }
}
