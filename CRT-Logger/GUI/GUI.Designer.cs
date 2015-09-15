namespace CRT_Logger
{
    partial class Gui
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tickerToggleButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeToStringButton = new System.Windows.Forms.Button();
            this.clockTimeLabel = new System.Windows.Forms.Label();
            this.testMode1Button = new System.Windows.Forms.Button();
            this.testMode2Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tickerToggleButton
            // 
            this.tickerToggleButton.Location = new System.Drawing.Point(35, 68);
            this.tickerToggleButton.Margin = new System.Windows.Forms.Padding(4);
            this.tickerToggleButton.Name = "tickerToggleButton";
            this.tickerToggleButton.Size = new System.Drawing.Size(100, 28);
            this.tickerToggleButton.TabIndex = 0;
            this.tickerToggleButton.Text = "Ticker toggle";
            this.tickerToggleButton.UseVisualStyleBackColor = true;
            this.tickerToggleButton.Click += new System.EventHandler(this.tickerToggleButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(202, 110);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(69, 17);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "timeLabel";
            // 
            // timeToStringButton
            // 
            this.timeToStringButton.AutoSize = true;
            this.timeToStringButton.Location = new System.Drawing.Point(193, 68);
            this.timeToStringButton.Name = "timeToStringButton";
            this.timeToStringButton.Size = new System.Drawing.Size(164, 27);
            this.timeToStringButton.TabIndex = 2;
            this.timeToStringButton.Text = "time to String";
            this.timeToStringButton.UseVisualStyleBackColor = true;
            this.timeToStringButton.Click += new System.EventHandler(this.timeToStringButton_Click);
            // 
            // clockTimeLabel
            // 
            this.clockTimeLabel.AutoSize = true;
            this.clockTimeLabel.Location = new System.Drawing.Point(32, 110);
            this.clockTimeLabel.Name = "clockTimeLabel";
            this.clockTimeLabel.Size = new System.Drawing.Size(106, 17);
            this.clockTimeLabel.TabIndex = 1;
            this.clockTimeLabel.Text = "clockTimeLabel";
            // 
            // testMode1Button
            // 
            this.testMode1Button.AutoSize = true;
            this.testMode1Button.Location = new System.Drawing.Point(54, 177);
            this.testMode1Button.Name = "testMode1Button";
            this.testMode1Button.Size = new System.Drawing.Size(84, 27);
            this.testMode1Button.TabIndex = 3;
            this.testMode1Button.Text = "testMode1";
            this.testMode1Button.UseVisualStyleBackColor = true;
            this.testMode1Button.Click += new System.EventHandler(this.testMode1Button_Click);
            // 
            // testMode2Button
            // 
            this.testMode2Button.AutoSize = true;
            this.testMode2Button.Location = new System.Drawing.Point(54, 218);
            this.testMode2Button.Name = "testMode2Button";
            this.testMode2Button.Size = new System.Drawing.Size(84, 27);
            this.testMode2Button.TabIndex = 3;
            this.testMode2Button.Text = "testMode2";
            this.testMode2Button.UseVisualStyleBackColor = true;
            this.testMode2Button.Click += new System.EventHandler(this.testMode2Button_Click);
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.testMode2Button);
            this.Controls.Add(this.testMode1Button);
            this.Controls.Add(this.timeToStringButton);
            this.Controls.Add(this.clockTimeLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.tickerToggleButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Gui";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tickerToggleButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button timeToStringButton;
        private System.Windows.Forms.Label clockTimeLabel;
        private System.Windows.Forms.Button testMode1Button;
        private System.Windows.Forms.Button testMode2Button;
    }
}

