using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRT_Logger.View
{
    public partial class PatientDataGui : Form
    {
        bool filePathOk = false;

        public PatientDataGui()
        {
            InitializeComponent();
        }

        private void PatientDataGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public delegate void SetFolderSafely(string patientDataFolder);

        /// <summary>
        /// Sets folder for patient data file.
        /// </summary>
        /// <param name="patientDataFolder">String of a valid folder.</param>
        public void SetPatientDataFolder(string patientDataFolder)
        {
            if (selectedFolderTextBox.InvokeRequired)
            {
                SetFolderSafely d = new SetFolderSafely(SetPatientDataFolder);
                Invoke(d, new object[] { patientDataFolder });
            }
            else
            {
                filePathOk = true;
                selectedFolderTextBox.Text = patientDataFolder;
            }

        }

        /// <summary>
        /// Returns if a valid folder has already been selected.
        /// </summary>
        public bool FilePathOk()
        {
            return filePathOk;
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            if (patientDataFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string fileFolder = patientDataFolderBrowserDialog.SelectedPath;
                string now = DateTime.Now.ToString("ddMMyyyy_HHmmss");

                // If a folder was selected, try creating and deleting a new file
                // to see if the user has the needed permission.
                try
                {
                    var testFile = System.IO.File.Create(fileFolder + @"\" + now + @"_deleteme.txt");
                    testFile.Close();
                    System.IO.File.Delete(fileFolder + @"\" + now + @"_deleteme.txt");
                }
                catch
                {
                    selectedFolderTextBox.Text = "Can't write files to this folder!";
                    selectedFolderTextBox.BackColor = Color.LightSalmon;
                    filePathOk = false;
                    return;
                }
                filePathOk = true;
                selectedFolderTextBox.Text = fileFolder;
                selectedFolderTextBox.SelectionStart = selectedFolderTextBox.TextLength;
                selectedFolderTextBox.ScrollToCaret();
                selectedFolderTextBox.BackColor = SystemColors.Control;
            }
        }

        private void anyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                TextBox textBox = sender as TextBox;
                textBox.SelectAll();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
