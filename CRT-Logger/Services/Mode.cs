using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CRT_Logger.Services
{
    class Mode
    {
        private string modeID;
        private string modeLogID;
        private bool referenceMode;
        private int modeCount = 0;
        private Label modeCounterLabel;
        private Button modeButton;

        public Mode(Label modeCounterLabel, Button modeButton, string modeID, string modeLogID, bool referenceMode)
        {
            this.modeCounterLabel = modeCounterLabel;
            this.modeID = modeID;
            this.modeLogID = modeLogID;
            this.referenceMode = referenceMode;
            this.modeButton = modeButton;
        }

        public Label getModeCounterLabel()
        {
            return modeCounterLabel;
        }
        public Button getModeButton()
        {
            return modeButton;
        }
        public string getModeID()
        {
            return modeID;
        }
        public void setModeLogID(string modeLogID)
        {
            this.modeID = modeLogID;
        }
        public int increaseModeCount()
        {
            modeCount++;
            return modeCount;
        }
        public void resetModeCount()
        {
            modeCount = 0;
        }
    }
}
