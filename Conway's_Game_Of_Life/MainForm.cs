#undef DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conway_s_Game_Of_Life
{
    public partial class MainForm : Form
    {
        private delegate void RefreshForm();
        private delegate void IntervalValue(Interval value);

        private readonly string[] pbStartStopStatus = { "Старт", "Стоп", "Продолжить" };
        private bool mapSizeChenged;

        private Game game;
        private MapRenderer.Style style;
        private MapRenderer.LayoutF layout;

        private Thread tickGenerator;
        private ManualResetEventSlim threadSync = new ManualResetEventSlim(false);
        private ManualResetEventSlim refreshSync = new ManualResetEventSlim(true);

        private DialogResult dialogAlreadyShown;

        // DEBUG
        private Label DEBUG_STATUS = new Label();
        //

        private class Interval
        {
            public int Value { get; set; }
        }

        public MainForm()
        {
            InitializeComponent();
#if !DEBUG
            DEBUG_STATUS.Location = new Point(615, 400);
            DEBUG_STATUS.Anchor = pbStartStop.Anchor;
            DEBUG_STATUS.AutoSize = true;
            this.Controls.Add(DEBUG_STATUS);
#endif
            mapSizeChenged = true;
            game = new Game((int)nudRows.Value, (int)nudColomns.Value);
            game.Random();
            style = new MapRenderer.Style()
            {
                GridIsOn = Properties.Settings.Default.gridIsOn,
                GridIsVisible = style.GridIsOn,
                GridColor = Properties.Settings.Default.gridColor,
                AliveCellColor = Properties.Settings.Default.aliveCellColor,
                DeadCellColor = Properties.Settings.Default.deathCellColor,
                DefoultStyle = Properties.Settings.Default.defoultStyle
            };
            layout = MapRenderer.LayoutSetupF(picbGenerationMap, game, ref style);
            style.mousePos = new Point(-1, -1);
            tickGenerator = new Thread(ThreadTickGenerator);
            tickGenerator.Start();

            mapSizeChenged = false;
        }

        private void pbStartStop_Click(object sender, EventArgs e)
        {
            dialogAlreadyShown = 0;
            if (!threadSync.IsSet) {
                pbStartStop.Text = pbStartStopStatus[1];
                nudColomns.Enabled = false;
                nudRows.Enabled = false;
                threadSync.Set();
            }
            else {
                pbStartStop.Text = pbStartStopStatus[2];
                nudColomns.Enabled = true;
                nudRows.Enabled = true;
                threadSync.Reset();
            }
        }

        private void picbGenerationMap_MouseMove(object sender, MouseEventArgs e)
        {

#if !DEBUG
            DEBUG_STATUS.Text = e.Location.ToString();
#endif
            if (mapSizeChenged)
                return;
            try {
                style.mousePos = MapRenderer.RelativeLocationF(layout, style, e.Location);
#if !DEBUG
                DEBUG_STATUS.Text += style.mousePos.ToString();
#endif
                if (style.mousePos.X < 0 || style.mousePos.Y < 0)
                    style.mousePos = new Point(-1, -1);
                if (style.mousePos.X >= game.ColomnsCount || style.mousePos.Y >= game.RowsCount)
                    style.mousePos = new Point(-1, -1);
                picbGenerationMap.Refresh();
            }
            catch { }
        }


        private void picbGenerationMap_MouseLeave(object sender, EventArgs e)
        {
            style.mousePos = new Point(-1, -1);
            picbGenerationMap.Refresh();
        }
        private void picbGenerationMap_MouseUp(object sender, MouseEventArgs e)
        {
            try {
                Point location = MapRenderer.RelativeLocationF(layout, style, e.Location);
                game[location] = !game[location];
                picbGenerationMap.Refresh();
            }
            catch { }
        }

        private void picbGenerationMap_Paint(object sender, PaintEventArgs e)
        {
            
            MapRenderer.RenderMapF(e.Graphics, game, layout, style);
            refreshSync.Wait();
            if (threadSync.IsSet && game.State != Game.GameStates.Alive) {
                switch (game.State) {
                    case Game.GameStates.Dead: {
                            threadSync.Reset();
                            dialogAlreadyShown = MessageBox.Show(Properties.Settings.Default.colonyIsDeadMessage);
                            break;
                        }
                    case Game.GameStates.Loop: {
                            threadSync.Reset();
                            dialogAlreadyShown = MessageBox.Show(Properties.Settings.Default.colonyIsLoopMessage);
                            break;
                        }
                    case Game.GameStates.Stable: {
                            threadSync.Reset();
                            dialogAlreadyShown = MessageBox.Show(Properties.Settings.Default.colonyIsStableMessage);
                            break;
                        }
                }
                pbStartStop.Text = pbStartStopStatus[0];
            }
        }


        private void picbGenerationMap_Resize(object sender, EventArgs e)
        {
            layout = MapRenderer.LayoutSetupF((PictureBox)sender, game, ref style);
            picbGenerationMap.Refresh();
        }

        private void IntervalMetod(Interval value)
        {
            value.Value = tbInterval.Value;
        }

        private void ThreadTickGenerator()
        {
            Interval interval = new Interval();
            while (true) {
                threadSync.Wait(); // Без этого прерывания потока может возникнуть ошибка BeginInvoke связанная с дескриптором окна
                BeginInvoke(new IntervalValue(IntervalMetod), interval);
                Thread.Sleep(interval.Value);
                refreshSync.Wait();
                threadSync.Wait(); // Повторное прерывание для более быстрой остановки
                refreshSync.Reset();
                game.NextGeneration();
                refreshSync.Set();
                BeginInvoke(new RefreshForm(Refresh));
            }

        }
        
        private void nudColomns_ValueChanged(object sender, EventArgs e)
        {
            mapSizeChenged = true;
            game = new Game((int)nudRows.Value, (int)nudColomns.Value);
            pbStartStop.Text = pbStartStopStatus[0];
            layout = MapRenderer.LayoutSetupF(picbGenerationMap, game, ref style);
            picbGenerationMap.Refresh();
            mapSizeChenged = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tickGenerator.Abort();
        }

        private void pbRandom_Click(object sender, EventArgs e)
        {
            game.Random();
            picbGenerationMap.Refresh();
            pbStartStop.Text = pbStartStopStatus[0]; 
        }

        private void mbSetitngs_Click(object sender, EventArgs e)
        {
            ColorSchemesForm config = new ColorSchemesForm(style);
            if (config.ShowDialog() != DialogResult.OK)
                return;
            style = config.Style;
            layout = MapRenderer.LayoutSetupF(picbGenerationMap, game, ref style);
            picbGenerationMap.Refresh();
        }

        private void mbSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            GameFile.SaveGameMap(saveFileDialog.FileName, game);
        }

        private void mbLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            Game newgame = GameFile.LoadGameMap(openFileDialog.FileName);
            nudRows.Value = newgame.RowsCount;
            nudColomns.Value = newgame.ColomnsCount;
            game = newgame;
            layout = MapRenderer.LayoutSetupF(picbGenerationMap, game, ref style);
            picbGenerationMap.Refresh();
        }
    }
}
