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

        public event testButtonClickHandler testButtonClick;
        public delegate void testButtonClickHandler(Object source, EventArgs e);



        public Gui()
        {
            InitializeComponent();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            testButtonClick(this, null);
        }
    }
}
