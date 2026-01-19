using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labirynt.MazeControl;

namespace Labirynt
{
    public class MazeGeneratorHuntAndKill
    {
        private readonly (int dr, int dc)[] directions =
        {
        (-1, 0),
        (1, 0),
        (0, -1),
        (0, 1)
    };

        private int rows;
        private int cols;
        private MazeCell[,] maze;
        private bool[,] visited;
        private Random rand;

        public MazeCell[,] Generate(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;

            rand = new Random();

            maze = new MazeCell[rows, cols];
            visited = new bool[rows, cols];

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    maze[r, c] = new MazeCell
                    {
                        Type = CellType.Wall
                    };

            int cr = rand.Next(rows);
            int cc = rand.Next(cols);

            Carve(cr, cc);

            maze[cr, cc].Type = CellType.Start;
            maze[rows - 1, cols - 1].Type = CellType.End;

            return maze;
        }

        private void Carve(int r, int c)
        {
            visited[r, c] = true;
            maze[r, c].Type = CellType.Empty;

            while (true)
            {
                var neighbors = GetUnvisitedNeighbors(r, c);

                if (neighbors.Count == 0)
                    return;

                var (nr, nc) = neighbors[rand.Next(neighbors.Count)];

                r = nr;
                c = nc;

                visited[r, c] = true;
                maze[r, c].Type = CellType.Empty;
            }
        }

        private List<(int r, int c)> GetUnvisitedNeighbors(int r, int c)
        {
            List<(int r, int c)> list = new();

            foreach (var (dr, dc) in directions)
            {
                int nr = r + dr;
                int nc = c + dc;

                if (nr < 0 || nc < 0 || nr >= rows || nc >= cols)
                    continue;

                if (!visited[nr, nc])
                    list.Add((nr, nc));
            }

            return list;
        }
    }
}
