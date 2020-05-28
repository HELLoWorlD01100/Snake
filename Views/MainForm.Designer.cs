namespace Snake.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playingControl = new Snake.Views.PlayingControl();
            this.startControl = new Snake.Views.StartControl();
            this.finishedControl = new Snake.Views.FinishedControl();
            this.SuspendLayout();
            // 
            // playingControl
            // 
            this.playingControl.BackColor = System.Drawing.SystemColors.Control;
            this.playingControl.Location = new System.Drawing.Point(2, 0);
            this.playingControl.Name = "playingControl";
            this.playingControl.Size = new System.Drawing.Size(500, 500);
            this.playingControl.TabIndex = 1;
            // 
            // startControl
            // 
            this.startControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.startControl.Location = new System.Drawing.Point(2, 0);
            this.startControl.Name = "startControl";
            this.startControl.Size = new System.Drawing.Size(500, 500);
            this.startControl.TabIndex = 0;
            // 
            // finishedControl
            // 
            this.finishedControl.BackColor = System.Drawing.SystemColors.Control;
            this.finishedControl.Location = new System.Drawing.Point(2, 0);
            this.finishedControl.Name = "finishedControl";
            this.finishedControl.Size = new System.Drawing.Size(500, 500);
            this.finishedControl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 481);
            this.Controls.Add(this.finishedControl);
            this.Controls.Add(this.playingControl);
            this.Controls.Add(this.startControl);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private StartControl startControl;
        private PlayingControl playingControl;
        private FinishedControl finishedControl;
    }
}