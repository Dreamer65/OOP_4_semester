namespace Conway_s_Game_Of_Life
{
    partial class StyleConfigForm
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
            if (disposing && (components != null)) {
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
            this.picbPreview = new System.Windows.Forms.PictureBox();
            this.cbAliveCellsColor = new Conway_s_Game_Of_Life.ColorBox();
            this.cbDeadCellsColor = new Conway_s_Game_Of_Life.ColorBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbGridColor = new Conway_s_Game_Of_Life.ColorBox();
            this.rbGridOff = new System.Windows.Forms.RadioButton();
            this.rbGridOn = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picbPreview
            // 
            this.picbPreview.Location = new System.Drawing.Point(12, 12);
            this.picbPreview.Name = "picbPreview";
            this.picbPreview.Size = new System.Drawing.Size(195, 195);
            this.picbPreview.TabIndex = 0;
            this.picbPreview.TabStop = false;
            // 
            // cbAliveCellsColor
            // 
            this.cbAliveCellsColor.Color = System.Drawing.Color.Empty;
            this.cbAliveCellsColor.Labeled = true;
            this.cbAliveCellsColor.LabelText = "Цвет живых клеток:";
            this.cbAliveCellsColor.Location = new System.Drawing.Point(213, 12);
            this.cbAliveCellsColor.MaximumSize = new System.Drawing.Size(300, 45);
            this.cbAliveCellsColor.MinimumSize = new System.Drawing.Size(210, 45);
            this.cbAliveCellsColor.Name = "cbAliveCellsColor";
            this.cbAliveCellsColor.Size = new System.Drawing.Size(255, 45);
            this.cbAliveCellsColor.TabIndex = 1;
            // 
            // cbDeadCellsColor
            // 
            this.cbDeadCellsColor.Color = System.Drawing.Color.Empty;
            this.cbDeadCellsColor.Labeled = true;
            this.cbDeadCellsColor.LabelText = "Цвет мертвых клеток:";
            this.cbDeadCellsColor.Location = new System.Drawing.Point(213, 63);
            this.cbDeadCellsColor.MaximumSize = new System.Drawing.Size(300, 45);
            this.cbDeadCellsColor.MinimumSize = new System.Drawing.Size(210, 45);
            this.cbDeadCellsColor.Name = "cbDeadCellsColor";
            this.cbDeadCellsColor.Size = new System.Drawing.Size(255, 45);
            this.cbDeadCellsColor.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbGridOn);
            this.groupBox1.Controls.Add(this.rbGridOff);
            this.groupBox1.Controls.Add(this.cbGridColor);
            this.groupBox1.Location = new System.Drawing.Point(213, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 93);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки сетки";
            // 
            // cbGridColor
            // 
            this.cbGridColor.Color = System.Drawing.Color.Empty;
            this.cbGridColor.Enabled = false;
            this.cbGridColor.Labeled = false;
            this.cbGridColor.LabelText = "Label";
            this.cbGridColor.Location = new System.Drawing.Point(26, 53);
            this.cbGridColor.MaximumSize = new System.Drawing.Size(300, 27);
            this.cbGridColor.MinimumSize = new System.Drawing.Size(210, 27);
            this.cbGridColor.Name = "cbGridColor";
            this.cbGridColor.Size = new System.Drawing.Size(223, 27);
            this.cbGridColor.TabIndex = 0;
            // 
            // rbGridOff
            // 
            this.rbGridOff.AutoSize = true;
            this.rbGridOff.Checked = true;
            this.rbGridOff.Location = new System.Drawing.Point(9, 26);
            this.rbGridOff.Name = "rbGridOff";
            this.rbGridOff.Size = new System.Drawing.Size(55, 17);
            this.rbGridOff.TabIndex = 1;
            this.rbGridOff.TabStop = true;
            this.rbGridOff.Text = "Выкл.";
            this.rbGridOff.UseVisualStyleBackColor = true;
            // 
            // rbGridOn
            // 
            this.rbGridOn.AutoSize = true;
            this.rbGridOn.Location = new System.Drawing.Point(9, 60);
            this.rbGridOn.Name = "rbGridOn";
            this.rbGridOn.Size = new System.Drawing.Size(14, 13);
            this.rbGridOn.TabIndex = 2;
            this.rbGridOn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // StyleConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 247);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbDeadCellsColor);
            this.Controls.Add(this.cbAliveCellsColor);
            this.Controls.Add(this.picbPreview);
            this.Name = "StyleConfigForm";
            this.Text = "Цветовые схемы";
            this.Load += new System.EventHandler(this.StyleConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picbPreview;
        private ColorBox cbAliveCellsColor;
        private ColorBox cbDeadCellsColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbGridOn;
        private System.Windows.Forms.RadioButton rbGridOff;
        private ColorBox cbGridColor;
        private System.Windows.Forms.Button button1;
    }
}