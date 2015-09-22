using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRT_Logger
{
    public class NewActiveModeEventArgs : EventArgs
    {
        public Button newActive;
        public Button lastActive;
    }
}
