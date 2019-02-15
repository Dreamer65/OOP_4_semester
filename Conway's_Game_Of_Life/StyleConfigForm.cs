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
    public partial class StyleConfigForm : Form
    {
        public MapRenderer.Style Style { get; set; }

        public StyleConfigForm()
        {
            InitializeComponent();
        }

        private void StyleConfigForm_Load(object sender, EventArgs e)
        {
        }
    }
}
