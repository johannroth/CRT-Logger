using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT_Logger
{
    public class StartStopEventArgs : EventArgs
    {
        public System.Windows.Forms.Button startStopButton;
        public bool start;
    }
}
