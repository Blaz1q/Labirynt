using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labirynt.MazeControl;

namespace Labirynt
{
    public class AStarPathfinder : IPathfinder
    {
        private readonly (int dr, int dc)[] directions = { (-1, 0), (1, 0), (0, -1), (0, 1) };

        public async Task<List<(int r, int c)>> FindPathAsync(
    MazeCell[,] maze,
    (int r, int c) start,
    (int r, int c) end,
    Action<int, int, CellType>? onStep = null,
    int delayMs = 15,
    CancellationToken token = default)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);
            Node[,] nodes = new Node[rows, cols];
            List<Node> openSet = new();

            // 1. Inicjalizacja węzłów
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (maze[r, c].Type == CellType.Wall) continue;
                    nodes[r, c] = new Node { Row = r, Col = c, Distance = int.MaxValue };
                }
            }

            // Sprawdzenie czy start i meta nie są na ścianach
            if (nodes[start.r, start.c] == null || nodes[end.r, end.c] == null)
            {
                System.Windows.Forms.MessageBox.Show("Start lub Meta znajduje się na ścianie!");
                return new List<(int, int)>();
            }

            Node startNode = nodes[start.r, start.c];
            Node endNode = nodes[end.r, end.c];

            startNode.Distance = 0;
            openSet.Add(startNode);

            bool targetReached = false;

            while (openSet.Count > 0)
            {
                token.ThrowIfCancellationRequested();

                // Wybieramy węzeł z najniższym F = G + H
                Node current = openSet.OrderBy(n => n.Distance + GetHeuristic(n, endNode)).First();

                if (current == endNode)
                {
                    targetReached = true;
                    break;
                }

                openSet.Remove(current);
                current.Visited = true;

                if ((current.Row, current.Col) != start && (current.Row, current.Col) != end)
                {
                    onStep?.Invoke(current.Row, current.Col, CellType.Visited);
                    await Task.Delay(delayMs, token);
                }

                foreach (var (dr, dc) in directions)
                {
                    int nr = current.Row + dr;
                    int nc = current.Col + dc;

                    if (nr < 0 || nc < 0 || nr >= rows || nc >= cols) continue;
                    Node neighbor = nodes[nr, nc];
                    if (neighbor == null || neighbor.Visited) continue;

                    int tentativeG = current.Distance + 1;

                    if (tentativeG < neighbor.Distance)
                    {
                        neighbor.Parent = current;
                        neighbor.Distance = tentativeG;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                            if ((nr, nc) != end)
                                onStep?.Invoke(nr, nc, CellType.Frontier);
                        }
                    }
                }
            }

            // Diagnostyka zatrzymania
            if (!targetReached)
            {
                System.Windows.Forms.MessageBox.Show("Nie znaleziono ścieżki – cel jest odcięty!");
                return new List<(int, int)>();
            }

            return await ReconstructAndDrawPath(endNode, maze, start, end, onStep, token,delayMs);
        }

        // Heurystyka: Odległość Manhattan (suma różnic współrzędnych)
        private int GetHeuristic(Node a, Node b)
        {
            return Math.Abs(a.Row - b.Row) + Math.Abs(a.Col - b.Col);
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
