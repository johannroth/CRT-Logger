using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRT_Logger.Services
{
    public class ModeManager
    {
        private Hashtable modes;
        private Mode activeMode;

        public ModeManager()
        {
            modes = new Hashtable();
        }

        /// <summary>
        /// Returns mode-object that is associated with the specified button.
        /// </summary>
        /// <param name="button">Button of the specific mode.</param>
        public Mode GetMode(Button button)
        {
            if (modes.ContainsKey(button))
            {
                return (Mode)modes[button];
            }
            else
            {
                MessageBox.Show("Button is not associated with a defined mode!", "Error",MessageBoxButtons.OK);
                return null;
            }
        }
        /// <summary>
        /// Returns mode that is currently active mode.
        /// </summary>
        public Mode GetActiveMode()
        {
            return activeMode;
        }
        /// <summary>
        /// Sets active mode.
        /// </summary>
        /// <param name="activeMode">Currently active mode.</param>
        public void SetActiveMode(Mode activeMode)
        {
            this.activeMode = activeMode;
        }
        /// <summary>
        /// Returns Hashtable of modes. Button objects are keys, Mode objects are values.
        /// </summary>
        public Hashtable GetModeHashtable()
        {
            return modes;
        }
    }
}
