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
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tbInterval = new System.Windows.Forms.TrackBar();
            this.pbRandom = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mbFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mbOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mbLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mbSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mbParams = new System.Windows.Forms.ToolStripMenuItem();
            this.mbColorSchemes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mbAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSpeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbGenerationMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColomns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInterval)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picbGenerationMap
            // 
            this.picbGenerationMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picbGenerationMap.BackColor = System.Drawing.SystemColors.Control;
            this.picbGenerationMap.Location = new System.Drawing.Point(6, 30);
            this.picbGenerationMap.Name = "picbGenerationMap";
            this.picbGenerationMap.Size = new System.Drawing.Size(599, 414);
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
            this.pbStartStop.Location = new System.Drawing.Point(614, 72);
            this.pbStartStop.Name = "pbStartStop";
            this.pbStartStop.Size = new System.Drawing.Size(174, 24);
            this.pbStartStop.TabIndex = 1;
            this.pbStartStop.Text = "Старт";
            this.pbStartStop.UseVisualStyleBackColor = true;
            this.pbStartStop.Click += new System.EventHandler(this.pbStartStop_Click);
            // 
            // nudRows
            // 
            this.nudRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRows.Location = new System.Drawing.Point(614, 46);
            this.nudRows.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            1,
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
            this.nudColomns.Location = new System.Drawing.Point(706, 46);
            this.nudColomns.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudColomns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColomns.Name = "nudColomns";
            this.nudColomns.Size = new System.Drawing.Size(82, 20);
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
            this.lbnudRows.Location = new System.Drawing.Point(611, 30);
            this.lbnudRows.Name = "lbnudRows";
            this.lbnudRows.Size = new System.Drawing.Size(43, 13);
            this.lbnudRows.TabIndex = 3;
            this.lbnudRows.Text = "Строки";
            // 
            // lbnudColomns
            // 
            this.lbnudColomns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbnudColomns.AutoSize = true;
            this.lbnudColomns.Location = new System.Drawing.Point(703, 30);
            this.lbnudColomns.Name = "lbnudColomns";
            this.lbnudColomns.Size = new System.Drawing.Size(51, 13);
            this.lbnudColomns.TabIndex = 3;
            this.lbnudColomns.Text = "Столбцы";
            // 
            // tbInterval
            // 
            this.tbInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInterval.Location = new System.Drawing.Point(614, 115);
            this.tbInterval.Maximum = 400;
            this.tbInterval.Minimum = 50;
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbInterval.Size = new System.Drawing.Size(174, 45);
            this.tbInterval.SmallChange = 10;
            this.tbInterval.TabIndex = 5;
            this.tbInterval.TickFrequency = 40;
            this.tbInterval.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbInterval.Value = 200;
            // 
            // pbRandom
            // 
            this.pbRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRandom.Location = new System.Drawing.Point(624, 201);
            this.pbRandom.Name = "pbRandom";
            this.pbRandom.Size = new System.Drawing.Size(163, 25);
            this.pbRandom.TabIndex = 6;
            this.pbRandom.Text = "Random";
            this.pbRandom.UseVisualStyleBackColor = true;
            this.pbRandom.Click += new System.EventHandler(this.pbRandom_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbFile,
            this.mbParams});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mbFile
            // 
            this.mbFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbOpen,
            this.mbLoad,
            this.mbSaveAs});
            this.mbFile.Name = "mbFile";
            this.mbFile.Size = new System.Drawing.Size(48, 20);
            this.mbFile.Text = "Файл";
            // 
            // mbOpen
            // 
            this.mbOpen.Name = "mbOpen";
            this.mbOpen.Size = new System.Drawing.Size(153, 22);
            this.mbOpen.Text = "Открыть";
            // 
            // mbLoad
            // 
            this.mbLoad.Name = "mbLoad";
            this.mbLoad.Size = new System.Drawing.Size(153, 22);
            this.mbLoad.Text = "Загрузить";
            // 
            // mbSaveAs
            // 
            this.mbSaveAs.Name = "mbSaveAs";
            this.mbSaveAs.Size = new System.Drawing.Size(153, 22);
            this.mbSaveAs.Text = "Сохранить как";
            // 
            // mbParams
            // 
            this.mbParams.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbColorSchemes,
            this.toolStripSeparator1,
            this.mbAbout});
            this.mbParams.Name = "mbParams";
            this.mbParams.Size = new System.Drawing.Size(83, 20);
            this.mbParams.Text = "Параметры";
            // 
            // mbColorSchemes
            // 
            this.mbColorSchemes.Name = "mbColorSchemes";
            this.mbColorSchemes.Size = new System.Drawing.Size(166, 22);
            this.mbColorSchemes.Text = "Цветовые схемы";
            this.mbColorSchemes.Click += new System.EventHandler(this.mbSetitngs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // mbAbout
            // 
            this.mbAbout.Name = "mbAbout";
            this.mbAbout.Size = new System.Drawing.Size(166, 22);
            this.mbAbout.Text = "О программе";
            // 
            // lbSpeed
            // 
            this.lbSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(611, 99);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(55, 13);
            this.lbSpeed.TabIndex = 8;
            this.lbSpeed.Text = "Скорость";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbSpeed);
            this.Controls.Add(this.pbRandom);
            this.Controls.Add(this.tbInterval);
            this.Controls.Add(this.lbnudColomns);
            this.Controls.Add(this.lbnudRows);
            this.Controls.Add(this.nudColomns);
            this.Controls.Add(this.nudRows);
            this.Controls.Add(this.pbStartStop);
            this.Controls.Add(this.picbGenerationMap);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "MainForm";
            this.Text = "Conway\'s game of life";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picbGenerationMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColomns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInterval)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TrackBar tbInterval;
        private System.Windows.Forms.Button pbRandom;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.ToolStripMenuItem mbFile;
        private System.Windows.Forms.ToolStripMenuItem mbOpen;
        private System.Windows.Forms.ToolStripMenuItem mbLoad;
        private System.Windows.Forms.ToolStripMenuItem mbSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mbParams;
        private System.Windows.Forms.ToolStripMenuItem mbColorSchemes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mbAbout;
    }
}

