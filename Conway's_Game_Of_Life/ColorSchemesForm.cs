using System;
using System.Windows.Forms;

namespace Conway_s_Game_Of_Life
{
    public partial class ColorSchemesForm : Form
    {
        private MapRenderer.Style style;

        public MapRenderer.Style Style {
            get => style;
            set {
                style = value;
                colbAliveCellsColor.Color = value.AliveCell.Color;
                colbDeadCellsColor.Color = value.DeadCell.Color;
                colbDeadCellsColor.Color = value.DeadCell.Color;
                colbGridColor.Color = value.Grid.Color;
                if (value.GridIsOn) {
                    rbGridOn.Checked = true;
                    rbGridOff.Checked = false;
                }
                else {
                    rbGridOff.Checked = true;
                    rbGridOn.Checked = false;
                }
                pbGetDefoult.Enabled = !value.DefoultStyle;
                cbUseStyleAtStartup.Enabled = !value.DefoultStyle;
                picbPreview.Refresh();
            }
        }
        Game game;
        MapRenderer.LayoutF layout;

        public ColorSchemesForm(MapRenderer.Style style)
        {
            InitializeComponent();
            game = new Game(3, 3)
            {
                GameMap = new bool[,] { { false, true, false }, { false, false, true }, { true, true, true } }
            };
            Style = style;
            picbPreview.Refresh();
        }

        private void pbOk_Click(object sender, EventArgs e)
        {
            if (!style.DefoultStyle && cbUseStyleAtStartup.Checked) {
                style.GridIsVisible = style.GridIsOn;
                Properties.Settings.Default.gridIsOn = style.GridIsOn;
                Properties.Settings.Default.gridColor = style.Grid.Color;
                Properties.Settings.Default.aliveCellColor = style.AliveCell.Color;
                Properties.Settings.Default.deathCellColor = style.DeadCell.Color;
                Properties.Settings.Default.defoultStyle = style.DefoultStyle;
                Properties.Settings.Default.Save();
            }
            DialogResult = DialogResult.OK;
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void colbAliveCellsColor_ColorChenged(object sender, ColorBox.ColorChengedEventArgs e)
        {
            style.AliveCellColor = e.Color;
            pbGetDefoult.Enabled = true;
            cbUseStyleAtStartup.Enabled = true;
            style.DefoultStyle = false;
            picbPreview.Refresh();
        }

        private void colbDeadCellsColor_ColorChenged(object sender, ColorBox.ColorChengedEventArgs e)
        {
            style.DeadCellColor = e.Color;
            pbGetDefoult.Enabled = true;
            cbUseStyleAtStartup.Enabled = true;
            style.DefoultStyle = false;
            picbPreview.Refresh();
        }

        private void colbGridColor_ColorChenged(object sender, ColorBox.ColorChengedEventArgs e)
        {
            style.GridColor = e.Color;
            pbGetDefoult.Enabled = true;
            cbUseStyleAtStartup.Enabled = true;
            style.DefoultStyle = false;
            picbPreview.Refresh();
        }

        private void pbGetDefoult_Click(object sender, EventArgs e)
        {
            Style = DefoultStyle();
            cbUseStyleAtStartup.Enabled = false;
            cbUseStyleAtStartup.Checked = false;
        }

        // перенести в класс с файлами
        private MapRenderer.Style DefoultStyle()
        {
            Properties.Settings.Default.Reset();
            MapRenderer.Style result = new MapRenderer.Style()
            {
                GridIsOn = Properties.Settings.Default.gridIsOn,
                GridColor = Properties.Settings.Default.gridColor,
                AliveCellColor = Properties.Settings.Default.aliveCellColor,
                DeadCellColor = Properties.Settings.Default.deathCellColor,
                DefoultStyle = Properties.Settings.Default.defoultStyle
            };
            return result;
        }

        private void rbGridOn_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.Equals(rbGridOff)) {
                style.GridIsOn = false;
                style.GridIsVisible = false;
            }
            if (sender.Equals(rbGridOn)) {
                style.GridIsOn = true;
                style.GridIsVisible = true;
            }
            style.DefoultStyle = false;
            pbGetDefoult.Enabled = true;
            cbUseStyleAtStartup.Enabled = true;
            picbPreview.Refresh();
        }

        private void picbPreview_Paint(object sender, PaintEventArgs e)
        {

            layout = MapRenderer.LayoutSetupF(picbPreview, game, ref style);
            MapRenderer.RenderMapF(e.Graphics, game, layout, style);
        }
    }
}
