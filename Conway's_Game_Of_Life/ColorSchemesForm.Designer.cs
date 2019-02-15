﻿namespace Conway_s_Game_Of_Life
{
    partial class ColorSchemesForm
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
            this.gbGrid = new System.Windows.Forms.GroupBox();
            this.rbGridOn = new System.Windows.Forms.RadioButton();
            this.rbGridOff = new System.Windows.Forms.RadioButton();
            this.cbGridColor = new Conway_s_Game_Of_Life.ColorBox();
            this.pbSetDefoult = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pbCancel = new System.Windows.Forms.Button();
            this.pbGetDefoult = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbPreview)).BeginInit();
            this.gbGrid.SuspendLayout();
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
            // gbGrid
            // 
            this.gbGrid.Controls.Add(this.rbGridOn);
            this.gbGrid.Controls.Add(this.rbGridOff);
            this.gbGrid.Controls.Add(this.cbGridColor);
            this.gbGrid.Location = new System.Drawing.Point(213, 114);
            this.gbGrid.Name = "gbGrid";
            this.gbGrid.Size = new System.Drawing.Size(255, 93);
            this.gbGrid.TabIndex = 3;
            this.gbGrid.TabStop = false;
            this.gbGrid.Text = "Настройки сетки";
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
            // pbSetDefoult
            // 
            this.pbSetDefoult.Location = new System.Drawing.Point(125, 213);
            this.pbSetDefoult.Name = "pbSetDefoult";
            this.pbSetDefoult.Size = new System.Drawing.Size(152, 23);
            this.pbSetDefoult.TabIndex = 4;
            this.pbSetDefoult.Text = "Установить по умолчанию";
            this.pbSetDefoult.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(305, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pbCancel
            // 
            this.pbCancel.Location = new System.Drawing.Point(389, 213);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(79, 23);
            this.pbCancel.TabIndex = 4;
            this.pbCancel.Text = "Отмена";
            this.pbCancel.UseVisualStyleBackColor = true;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // pbGetDefoult
            // 
            this.pbGetDefoult.Location = new System.Drawing.Point(12, 213);
            this.pbGetDefoult.Name = "pbGetDefoult";
            this.pbGetDefoult.Size = new System.Drawing.Size(94, 23);
            this.pbGetDefoult.TabIndex = 5;
            this.pbGetDefoult.Text = "По умолчанию";
            this.pbGetDefoult.UseVisualStyleBackColor = true;
            this.pbGetDefoult.Click += new System.EventHandler(this.pbGetDefoult_Click);
            // 
            // ColorSchemesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 247);
            this.Controls.Add(this.pbGetDefoult);
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pbSetDefoult);
            this.Controls.Add(this.gbGrid);
            this.Controls.Add(this.cbDeadCellsColor);
            this.Controls.Add(this.cbAliveCellsColor);
            this.Controls.Add(this.picbPreview);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximumSize = new System.Drawing.Size(494, 286);
            this.MinimumSize = new System.Drawing.Size(494, 286);
            this.Name = "ColorSchemesForm";
            this.Text = "Цветовые схемы";
            ((System.ComponentModel.ISupportInitialize)(this.picbPreview)).EndInit();
            this.gbGrid.ResumeLayout(false);
            this.gbGrid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picbPreview;
        private ColorBox cbAliveCellsColor;
        private ColorBox cbDeadCellsColor;
        private System.Windows.Forms.GroupBox gbGrid;
        private System.Windows.Forms.RadioButton rbGridOn;
        private System.Windows.Forms.RadioButton rbGridOff;
        private ColorBox cbGridColor;
        private System.Windows.Forms.Button pbSetDefoult;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button pbCancel;
        private System.Windows.Forms.Button pbGetDefoult;
    }
}