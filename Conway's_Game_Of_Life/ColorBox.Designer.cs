namespace Conway_s_Game_Of_Life
{
    partial class ColorBox
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
            if (disposing && (components != null)) {
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
            this.pbColorDialog = new System.Windows.Forms.Button();
            this.tbColorName = new System.Windows.Forms.TextBox();
            this.picbColor = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.lbLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbColor)).BeginInit();
            this.SuspendLayout();
            // 
            // pbColorDialog
            // 
            this.pbColorDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbColorDialog.Location = new System.Drawing.Point(148, 20);
            this.pbColorDialog.Name = "pbColorDialog";
            this.pbColorDialog.Size = new System.Drawing.Size(80, 24);
            this.pbColorDialog.TabIndex = 0;
            this.pbColorDialog.Text = "Изменить";
            this.pbColorDialog.UseVisualStyleBackColor = true;
            this.pbColorDialog.Click += new System.EventHandler(this.pbColorDialog_Click);
            // 
            // tbColorName
            // 
            this.tbColorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbColorName.BackColor = System.Drawing.SystemColors.Window;
            this.tbColorName.Location = new System.Drawing.Point(33, 22);
            this.tbColorName.Name = "tbColorName";
            this.tbColorName.ReadOnly = true;
            this.tbColorName.Size = new System.Drawing.Size(112, 20);
            this.tbColorName.TabIndex = 1;
            this.tbColorName.Text = "(нет)";
            // 
            // picbColor
            // 
            this.picbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picbColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picbColor.Location = new System.Drawing.Point(7, 21);
            this.picbColor.Name = "picbColor";
            this.picbColor.Size = new System.Drawing.Size(22, 22);
            this.picbColor.TabIndex = 2;
            this.picbColor.TabStop = false;
            this.picbColor.Paint += new System.Windows.Forms.PaintEventHandler(this.picbColor_Paint);
            // 
            // lbLabel
            // 
            this.lbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLabel.AutoSize = true;
            this.lbLabel.Location = new System.Drawing.Point(2, 3);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(33, 13);
            this.lbLabel.TabIndex = 4;
            this.lbLabel.Text = "Label";
            // 
            // ColorBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbLabel);
            this.Controls.Add(this.picbColor);
            this.Controls.Add(this.tbColorName);
            this.Controls.Add(this.pbColorDialog);
            this.MaximumSize = new System.Drawing.Size(300, 45);
            this.MinimumSize = new System.Drawing.Size(210, 45);
            this.Name = "ColorBox";
            this.Size = new System.Drawing.Size(230, 45);
            ((System.ComponentModel.ISupportInitialize)(this.picbColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pbColorDialog;
        private System.Windows.Forms.TextBox tbColorName;
        private System.Windows.Forms.PictureBox picbColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lbLabel;
    }
}
