
using System;
using System.Collections.Generic;
using System.Drawing;


namespace Conway_s_Game_Of_Life
{
    public static partial class MapRenderer
    {
        private static int Grid(bool status) => (status) ? 1 : 0;
        
        private static PointF RealLocationF(LayoutF layout, Style style, int row, int colomn)
        {
            int grid = Grid(style.GridIsVisible);
            PointF result = new PointF((grid + layout.cellSize.Width) * colomn + grid,
                (grid + layout.cellSize.Height) * row + grid);
            result.X += layout.zeroPivot.X - grid;
            result.Y += layout.zeroPivot.Y - grid;
            return result;
        }

        private static PointF RealLocationF(LayoutF layout, Style style, Point cellLocation)
        {
            int grid = Grid(style.GridIsVisible);
            PointF result = new PointF((grid + layout.cellSize.Width) * cellLocation.X + grid,
                (grid + layout.cellSize.Height) * cellLocation.Y + grid);
            result.X += layout.zeroPivot.X;
            result.Y += layout.zeroPivot.Y;
            return result;
        }

        public static Point RelativeLocationF(LayoutF layout, Style style, Point location)
        {
            int grid = Grid(style.GridIsVisible);
            float x = (location.X - layout.zeroPivot.X - grid) / (grid + layout.cellSize.Width);
            float y = (location.Y - layout.zeroPivot.Y - grid) / (grid + layout.cellSize.Height);
            return new Point((int)((x<0)?-1:x), (int)((y < 0) ? -1 : y));
        }

        /*
        public static void RenderSelectedCellF(Graphics graphics, Game map, LayoutF layout, Style style, int row, int colomn)
        {
            PointF location = RealLocationF(layout, style, row, colomn);
            graphics.FillRectangle(style[map[row, colomn]],
                location.X, location.Y, layout.cellSize.Width, layout.cellSize.Height);
        }*/

        public static void RenderMapF(Graphics graphics, Game map, LayoutF layout, Style style)
        {
            List<RectangleF> cells = new List<RectangleF>();
            PointF firstInRowLocation = new PointF();
            int grid = Grid(style.GridIsVisible);
            int count = 0;
            
            graphics.FillRectangle(style.DeadCell, new RectangleF(layout.zeroPivot, layout.mapSize));


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
            
            RectangleF[] cellsArr = cells.ToArray();
            if (cellsArr.Length != 0)
                graphics.FillRectangles(style.AliveCell, cellsArr);

            if (style.mousePos.X >= 0 && style.mousePos.Y >= 0) {
                SolidBrush brush;
                if (map[style.mousePos])
                    brush = style.MouseAlive;
                else
                    brush = style.MouseDead;
                PointF point = RealLocationF(layout, style, style.mousePos);
                graphics.FillRectangle(brush, point.X - grid, point.Y - grid, 
                    layout.cellSize.Width + grid, layout.cellSize.Height + grid);
            }

            DrawGridF(graphics, map, layout, style);

        }

        private static void DrawGridF(Graphics graphics, Game map, LayoutF layout, Style style)
        {
            List<RectangleF> grid = new List<RectangleF>();
            PointF zero = layout.zeroPivot;
            int gridThickness = Grid(style.GridIsVisible);
            float cellHeight = layout.cellSize.Height;
            float cellWidth = layout.cellSize.Width;

            if (style.GridIsVisible) {
                SizeF recSize = new SizeF(layout.mapSize.Width - gridThickness, cellHeight + gridThickness);
                for (int i = 0; i < Math.Ceiling((double)map.RowsCount / 2); i++) {
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
            graphics.DrawRectangles(new Pen(style.Grid, gridThickness),
                rec);
        }

        public static LayoutF LayoutSetupF(System.Windows.Forms.PictureBox pictureBox, Game game, ref Style style)
        {
            LayoutF result = new LayoutF();
            float CellSetup(float size, int count, int gridThickness) => (size - gridThickness * (count + 1)) / count;
            float MapSetup(float size, int count, int gridThickness) => (size + gridThickness) * count + gridThickness;

            if (!style.GridIsOn && style.GridIsVisible)
                style.GridIsVisible = false;

            int grid = Grid(style.GridIsVisible);
            int pbWidth = pictureBox.Size.Width - 10;
            int pbHeight = pictureBox.Size.Height - 10;

            float cellSize = (float)Math.Round(Math.Min(CellSetup(pbHeight, game.RowsCount, grid),
                CellSetup(pbWidth, game.ColomnsCount, grid)), 3);
            if (style.GridIsVisible && cellSize < 4) {
                style.GridIsVisible = false;
                return LayoutSetupF(pictureBox, game, ref style);
            }
            if (style.GridIsOn && !style.GridIsVisible && cellSize > 5) {
                style.GridIsVisible = true;
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
