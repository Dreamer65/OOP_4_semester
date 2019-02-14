
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Conway_s_Game_Of_Life
{
    static class MapRenderer
    {
        public struct VisualConfig
        {
            public bool gridIsOn;
            public bool gridIsVisible;
            public Color gridColor;
            public Color aliveCellColor;
            public Color deadCellColor;
            private const int invert = 60;

            public Color MouseAlive
            {
                get => Color.FromArgb(aliveCellColor.A, Math.Abs(invert - aliveCellColor.R)%255,
                    Math.Abs(invert -+ aliveCellColor.G) % 255, Math.Abs(invert - aliveCellColor.B) % 255);
            }
            public Color MouseDead
            {
                get => Color.FromArgb(deadCellColor.A, Math.Abs(invert - deadCellColor.R) % 255,
                    Math.Abs(invert - deadCellColor.G) % 255, Math.Abs(invert - deadCellColor.B) % 255);
            }

            public Color this[bool cellStatus]
            {
                get => (cellStatus) ? aliveCellColor : deadCellColor;
            }

        }
        
        public struct LayoutF
        {
            public SizeF cellSize;
            public SizeF mapSize;
            public PointF zeroPivot;
            public Point mousePos;
        }

        private static int Grid(bool status) => (status) ? 1 : 0;
        
        private static PointF RealLocationF(LayoutF layout, VisualConfig style, int row, int colomn)
        {
            int grid = Grid(style.gridIsVisible);
            PointF result = new PointF((grid + layout.cellSize.Width) * colomn + grid,
                (grid + layout.cellSize.Height) * row + grid);
            result.X += layout.zeroPivot.X - grid;
            result.Y += layout.zeroPivot.Y - grid;
            return result;
        }

        private static PointF RealLocationF(LayoutF layout, VisualConfig style, Point cellLocation)
        {
            int grid = Grid(style.gridIsVisible);
            PointF result = new PointF((grid + layout.cellSize.Width) * cellLocation.X + grid,
                (grid + layout.cellSize.Height) * cellLocation.Y + grid);
            result.X += layout.zeroPivot.X;
            result.Y += layout.zeroPivot.Y;
            return result;
        }

        public static Point RelativeLocationF(LayoutF layout, VisualConfig style, Point location)
        {
            int grid = Grid(style.gridIsVisible);
            int x = (int)((location.X - layout.zeroPivot.X - grid) / (grid + layout.cellSize.Width));
            int y = (int)((location.Y - layout.zeroPivot.Y - grid) / (grid + layout.cellSize.Height));
            return new Point(x, y);
        }

        public static void RenderSelectedCellF(Graphics graphics, Game map, LayoutF layout, VisualConfig style, int row, int colomn)
        {
            PointF location = RealLocationF(layout, style, row, colomn);
            graphics.FillRectangle(new SolidBrush(style[map[row, colomn]]),
                location.X, location.Y, layout.cellSize.Width, layout.cellSize.Height);
        }

        public static void RenderMapF(Graphics graphics, Game map, LayoutF layout, VisualConfig style)
        {
            List<RectangleF> cells = new List<RectangleF>();
            PointF firstInRowLocation = new PointF();
            int grid = Grid(style.gridIsVisible);
            int count = 0;
            SolidBrush brush;

            brush = new SolidBrush(style.deadCellColor);
            graphics.FillRectangle(brush, new RectangleF(layout.zeroPivot, layout.mapSize));


            for (int i = 0; i < map.RowsCount; i++) {
                for (int j = 0; j < map.ColomnsCount; j++) {
                    if (map[i, j]) {
                        if (count == 0)
                            firstInRowLocation = RealLocationF(layout, style, i, j);
                        count++;
                    }
                    else {
                        if (count == 0)
                            continue;
                        cells.Add(new RectangleF(firstInRowLocation,
                            new SizeF((layout.cellSize.Width + grid) * count, layout.cellSize.Height + grid)));
                        count = 0;
                    }
                }
                if (count == 0)
                    continue;
                cells.Add(new RectangleF(firstInRowLocation,
                    new SizeF((layout.cellSize.Width + grid) * count, layout.cellSize.Height + grid)));
                count = 0;
            }

            brush = new SolidBrush(style.aliveCellColor);

            RectangleF[] cellsArr = cells.ToArray();
            if (cellsArr.Length != 0)
                graphics.FillRectangles(brush, cellsArr);

            if (layout.mousePos.X > 0 && layout.mousePos.Y > 0) {
                if (map[layout.mousePos])
                    brush = new SolidBrush(style.MouseAlive);
                else
                    brush = new SolidBrush(style.MouseDead);
                PointF point = RealLocationF(layout, style, layout.mousePos);
                graphics.FillRectangle(brush, point.X - grid, point.Y - grid, 
                    layout.cellSize.Width + grid, layout.cellSize.Height + grid);
            }

            DrawGridF(graphics, map, layout, style);

        }

        private static void DrawGridF(Graphics graphics, Game map, LayoutF layout, VisualConfig style)
        {
            List<RectangleF> grid = new List<RectangleF>();
            PointF zero = layout.zeroPivot;
            int gridThickness = Grid(style.gridIsVisible);
            float cellHeight = layout.cellSize.Height;
            float cellWidth = layout.cellSize.Width;

            if (style.gridIsVisible) {
                SizeF recSize = new SizeF(layout.mapSize.Width - gridThickness, cellHeight + gridThickness);
                for (int i = 0; i < Math.Ceiling((double)(map.RowsCount / 2)); i++) {
                    grid.Add(new RectangleF(new PointF(zero.X,
                        2 * i * (gridThickness + cellHeight) + zero.Y), recSize));
                }
                recSize = new SizeF(cellWidth + gridThickness, layout.mapSize.Height - gridThickness);
                for (int i = 0; i < Math.Ceiling((double)map.ColomnsCount / 2); i++) {
                    grid.Add(new RectangleF(new PointF(2 * i * (gridThickness + cellHeight) + zero.X,
                        zero.Y), recSize));
                }
            }
            grid.Add(new RectangleF(zero, layout.mapSize - new Size(gridThickness, gridThickness)));

            RectangleF[] rec = grid.ToArray();
            graphics.DrawRectangles(new Pen(new SolidBrush(style.gridColor), gridThickness),
                rec);
        }

        public static LayoutF LayoutSetupF(System.Windows.Forms.PictureBox pictureBox, Game game, ref VisualConfig style)
        {
            LayoutF result = new LayoutF();
            float CellSetup(float size, int count, int gridThickness) => (size - gridThickness * (count + 1)) / count;
            float MapSetup(float size, int count, int gridThickness) => (size + gridThickness) * count + gridThickness;

            if (!style.gridIsOn && style.gridIsVisible)
                style.gridIsVisible = false;

            int grid = Grid(style.gridIsVisible);
            int pbWidth = pictureBox.Size.Width - 10;
            int pbHeight = pictureBox.Size.Height - 10;

            float cellSize = (float)Math.Round(Math.Min(CellSetup(pbHeight, game.RowsCount, grid),
                CellSetup(pbWidth, game.ColomnsCount, grid)), 3);
            if (style.gridIsVisible && cellSize < 4) {
                style.gridIsVisible = false;
                return LayoutSetupF(pictureBox, game, ref style);
            }
            if (style.gridIsOn && !style.gridIsVisible && cellSize > 5) {
                style.gridIsVisible = true;
                return LayoutSetupF(pictureBox, game, ref style);
            }
            result.cellSize = new SizeF(cellSize, cellSize);

            result.mapSize = new SizeF(MapSetup(cellSize, game.ColomnsCount, grid),
                MapSetup(cellSize, game.RowsCount, grid));

            result.zeroPivot = new PointF()
            {
                X = (pictureBox.Size.Width - result.mapSize.Width) / 2,
                Y = (pictureBox.Size.Height - result.mapSize.Height) / 2
            };

            return result;
        }
    }
}
