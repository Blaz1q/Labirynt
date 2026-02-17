using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using static Labirynt.MazeControl;

namespace Labirynt
{
    public class BellmanFordPathfinder : PathfindingBase, IPathfinder
    {
        public async Task<PathfindingResult> FindPathAsync(
            MazeCell[,] maze, (int r, int c) start, (int r, int c) end,
            Action<int, int, CellType>? onStep = null, int delayMs = 20, CancellationToken token = default)
        {
            ValidatePoints(maze, start, end);

            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);
            Node[,] nodes = new Node[rows, cols];
            List<Node> allNodes = new();
            int visitedCount = 0;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    if (maze[r, c].Type != CellType.Wall)
                    {
                        var n = new Node { Row = r, Col = c, Distance = double.MaxValue };
                        nodes[r, c] = n;
                        allNodes.Add(n);
                    }

            nodes[start.r, start.c].Distance = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Relaksacja krawędzi (V - 1 razy)
            for (int i = 0; i < allNodes.Count - 1; i++)
            {
                bool anyChange = false;
                token.ThrowIfCancellationRequested();

                foreach (Node u in allNodes)
                {
                    if (u.Distance == double.MaxValue) continue;

                    // W Bellman-Ford każda analiza węzła w iteracji to odwiedzenie
                    visitedCount++;

                    // Punkt 10: Wizualizacja (rzadsza dla BF, żeby nie trwała wiecznie)
                    if (delayMs > 0 && onStep != null && i % 2 == 0)
                    {
                        sw.Stop();
                        if ((u.Row, u.Col) != start && (u.Row, u.Col) != end)
                            onStep.Invoke(u.Row, u.Col, CellType.Visited);
                        await Task.Delay(1, token);
                        sw.Start();
                    }

                    foreach (var (dr, dc) in Directions)
                    {
                        int nr = u.Row + dr; int nc = u.Col + dc;
                        if (nr < 0 || nc < 0 || nr >= rows || nc >= cols) continue;
                        Node v = nodes[nr, nc];
                        if (v == null) continue;

                        if (u.Distance + 1 < v.Distance)
                        {
                            v.Distance = u.Distance + 1;
                            v.Parent = u;
                            anyChange = true;
                            if (delayMs > 0 && (v.Row, v.Col) != end)
                                onStep?.Invoke(v.Row, v.Col, CellType.Frontier);
                        }
                    }
                }
                if (!anyChange) break;
            }
            sw.Stop();

            var path = await ReconstructAndDrawPath(nodes[end.r, end.c], start, end, onStep, token, delayMs);
            return new PathfindingResult(path, visitedCount, sw.Elapsed.TotalMilliseconds);
        }
    }
}
