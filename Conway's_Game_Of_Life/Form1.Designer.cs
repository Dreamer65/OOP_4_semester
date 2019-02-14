namespace Conway_s_Game_Of_Life
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.picbGenerationMap = new System.Windows.Forms.PictureBox();
            this.pbStartStop = new System.Windows.Forms.Button();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.nudColomns = new System.Windows.Forms.NumericUpDown();
            this.lbnudRows = new System.Windows.Forms.Label();
            this.lbnudColomns = new System.Windows.Forms.Label();
            this.savefdMap = new System.Windows.Forms.SaveFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbInterval = new System.Windows.Forms.TrackBar();
            this.pbRandom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbGenerationMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColomns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // picbGenerationMap
            // 
            this.picbGenerationMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picbGenerationMap.BackColor = System.Drawing.SystemColors.Control;
            this.picbGenerationMap.Location = new System.Drawing.Point(12, 12);
            this.picbGenerationMap.Name = "picbGenerationMap";
            this.picbGenerationMap.Size = new System.Drawing.Size(587, 426);
            this.picbGenerationMap.TabIndex = 0;
            this.picbGenerationMap.TabStop = false;
            this.picbGenerationMap.Paint += new System.Windows.Forms.PaintEventHandler(this.picbGenerationMap_Paint);
            this.picbGenerationMap.MouseEnter += new System.EventHandler(this.picbGenerationMap_MouseLeave);
            this.picbGenerationMap.MouseLeave += new System.EventHandler(this.picbGenerationMap_MouseLeave);
            this.picbGenerationMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbGenerationMap_MouseMove);
            this.picbGenerationMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbGenerationMap_MouseUp);
            this.picbGenerationMap.Resize += new System.EventHandler(this.picbGenerationMap_Resize);
            // 
            // pbStartStop
            // 
            this.pbStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStartStop.Location = new System.Drawing.Point(614, 54);
            this.pbStartStop.Name = "pbStartStop";
            this.pbStartStop.Size = new System.Drawing.Size(173, 24);
            this.pbStartStop.TabIndex = 1;
            this.pbStartStop.Text = "Старт";
            this.pbStartStop.UseVisualStyleBackColor = true;
            this.pbStartStop.Click += new System.EventHandler(this.pbStartStop_Click);
            // 
            // nudRows
            // 
            this.nudRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRows.Location = new System.Drawing.Point(614, 28);
            this.nudRows.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(86, 20);
            this.nudRows.TabIndex = 2;
            this.nudRows.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRows.ValueChanged += new System.EventHandler(this.nudColomns_ValueChanged);
            // 
            // nudColomns
            // 
            this.nudColomns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudColomns.Location = new System.Drawing.Point(706, 28);
            this.nudColomns.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudColomns.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudColomns.Name = "nudColomns";
            this.nudColomns.Size = new System.Drawing.Size(81, 20);
            this.nudColomns.TabIndex = 2;
            this.nudColomns.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudColomns.ValueChanged += new System.EventHandler(this.nudColomns_ValueChanged);
            // 
            // lbnudRows
            // 
            this.lbnudRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbnudRows.AutoSize = true;
            this.lbnudRows.Location = new System.Drawing.Point(611, 12);
            this.lbnudRows.Name = "lbnudRows";
            this.lbnudRows.Size = new System.Drawing.Size(43, 13);
            this.lbnudRows.TabIndex = 3;
            this.lbnudRows.Text = "Строки";
            // 
            // lbnudColomns
            // 
            this.lbnudColomns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbnudColomns.AutoSize = true;
            this.lbnudColomns.Location = new System.Drawing.Point(703, 12);
            this.lbnudColomns.Name = "lbnudColomns";
            this.lbnudColomns.Size = new System.Drawing.Size(51, 13);
            this.lbnudColomns.TabIndex = 3;
            this.lbnudColomns.Text = "Столбцы";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(620, 100);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tbInterval
            // 
            this.tbInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInterval.Location = new System.Drawing.Point(614, 132);
            this.tbInterval.Maximum = 400;
            this.tbInterval.Minimum = 50;
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(179, 45);
            this.tbInterval.SmallChange = 10;
            this.tbInterval.TabIndex = 5;
            this.tbInterval.TickFrequency = 40;
            this.tbInterval.Value = 200;
            // 
            // pbRandom
            // 
            this.pbRandom.Location = new System.Drawing.Point(624, 183);
            this.pbRandom.Name = "pbRandom";
            this.pbRandom.Size = new System.Drawing.Size(163, 25);
            this.pbRandom.TabIndex = 6;
            this.pbRandom.Text = "Random";
            this.pbRandom.UseVisualStyleBackColor = true;
            this.pbRandom.Click += new System.EventHandler(this.pbRandom_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbRandom);
            this.Controls.Add(this.tbInterval);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lbnudColomns);
            this.Controls.Add(this.lbnudRows);
            this.Controls.Add(this.nudColomns);
            this.Controls.Add(this.nudRows);
            this.Controls.Add(this.pbStartStop);
            this.Controls.Add(this.picbGenerationMap);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picbGenerationMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColomns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picbGenerationMap;
        private System.Windows.Forms.Button pbStartStop;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.NumericUpDown nudColomns;
        private System.Windows.Forms.Label lbnudRows;
        private System.Windows.Forms.Label lbnudColomns;
        private System.Windows.Forms.SaveFileDialog savefdMap;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TrackBar tbInterval;
        private System.Windows.Forms.Button pbRandom;
    }
}

