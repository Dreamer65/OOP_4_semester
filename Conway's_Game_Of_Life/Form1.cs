using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conway_s_Game_Of_Life
{
    public partial class MainForm : Form
    {
        private readonly string[] pbStartStopStatus = { "Старт", "Стоп", "Продолжить" };
        private bool isNewMap;
        public MainForm()
        {
            InitializeComponent();
            isNewMap = true;
        }

        private void pbStartStop_Click(object sender, EventArgs e)
        {
            MessageBox.Show((-1 % 3).ToString());
        }
    }
}
