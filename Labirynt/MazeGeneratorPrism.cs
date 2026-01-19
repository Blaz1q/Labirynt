using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labirynt.MazeControl;

namespace Labirynt
{
    public class MazeGeneratorPrim
    {
        private readonly (int dr, int dc)[] directions =
        {
        (-1, 0),
        (1, 0),
        (0, -1),
        (0, 1)
    };

        private Random rand = new Random();

        public MazeCell[,] Generate(int rows, int cols)
        {
            int gridRows = rows * 2 + 1;
            int gridCols = cols * 2 + 1;

            MazeCell[,] maze = new MazeCell[gridRows, gridCols];

            for (int r = 0; r < gridRows; r++)
                for (int c = 0; c < gridCols; c++)
                    maze[r, c] = new MazeCell
                    {
                        Type = CellType.Wall
                    };

            int startR = rand.Next(rows) * 2 + 1;
            int startC = rand.Next(cols) * 2 + 1;

            maze[startR, startC].Type = CellType.Empty;

            List<(int r, int c)> walls = new();

            AddWalls(startR, startC, maze, walls);

            while (walls.Count > 0)
            {
                int index = rand.Next(walls.Count);
                var (wr, wc) = walls[index];
                walls.RemoveAt(index);

                int r1 = wr + (wr % 2 == 0 ? -1 : 0);
                int c1 = wc + (wc % 2 == 0 ? -1 : 0);

                int r2 = wr + (wr % 2 == 0 ? 1 : 0);
                int c2 = wc + (wc % 2 == 0 ? 1 : 0);

                if (!IsInside(maze, r1, c1) || !IsInside(maze, r2, c2))
                    continue;

                bool v1 = maze[r1, c1].Type == CellType.Empty;
                bool v2 = maze[r2, c2].Type == CellType.Empty;

                if (v1 ^ v2)
                {
                    maze[wr, wc].Type = CellType.Empty;

                    int nr = v1 ? r2 : r1;
                    int nc = v1 ? c2 : c1;

                    maze[nr, nc].Type = CellType.Empty;
                    AddWalls(nr, nc, maze, walls);
                }
            }

            maze[startR, startC].Type = CellType.Start;
            maze[gridRows - 2, gridCols - 2].Type = CellType.End;

            return maze;
        }

        private void AddWalls(
            int r,
            int c,
            MazeCell[,] maze,
            List<(int r, int c)> walls)
        {
            foreach (var (dr, dc) in directions)
            {
                int wr = r + dr;
                int wc = c + dc;

                if (!IsInside(maze, wr, wc))
                    continue;

                if (maze[wr, wc].Type == CellType.Wall)
                    walls.Add((wr, wc));
            }
        }

        private bool IsInside(MazeCell[,] maze, int r, int c)
        {
            return r > 0 &&
                   c > 0 &&
                   r < maze.GetLength(0) - 1 &&
                   c < maze.GetLength(1) - 1;
        }
    }
}
