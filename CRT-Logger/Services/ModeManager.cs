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

        public delegate void newActiveModeEventHandler(Object sender, NewActiveModeEventArgs e);
        public event newActiveModeEventHandler newActiveModeEvent;

        public ModeManager()
        {
            modes = new Hashtable();
        }

        /// <summary>
        /// Returns mode-object that is associated with the specified button.
        /// </summary>
        /// <param name="button">Button of the specific mode.</param>
        /// <returns>Returns associated Mode object for a certain button.</returns>
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
            NewActiveModeEventArgs args = new NewActiveModeEventArgs();
            if (activeMode != null)
            {
                args.lastActive = this.activeMode.GetButton();
            }
            else
            {
                args.lastActive = null;
            }
            args.newActive = activeMode.GetButton();
            this.activeMode = activeMode;
            newActiveModeEvent(this, args);
        }
        /// <summary>
        /// Sets active mode via button.
        /// </summary>
        /// <param name="modeButton">Button of currently active mode.</param>
        public void SetActiveMode(Button modeButton)
        {
            NewActiveModeEventArgs args = new NewActiveModeEventArgs();
            if (activeMode != null)
            {
                args.lastActive = this.activeMode.GetButton();
            }
            else
            {
                args.lastActive = null;
            }
            args.newActive = modeButton;
            this.activeMode = (Mode)modes[modeButton];
            newActiveModeEvent(this, args);
        }
        /// <summary>
        /// Sets active mode to null.
        /// </summary>
        public void SetNoModeActive()
        {
            NewActiveModeEventArgs args = new NewActiveModeEventArgs();
            if (activeMode != null)
            {
                args.lastActive = this.activeMode.GetButton();
            }
            else
            {
                args.lastActive = null;
            }
            args.newActive = null;
            this.activeMode = null;
            newActiveModeEvent(this, args);
        }
        /// <summary>
        /// Returns Hashtable of modes. Button objects are keys, Mode objects are values.
        /// </summary>
        public Hashtable GetModeHashtable()
        {
            return modes;
        }
        /// <summary>
        /// Adds new Mode to the Hashtable
        /// </summary>
        /// <param name="mode">Mode to be added to the Hashtable</param>
        public void AddMode(Mode mode)
        {
            modes.Add(mode.GetButton(), mode);
        }
    }
}
