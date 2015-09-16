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
        private TextBox modeTextBox;
        private string modeType;

        public Mode(Label modeCounterLabel, Button modeButton, TextBox modeTextBox, string modeID, string modeLogID,
            string modeType, bool referenceMode)
        {
            this.modeCounterLabel = modeCounterLabel;
            this.modeID = modeID;
            this.modeLogID = modeLogID;
            this.referenceMode = referenceMode;
            this.modeButton = modeButton;
            this.modeTextBox = modeTextBox;
            this.modeType = modeType;
        }

        public Label getModeCounterLabel()
        {
            return modeCounterLabel;
        }
        public Button getModeButton()
        {
            return modeButton;
        }
        public TextBox getModeTextBox()
        {
            return modeTextBox;
        }
        public string getModeID()
        {
            return modeID;
        }
        public string getModeType()
        {
            return modeType;
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
        public bool isReferenceMode()
        {
            return referenceMode;
        }
    }
}
