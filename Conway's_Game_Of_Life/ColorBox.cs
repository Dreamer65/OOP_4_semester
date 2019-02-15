using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conway_s_Game_Of_Life
{
    public partial class ColorBox : UserControl
    {
        /// <summary>
        /// Предоставляет данные для события <code>ColorBox.ColorChenged</code>
        /// </summary>
        public class ColorChengedEventArgs : EventArgs
        {
            public Color Color { get; set; }
        }

        /// <summary>
        /// Событие возникает, когда изменяется свойство Color объекта.
        /// </summary>
        public event EventHandler<ColorChengedEventArgs> ColorChenged;

        private Color color;
        public Color Color {
            get => color;
            set {
                color = value;
                tbColorName.Text = (color.ToKnownColor() != 0) ? color.ToKnownColor().ToString() : "#" + color.Name.ToString().ToUpper();
                colorDialog.Color = color;
                picbColor.Refresh();
                if (ColorChenged != null) {
                    ColorChengedEventArgs e = new ColorChengedEventArgs();
                    e.Color = color;
                    ColorChenged(this, e);
                }
            }
        }

        public string LabelText { get => lbLabel.Text; set => lbLabel.Text = value; }

        private bool isLabeled = true;
        public bool Labeled {
            get => isLabeled;
            set {
                isLabeled = value;
                if (value) {
                    this.MinimumSize = new Size(this.MinimumSize.Width, 45);
                    this.MaximumSize = new Size(this.MaximumSize.Width, 45);
                    lbLabel.Visible = true;
                }
                else {

                    this.MinimumSize = new Size(this.MinimumSize.Width, 27);
                    this.MaximumSize = new Size(this.MaximumSize.Width, 27);
                    lbLabel.Visible = false;
                }
            }
        }


        public ColorBox()
        {
            InitializeComponent();
        }


        private void pbColorDialog_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            Color = colorDialog.Color;
        }

        private void picbColor_Paint(object sender, PaintEventArgs e)
        {
            if (color == null)
                return;
            e.Graphics.Clear(color);
        }
    }
}
