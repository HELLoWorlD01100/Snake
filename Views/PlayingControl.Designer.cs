namespace Snake.Views
{
    partial class PlayingControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayingControl));
            this.ScoreBoard = new System.Windows.Forms.Label();
            this.fieldControl1 = new Snake.Views.FieldControl();
            this.SuspendLayout();
            // 
            // ScoreBoard
            // 
            this.ScoreBoard.AutoSize = true;
            this.ScoreBoard.BackColor = System.Drawing.Color.Transparent;
            this.ScoreBoard.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoreBoard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ScoreBoard.Location = new System.Drawing.Point(341, 25);
            this.ScoreBoard.MinimumSize = new System.Drawing.Size(100, 50);
            this.ScoreBoard.Name = "ScoreBoard";
            this.ScoreBoard.Size = new System.Drawing.Size(122, 50);
            this.ScoreBoard.TabIndex = 1;
            this.ScoreBoard.Text = "Счёт: 0\r\n\r\n";
            // 
            // fieldControl1
            // 
            this.fieldControl1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fieldControl1.Location = new System.Drawing.Point(6, 3);
            this.fieldControl1.Name = "fieldControl1";
            this.fieldControl1.Size = new System.Drawing.Size(329, 327);
            this.fieldControl1.TabIndex = 2;
            // 
            // PlayingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.fieldControl1);
            this.Controls.Add(this.ScoreBoard);
            this.DoubleBuffered = true;
            this.Name = "PlayingControl";
            this.Size = new System.Drawing.Size(500, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private FieldControl fieldControl1;
        private System.Windows.Forms.Label ScoreBoard;
        private FieldControl fieldControl1;
    }
}
