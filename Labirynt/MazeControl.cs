using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            Frontier,
            Path
        }
        public CellType UserBrush = CellType.Wall;
        public class MazeCell
        {
            public CellType Type { get; set; }
        }
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public int[] start = { -1,-1};
        public int[] end = { -1,-1};
        private CancellationTokenSource? _cts;
        public int CellSize = 25;
        public int delay = 0;
        public long LastSolveTimeMs { get; private set; }
        private MazeCell[,] maze;

        public event Action<long>? OnSolveFinished;

        public MazeControl()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }
        public void FindStartAndEnd()
        {
            for (int r = 0; r < this.Rows; r++)
            {
                for (int c = 0; c < this.Cols; c++)
                {
                    switch (this.maze[r, c].Type)
                    {
                        case CellType.Start:
                            this.start[0] = r;
                            this.start[1] = c;
                            Console.WriteLine("start");
                            break;

                        case CellType.End:
                            this.end[0] = r;
                            this.end[1] = c;
                            Console.WriteLine("end");
                            break;
                    }
                }
            }
        }

        public async Task PrepareForNewAlgorithm()
        {
            // 1. Przerwij aktualnie działający algorytm
            if (_cts != null)
            {
                _cts.Cancel();
                _cts.Dispose();
            }

            // 2. Stwórz nowy token dla nadchodzącego algorytmu
            _cts = new CancellationTokenSource();
            LastSolveTimeMs = 0; // Resetujemy czas przed nowym startem
            // 3. (Opcjonalnie) Wyczyść poprzednie wyniki z labiryntu
            ClearVisuals();
        }

        private void ClearVisuals()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (maze[r, c].Type == CellType.Visited ||
                        maze[r, c].Type == CellType.Frontier ||
                        maze[r, c].Type == CellType.Path)
                    {
                        maze[r, c].Type = CellType.Empty;
                    }
                }
            }
            Invalidate();
        }
        public async Task SolveAlgorithmAsync(IPathfinder pathfinder)
        {
            await PrepareForNewAlgorithm();
            var token = _cts.Token;

            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                FindStartAndEnd();

                // Polimorficzne wywołanie metody FindPathAsync
                await pathfinder.FindPathAsync(
                    maze,
                    (start[0], start[1]),
                    (end[0], end[1]),
                    onStep: (r, c, type) =>
                    {
                        if (maze[r, c].Type == CellType.Start || maze[r, c].Type == CellType.End) return;
                        maze[r, c].Type = type;
                        Invalidate();
                    },
                    delayMs: delay,
                    token: token
                );

                sw.Stop();
                LastSolveTimeMs = sw.ElapsedMilliseconds;
                OnSolveFinished?.Invoke(LastSolveTimeMs);
            }
            catch (OperationCanceledException)
            {
                sw.Stop();
                LastSolveTimeMs = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd algorytmu: {ex.Message}");
            }
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


        public void CreateMaze(int rows, int cols,double density)
        {
            //maze = new MazeCell[rows, cols];

            //for (int r = 0; r < rows; r++)
            //    for (int c = 0; c < cols; c++)
            //        maze[r, c] = new MazeCell();
            PrepareForNewAlgorithm();
            this.GenerateRandomMaze(rows, cols,density);

            Width = Cols * CellSize;
            Height = Rows * CellSize;

            
            Invalidate();
        }
        public void GenerateRandomMaze(int rows,int cols,double density) {
            MazeGeneratorPrim generator = new MazeGeneratorPrim();
            maze = generator.Generate(rows, cols,density);
            Rows = rows * 2 + 1;
            Cols = cols * 2 + 1;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int col = e.X / CellSize;
            int row = e.Y / CellSize;

            if (row < 0 || col < 0 || row >= Rows || col >= Cols)
                return;

            if (e.Button == MouseButtons.Left) {
                switch (UserBrush) {
                    case CellType.Wall:
                        maze[row, col].Type = CellType.Wall;
                    break;
                    case CellType.Start:
                        this.FindStartAndEnd();
                        maze[start[0], start[1]].Type = CellType.Empty;
                        maze[row, col].Type = CellType.Start;
                        break;
                    case CellType.End:
                        this.FindStartAndEnd();
                        maze[end[0], end[1]].Type = CellType.Empty;
                        maze[row, col].Type = CellType.End;
                        break;
                    default:
                        break;
                }
            }
            if (e.Button == MouseButtons.Right)
                maze[row, col].Type = CellType.Empty;

            Invalidate();
        }
    }
}
