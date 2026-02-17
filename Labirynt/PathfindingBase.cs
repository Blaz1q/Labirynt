using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labirynt.MazeControl;

namespace Labirynt
{
    public abstract class PathfindingBase
    {
        protected readonly (int dr, int dc)[] Directions = { (-1, 0), (1, 0), (0, -1), (0, 1) };

        protected void ValidatePoints(MazeCell[,] maze, (int r, int c) start, (int r, int c) end)
        {
            if (start.r < 0 || start.c < 0 || end.r < 0 || end.c < 0)
                throw new Exception("Punkt startowy lub końcowy nie został ustawiony.");

            if (maze[start.r, start.c].Type == CellType.Wall || maze[end.r, end.c].Type == CellType.Wall)
                throw new Exception("Start lub Meta nie mogą znajdować się na ścianie.");
        }

        protected async Task<List<(int r, int c)>> ReconstructAndDrawPath(
            Node endNode, (int r, int c) start, (int r, int c) end,
            Action<int, int, CellType>? onStep, CancellationToken token, int delayMs)
        {
            List<(int r, int c)> path = new();
            if (endNode == null || endNode.Parent == null) return path;

            Node? curr = endNode;
            while (curr != null)
            {
                path.Add((curr.Row, curr.Col));
                curr = curr.Parent;
            }
            path.Reverse();

            foreach (var (r, c) in path)
            {
                token.ThrowIfCancellationRequested();
                if ((r, c) != start && (r, c) != end)
                {
                    onStep?.Invoke(r, c, CellType.Path);
                    if (delayMs > 0) await Task.Delay(delayMs, token);
                }
            }
            return path;
        }
    }
}
