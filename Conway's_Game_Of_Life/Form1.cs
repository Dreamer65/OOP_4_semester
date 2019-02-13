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
        private Game game;
        private MapRenderer.VisualConfig style;
        private MapRenderer.LayoutF layout;

        public MainForm()
        {
            InitializeComponent();
            isNewMap = true;
            game = new Game((int)nudRows.Value, (int)nudColomns.Value);
            game.GameMap = RandomMap(game.RowsCount, game.ColomnsCount);
            style = new MapRenderer.VisualConfig()
            {
                isGridOn = Properties.Settings.Default.gridThickness,
                gridColor = Properties.Settings.Default.gridColor,
                aliveCellColor = Properties.Settings.Default.aliveCellColor,
                deathCellColor = Properties.Settings.Default.deathCellColor
            };
            layout = MapRenderer.LayoutSetupF(picbGenerationMap, game, style);
        }

        private void pbStartStop_Click(object sender, EventArgs e)
        {
            game.NextGeneration();
            Refresh();
        }

        private void picbGenerationMap_MouseMove(object sender, MouseEventArgs e)
        {/*
            Graphics g = picbGenerationMap.CreateGraphics();
            switch(e.Button) {
                case MouseButtons.Left : {
                        g.FillRectangle(new SolidBrush(Color.Black), new RectangleF(e.Location, new Size(1, 1)));
                        break;
                    }
                case MouseButtons.Right: {
                        //g.Clear(Color.White);
                        break;
                    }*/
            }

        private void picbGenerationMap_MouseUp(object sender, MouseEventArgs e)
        {
            try {
                Point location = MapRenderer.RelativeLocationF(layout, style, e.Location);
                game[location] = !game[location];
                Refresh();
            }
            catch { }
        }

        private void picbGenerationMap_Paint(object sender, PaintEventArgs e)
        {
            MapRenderer.RenderMapF(e.Graphics, game, layout, style);

        }

        private static bool[,] RandomMap(int rows, int colomns)
        {
            bool[,] result = new bool[rows, colomns];
            Random random = new Random();
            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++) {
                    if (random.Next() % 2 == 0)
                        result[i, j] = true;
                }
            return result;
        }

        private void picbGenerationMap_Resize(object sender, EventArgs e)
        {
            layout = MapRenderer.LayoutSetupF((PictureBox)sender, game, style);
            Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            style.isGridOn = ((CheckBox)sender).Checked;
            layout = MapRenderer.LayoutSetupF(picbGenerationMap, game, style);
            Refresh();
        }
    }
}
