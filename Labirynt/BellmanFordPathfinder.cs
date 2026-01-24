using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using static global::Labirynt.MazeControl;

    public class BellmanFordPathfinder : IPathfinder
    {
        private readonly (int dr, int dc)[] directions = { (-1, 0), (1, 0), (0, -1), (0, 1) };

        public async Task<List<(int r, int c)>> FindPathAsync(
            MazeCell[,] maze,
            (int r, int c) start,
            (int r, int c) end,
            Action<int, int, CellType>? onStep = null,
            int delayMs = 20,
            CancellationToken token = default)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);
            Node[,] nodes = new Node[rows, cols];
            List<Node> allNodes = new();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (maze[r, c].Type == CellType.Wall) continue;
                    var n = new Node { Row = r, Col = c, Distance = int.MaxValue };
                    nodes[r, c] = n;
                    allNodes.Add(n);
                }
            }

            nodes[start.r, start.c].Distance = 0;

            // Relaksacja krawędzi (Liczba węzłów - 1) razy
            for (int i = 0; i < allNodes.Count - 1; i++)
            {
                bool anyChange = false;
                token.ThrowIfCancellationRequested();

                foreach (Node u in allNodes)
                {
                    if (u.Distance == int.MaxValue) continue;

                    // Wizualizacja skanowania
                    if ((u.Row, u.Col) != start && (u.Row, u.Col) != end)
                    {
                        onStep?.Invoke(u.Row, u.Col, CellType.Visited);
                        // Przy BF delay musi być minimalny, inaczej trwa to godzinami
                        if (i % 5 == 0) await Task.Delay(1, token);
                    }

                    foreach (var (dr, dc) in directions)
                    {
                        int nr = u.Row + dr;
                        int nc = u.Col + dc;

                        if (nr < 0 || nc < 0 || nr >= rows || nc >= cols) continue;
                        Node v = nodes[nr, nc];
                        if (v == null) continue;

                        if (u.Distance + 1 < v.Distance)
                        {
                            v.Distance = u.Distance + 1;
                            v.Parent = u;
                            anyChange = true;
                            if ((v.Row, v.Col) != end) onStep?.Invoke(v.Row, v.Col, CellType.Frontier);
                        }
                    }
                }
                if (!anyChange) break;
            }

            // Rekonstrukcja ścieżki (taka sama logika jak w Dijkstrze)
            return await ReconstructAndDrawPath(nodes[end.r, end.c], maze, start, end, onStep, token,delayMs);
        }

        private async Task<List<(int r, int c)>> ReconstructAndDrawPath(Node endNode, MazeCell[,] maze, (int r, int c) start, (int r, int c) end, Action<int, int, CellType>? onStep, CancellationToken token, int delayMs = 15)
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
                    await Task.Delay(delayMs, token);
                }
            }
            return path;
        }
    }
}
