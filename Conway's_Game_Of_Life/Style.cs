
using System;
using System.Drawing;


namespace Conway_s_Game_Of_Life
{
    public static partial class MapRenderer
    {
        public struct Style
        {
            private const int invert = 60;

            private Color aliveCellColor;
            private Color deadCellColor;

            public Point mousePos { get; set; }
            public bool DefoultStyle { get; set; }
            public bool GridIsOn { get; set; }
            public bool GridIsVisible { get; set; }
            public SolidBrush Grid { get; private set; }
            public SolidBrush AliveCell { get; private set; }
            public SolidBrush DeadCell { get; private set; }

            public SolidBrush MouseAlive
            {
                get => new SolidBrush(Color.FromArgb(aliveCellColor.A, Math.Abs(invert - aliveCellColor.R) % 255,
                    Math.Abs(invert - +aliveCellColor.G) % 255, Math.Abs(invert - aliveCellColor.B) % 255));
            }

            public SolidBrush MouseDead
            {
                get => new SolidBrush(Color.FromArgb(deadCellColor.A, Math.Abs(invert - deadCellColor.R) % 255,
                    Math.Abs(invert - deadCellColor.G) % 255, Math.Abs(invert - deadCellColor.B) % 255));
            }

            public SolidBrush this[bool cellStatus]
            {
                get => (cellStatus) ? AliveCell : DeadCell;
            }

            public Color GridColor { set => Grid = new SolidBrush(value); }

            public Color AliveCellColor
            {
                set {
                    aliveCellColor = value;
                    AliveCell = new SolidBrush(value);
                }
            }

            public Color DeadCellColor
            {
                set {
                    deadCellColor = value;
                    DeadCell = new SolidBrush(value);
                }
            }

        }

        public struct LayoutF
        {
            public SizeF cellSize;
            public SizeF mapSize;
            public PointF zeroPivot;
            //public Point mousePos;
        }
    }
}
