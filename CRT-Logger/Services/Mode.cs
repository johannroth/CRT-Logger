using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRT_Logger.Services
{
    public class Mode
    {
        // Id that will be displayed in Log.
        private string logId;
        private int count = 0;
        // Limit for the mode count, to be marked as finished .
        private int limit = 99;
        private Button button;
        private Label counter;
        private TextBox textBox;
        // String for modeType, needed for custom modes.
        // can be "AV", "VV" or "Note".
        string modeType;
        // Bools to specify type of mode.
        bool isReference = false;
        bool isAnnotation = false;
        bool isCustom = false;

        // Note
        /// <summary>
        /// Constructor for annotations, no textBox.
        /// </summary>
        /// <param name="logId">ID that will be displayed in Log.</param>
        /// <param name="button">Button of the specific mode.</param>
        /// <returns></returns>
        public Mode(string logId, Button button)
        {
            this.logId = logId;
            this.button = button;
            isAnnotation = true;
        }
        // Custom Note
        /// <summary>
        /// Constructor for custom annotation with textBox.
        /// </summary>
        /// <param name="logId">ID that will be displayed in Log.</param>
        /// <param name="button">Button of the specific mode.</param>
        /// <param name="textBox">TextBox containing the custom annotation.</param>
        /// <returns></returns>
        public Mode(string logId, Button button, TextBox textBox)
        {
            this.logId = logId;
            this.button = button;
            this.textBox = textBox;
            isAnnotation = true;
            isCustom = true;
        }
        // Normal mode
        /// <summary>
        /// Constructor for normal modes.
        /// </summary>
        /// <param name="logId">ID that will be displayed in Log.</param>
        /// <param name="button">Button of the specific mode.</param>
        /// <param name="label">Counter label of the specific mode.</param>
        /// <returns></returns>
        public Mode(string logId, Button button, Label counter)
        {
            this.logId = logId;
            this.button = button;
            this.limit = 3;
            this.counter = counter;
        }
        // Reference mode
        /// <summary>
        /// Constructor for reference modes.
        /// </summary>
        /// <param name="logId">ID that will be displayed in Log.</param>
        /// <param name="button">Button of the specific mode.</param>
        /// <param name="label">Counter label of the specific mode.</param>
        /// <param name="limit">Limit for the mode count, to be marked as finished.</param>
        /// <returns></returns>
        public Mode(string logId, Button button, Label counter, int limit)
        {
            this.logId = logId;
            this.button = button;
            this.limit = limit;
            this.counter = counter;
            isReference = true;
        }
        // Custom mode
        /// <summary>
        /// Constructor for custom AV/VV modes.
        /// </summary>
        /// <param name="logId">ID that will be displayed in Log.</param>
        /// <param name="button">Button of the specific mode.</param>
        /// <param name="label">Counter label of the specific mode.</param>
        /// <param name="textBox">TextBox, that contains the specification of the mode.</param>
        /// <param name="modeType">String that specifies modeType, AV or VV.</param>
        /// <returns></returns>
        public Mode(string logId, Button button, Label counter, TextBox textBox, string modeType)
        {
            this.logId = logId;
            this.button = button;
            this.counter = counter;
            this.textBox = textBox;
            this.modeType = modeType;
            isCustom = true;
        }

        /// <summary>
        /// Returns the Button that is associated with the mode.
        /// </summary>
        public Button GetButton()
        {
            return button;
        }
        /// <summary>
        /// Returns the counter Label that is associated with the mode.
        /// </summary>
        public Label GetCounter()
        {
            return counter;
        }
        /// <summary>
        /// Returns the TextBox that is associated with the mode.
        /// </summary>
        public TextBox GetTextBox()
        {
            return textBox;
        }
        /// <summary>
        /// Increases the count by one, returns new count.
        /// </summary>
        public int IncreaseCount()
        {
            count++;
            return count;
        }
        /// <summary>
        /// Sets count to 0.
        /// </summary>
        public void ResetCount()
        {
            count = 0;
        }
        /// <summary>
        /// Returns the LogId.
        /// </summary>
        public string GetLogId()
        {
            return logId;
        }
        /// <summary>
        /// Sets the LogId to the specified string.
        /// </summary>
        /// <param name="logId">New ID that will be displayed in Log.</param>
        public void SetLogId(string logId)
        {
            this.logId = logId;
        }
        public bool IsReference()
        {
            return isReference;
        }
        public bool IsAnnotation()
        {
            return isAnnotation;
        }
        public bool IsCustom()
        {
            return isCustom;
        }
        /// <summary>
        /// Checks if count has reached the limit. True for count >= limit.
        /// </summary>
        public bool IsOverLimit()
        {
            return (count >= limit);
        }
    }
}
