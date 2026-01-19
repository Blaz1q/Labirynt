using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirynt
{
    public partial class MazeControl : UserControl
    {
        public enum CellType
        {
            Empty,
            Wall,
            Start,
            End,
            Visited,
            Path
        }
        public class MazeCell
        {
            public CellType Type { get; set; }
        }
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public int CellSize = 25;

        private MazeCell[,] maze;

        public MazeControl()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (maze == null) return;

            Graphics g = e.Graphics;

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Rectangle rect = new Rectangle(
                        c * CellSize,
                        r * CellSize,
                        CellSize,
                        CellSize
                    );

                    Brush brush = Brushes.White;

                    switch (maze[r, c].Type)
                    {
                        case CellType.Wall:
                            brush = Brushes.Black;
                            break;
                        case CellType.Start:
                            brush = Brushes.Green;
                            break;
                        case CellType.End:
                            brush = Brushes.Red;
                            break;
                        case CellType.Visited:
                            brush = Brushes.LightBlue;
                            break;
                        case CellType.Path:
                            brush = Brushes.Gold;
                            break;
                    }

                    g.FillRectangle(brush, rect);
                    //g.DrawRectangle(Pens.Gray, rect);
                }
            }
        }


        public void CreateMaze(int rows, int cols)
        {
            //maze = new MazeCell[rows, cols];

            //for (int r = 0; r < rows; r++)
            //    for (int c = 0; c < cols; c++)
            //        maze[r, c] = new MazeCell();
            this.GenerateRandomMaze(rows, cols);

            Width = Cols * CellSize;
            Height = Rows * CellSize;

            
            Invalidate();
        }
        public void GenerateRandomMaze(int rows,int cols) {
            MazeGeneratorPrim generator = new MazeGeneratorPrim();
            maze = generator.Generate(rows, cols);
            Rows = rows * 2 + 1;
            Cols = cols * 2 + 1;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int col = e.X / CellSize;
            int row = e.Y / CellSize;

            if (row < 0 || col < 0 || row >= Rows || col >= Cols)
                return;

            if (e.Button == MouseButtons.Left)
                maze[row, col].Type = CellType.Wall;

            if (e.Button == MouseButtons.Right)
                maze[row, col].Type = CellType.Empty;

            Invalidate();
        }
    }
}
