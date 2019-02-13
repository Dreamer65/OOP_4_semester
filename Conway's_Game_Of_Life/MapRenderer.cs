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
            public bool isGridOn;
            public Color gridColor;
            public Color aliveCellColor;
            public Color deathCellColor;

            public Color this[bool cellStatus]
            {
                get => (cellStatus) ? aliveCellColor : deathCellColor;
            }

        }

        public struct Layout
        {
            public Size cellSize;
            public Size mapSize;
            public Point zeroPivot;
        }

        public struct LayoutF
        {
            public SizeF cellSize;
            public SizeF mapSize;
            public PointF zeroPivot;
        }

        private static int Grid(bool status) => (status) ? 1 : 0;

        // Методы для целочисленных длинн сторон
        #region 
        private static Point RealLocation(Layout layout, VisualConfig style, int row, int colomn)
        {
            int grid = Grid(style.isGridOn);
            Point result = new Point((grid + layout.cellSize.Width) * row + grid,
                (grid + layout.cellSize.Height) * colomn + grid);
            result.Offset(layout.zeroPivot);
            return result;
        }

        private static Point RealLocation(Layout layout, VisualConfig style, Point cellLocation)
        {
            int grid = Grid(style.isGridOn);
            Point result = new Point((grid + layout.cellSize.Width) * cellLocation.X + grid,
                (grid + layout.cellSize.Height) * cellLocation.Y + grid);
            result.Offset(layout.zeroPivot);
            return result;
        }

        public static Point RelativeLocation(Layout layout, VisualConfig style, Point location)
        {
            int grid = Grid(style.isGridOn);
            return new Point(Math.Abs((location.X - layout.zeroPivot.X - grid) / (grid + layout.cellSize.Height)),
                Math.Abs((location.Y - layout.zeroPivot.Y - grid) / (grid + layout.cellSize.Width)));
        }

        public static void RenderSelectedCell(Graphics graphics, Game map, Layout layout, VisualConfig style, int row, int colomn)
        {
            Point location = RealLocation(layout, style, row, colomn);
            graphics.FillRectangle(new SolidBrush(style[map[row, colomn]]),
                location.X, location.Y, layout.cellSize.Width, layout.cellSize.Height);
        }

        public static void RenderSelectedCell(System.Windows.Forms.PictureBox pictureBox, Game map, Layout layout, VisualConfig style, Point mapLocation)
        {
            Graphics graphics = pictureBox.CreateGraphics();
            graphics.FillRectangle(new SolidBrush(style[map[mapLocation]]),
                new Rectangle(RealLocation(layout, style, mapLocation), layout.cellSize));
        }

        public static void RenderMap(Graphics graphics, Game map, Layout layout, VisualConfig style)
        {
            List<Rectangle> cells = new List<Rectangle>();
            Point firstInRowLocation = new Point();
            int grid = Grid(style.isGridOn);
            int count = 0;
            SolidBrush brush;

            brush = new SolidBrush(style.deathCellColor);
            graphics.FillRectangle(brush, new Rectangle(layout.zeroPivot, layout.mapSize));


            for (int i = 0; i < map.RowsCount; i++) {
                for (int j = 0; j < map.ColomnsCount; j++) {
                    if (map[i, j]) {
                        if (count == 0)
                            firstInRowLocation = RealLocation(layout, style, i, j);
                        count++;
                    }
                    else {
                        if (count == 0)
                            continue;
                        cells.Add(new Rectangle(firstInRowLocation,
                            new Size(layout.cellSize.Width, (layout.cellSize.Height + grid) * count - grid)));
                        count = 0;
                    }
                }
                if (count == 0)
                    continue;
                cells.Add(new Rectangle(firstInRowLocation,
                    new Size(layout.cellSize.Width, (layout.cellSize.Height + grid) * count - grid)));
                count = 0;
            }

            brush = new SolidBrush(style.aliveCellColor);

            Rectangle[] cellsArr = cells.ToArray();
            if (cellsArr.Length != 0)
                graphics.FillRectangles(brush, cellsArr);

            DrawGrid(graphics, map, layout, style);

        }

        private static void DrawGrid(Graphics graphics, Game map, Layout layout, VisualConfig style)
        {
            List<Rectangle> grid = new List<Rectangle>();
            Point zero = layout.zeroPivot;
            int gridThickness = Grid(style.isGridOn);
            int cellHeight = layout.cellSize.Height;
            int cellWidth = layout.cellSize.Width;

            if (style.isGridOn) {
                Size recSize = new Size(layout.mapSize.Width - gridThickness, cellHeight + gridThickness);
                for (int i = 0; i < map.RowsCount / 2; i++) {
                    grid.Add(new Rectangle(new Point(zero.X,
                        2 * i * (gridThickness + cellHeight) + zero.Y), recSize));
                }
                recSize = new Size(cellWidth + gridThickness, layout.mapSize.Height - gridThickness);
                for (int i = 0; i < map.ColomnsCount / 2; i++) {
                    grid.Add(new Rectangle(new Point(2 * i * (gridThickness + cellHeight) + zero.X,
                        zero.Y), recSize));
                }
            }
            grid.Add(new Rectangle(zero, layout.mapSize - new Size(gridThickness, gridThickness)));

            Rectangle[] rec = grid.ToArray();
            graphics.DrawRectangles(new Pen(new SolidBrush(style.gridColor), gridThickness),
                rec);
        }

        public static Layout LayoutSetup(System.Windows.Forms.PictureBox pictureBox, Game game, VisualConfig style){
            Layout result = new Layout();
            int CellSetup(int size, int count, int gridThickness) => (size - gridThickness * (count + 1)) / count;
            int MapSetup(int size, int count, int gridThickness) => (size + gridThickness) * count + gridThickness;

            int grid = Grid(style.isGridOn);
            int cellSize = Math.Min(CellSetup(pictureBox.Size.Height, game.RowsCount, grid),
                CellSetup(pictureBox.Size.Width, game.ColomnsCount, grid));
            result.cellSize = new Size(cellSize, cellSize);

            result.mapSize = new Size(MapSetup(cellSize, game.ColomnsCount, grid),
                MapSetup(cellSize, game.RowsCount, grid));

            result.zeroPivot = new Point()
            {
                X = (pictureBox.Size.Width - result.mapSize.Width)/2,
                Y = (pictureBox.Size.Height - result.mapSize.Height) / 2
            };

            return result;
        }

        #endregion

        private static PointF RealLocationF(LayoutF layout, VisualConfig style, int row, int colomn)
        {
            int grid = Grid(style.isGridOn);
            PointF result = new PointF((grid + layout.cellSize.Width) * row + grid,
                (grid + layout.cellSize.Height) * colomn + grid);
            result.X += layout.zeroPivot.X;
            result.Y += layout.zeroPivot.Y;
            return result;
        }

        private static PointF RealLocationF(LayoutF layout, VisualConfig style, Point cellLocation)
        {
            int grid = Grid(style.isGridOn);
            PointF result = new PointF((grid + layout.cellSize.Width) * cellLocation.X + grid,
                (grid + layout.cellSize.Height) * cellLocation.Y + grid);
            result.X += layout.zeroPivot.X;
            result.Y += layout.zeroPivot.Y;
            return result;
        }

        public static Point RelativeLocationF(LayoutF layout, VisualConfig style, Point location)
        {
            int grid = Grid(style.isGridOn);
            return new Point((int)Math.Abs((location.X - layout.zeroPivot.X - grid) / (grid + layout.cellSize.Height)),
                (int)Math.Abs((location.Y - layout.zeroPivot.Y - grid) / (grid + layout.cellSize.Width)));
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
            int grid = Grid(style.isGridOn);
            int count = 0;
            SolidBrush brush;

            brush = new SolidBrush(style.deathCellColor);
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
                            new SizeF(layout.cellSize.Width, (layout.cellSize.Height + grid) * count - grid)));
                        count = 0;
                    }
                }
                if (count == 0)
                    continue;
                cells.Add(new RectangleF(firstInRowLocation,
                    new SizeF(layout.cellSize.Width, (layout.cellSize.Height + grid) * count - grid)));
                count = 0;
            }

            brush = new SolidBrush(style.aliveCellColor);

            RectangleF[] cellsArr = cells.ToArray();
            if (cellsArr.Length != 0)
                graphics.FillRectangles(brush, cellsArr);

            DrawGridF(graphics, map, layout, style);

        }

        private static void DrawGridF(Graphics graphics, Game map, LayoutF layout, VisualConfig style)
        {
            List<RectangleF> grid = new List<RectangleF>();
            PointF zero = layout.zeroPivot;
            int gridThickness = Grid(style.isGridOn);
            float cellHeight = layout.cellSize.Height;
            float cellWidth = layout.cellSize.Width;

            if (style.isGridOn) {
                SizeF recSize = new SizeF(layout.mapSize.Width - gridThickness, cellHeight + gridThickness);
                for (int i = 0; i < map.RowsCount / 2; i++) {
                    grid.Add(new RectangleF(new PointF(zero.X,
                        2 * i * (gridThickness + cellHeight) + zero.Y), recSize));
                }
                recSize = new SizeF(cellWidth + gridThickness, layout.mapSize.Height - gridThickness);
                for (int i = 0; i < map.ColomnsCount / 2; i++) {
                    grid.Add(new RectangleF(new PointF(2 * i * (gridThickness + cellHeight) + zero.X,
                        zero.Y), recSize));
                }
            }
            grid.Add(new RectangleF(zero, layout.mapSize - new Size(gridThickness, gridThickness)));

            RectangleF[] rec = grid.ToArray();
            graphics.DrawRectangles(new Pen(new SolidBrush(style.gridColor), gridThickness),
                rec);
        }

        public static LayoutF LayoutSetupF(System.Windows.Forms.PictureBox pictureBox, Game game, VisualConfig style)
        {
            LayoutF result = new LayoutF();
            float CellSetup(float size, int count, int gridThickness) => (size - gridThickness * (count + 1)) / count;
            float MapSetup(float size, int count, int gridThickness) => (size + gridThickness) * count + gridThickness;

            int grid = Grid(style.isGridOn);
            float cellSize = Math.Min(CellSetup(pictureBox.Size.Height, game.RowsCount, grid),
                CellSetup(pictureBox.Size.Width, game.ColomnsCount, grid));
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
