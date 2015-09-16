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
            this.modeAV40Button = new System.Windows.Forms.Button();
            this.modeAV80Button = new System.Windows.Forms.Button();
            this.modeAV40Label = new System.Windows.Forms.Label();
            this.modeAV80Label = new System.Windows.Forms.Label();
            this.modeIdleButton = new System.Windows.Forms.Button();
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
            // modeAV40Button
            // 
            this.modeAV40Button.AutoSize = true;
            this.modeAV40Button.Location = new System.Drawing.Point(54, 177);
            this.modeAV40Button.Name = "modeAV40Button";
            this.modeAV40Button.Size = new System.Drawing.Size(84, 27);
            this.modeAV40Button.TabIndex = 3;
            this.modeAV40Button.Text = "AV 40";
            this.modeAV40Button.UseVisualStyleBackColor = true;
            this.modeAV40Button.Click += new System.EventHandler(this.modeAV40Button_Click);
            // 
            // modeAV80Button
            // 
            this.modeAV80Button.AutoSize = true;
            this.modeAV80Button.Location = new System.Drawing.Point(54, 218);
            this.modeAV80Button.Name = "modeAV80Button";
            this.modeAV80Button.Size = new System.Drawing.Size(84, 27);
            this.modeAV80Button.TabIndex = 3;
            this.modeAV80Button.Text = "AV 80";
            this.modeAV80Button.UseVisualStyleBackColor = true;
            this.modeAV80Button.Click += new System.EventHandler(this.modeAV80Button_Click);
            // 
            // modeAV40Label
            // 
            this.modeAV40Label.AutoSize = true;
            this.modeAV40Label.Location = new System.Drawing.Point(157, 186);
            this.modeAV40Label.Name = "modeAV40Label";
            this.modeAV40Label.Size = new System.Drawing.Size(16, 17);
            this.modeAV40Label.TabIndex = 4;
            this.modeAV40Label.Text = "0";
            // 
            // modeAV80Label
            // 
            this.modeAV80Label.AutoSize = true;
            this.modeAV80Label.Location = new System.Drawing.Point(157, 228);
            this.modeAV80Label.Name = "modeAV80Label";
            this.modeAV80Label.Size = new System.Drawing.Size(16, 17);
            this.modeAV80Label.TabIndex = 4;
            this.modeAV80Label.Text = "0";
            // 
            // modeIdleButton
            // 
            this.modeIdleButton.AutoSize = true;
            this.modeIdleButton.Location = new System.Drawing.Point(54, 144);
            this.modeIdleButton.Name = "modeIdleButton";
            this.modeIdleButton.Size = new System.Drawing.Size(285, 27);
            this.modeIdleButton.TabIndex = 3;
            this.modeIdleButton.Text = "Idle Mode";
            this.modeIdleButton.UseVisualStyleBackColor = true;
            this.modeIdleButton.Click += new System.EventHandler(this.modeIdleButton_Click);
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.modeAV80Label);
            this.Controls.Add(this.modeAV40Label);
            this.Controls.Add(this.modeAV80Button);
            this.Controls.Add(this.modeIdleButton);
            this.Controls.Add(this.modeAV40Button);
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
        private System.Windows.Forms.Button modeAV40Button;
        private System.Windows.Forms.Button modeAV80Button;
        private System.Windows.Forms.Label modeAV40Label;
        private System.Windows.Forms.Label modeAV80Label;
        private System.Windows.Forms.Button modeIdleButton;
    }
}

