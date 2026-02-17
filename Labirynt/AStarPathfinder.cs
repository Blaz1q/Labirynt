using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labirynt.MazeControl;

namespace Labirynt
{
    public class AStarPathfinder : PathfindingBase, IPathfinder
    {
        private readonly IHeuristic _heuristic;

        // Punkt 2: Mechanizm wyboru heurystyki przez konstruktor
        public AStarPathfinder(IHeuristic heuristic)
        {
            _heuristic = heuristic;
        }

        public async Task<PathfindingResult> FindPathAsync(
            MazeCell[,] maze,
            (int r, int c) start,
            (int r, int c) end,
            Action<int, int, MazeControl.CellType>? onStep = null,
            int delayMs = 15,
            CancellationToken token = default)
        {
            // Punkt 16: Ujednolicona walidacja
            ValidatePoints(maze, start, end);

            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);
            Node[,] nodes = new Node[rows, cols];

            // Punkt 18: Wydajna kolejka priorytetowa (NuGet: .NET 6+ PriorityQueue)
            var priorityQueue = new PriorityQueue<Node, double>();
            int visitedCount = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (maze[r, c].Type == CellType.Wall) continue;
                    // Poprawka: dystans trzymamy jako double, by uniknąć overflow przy MaxValue
                    nodes[r, c] = new Node { Row = r, Col = c, Distance = double.MaxValue };
                }
            }

            Node startNode = nodes[start.r, start.c];
            startNode.Distance = 0;

            // f(n) = g(n) + h(n)
            double startPriority = 0 + _heuristic.Calculate(start, end);
            priorityQueue.Enqueue(startNode, startPriority);

            // Punkt 10: Pomiar czasu bez wizualizacji
            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool targetReached = false;

            while (priorityQueue.Count > 0)
            {
                token.ThrowIfCancellationRequested();

                Node current = priorityQueue.Dequeue();

                if (current.Visited) continue;
                current.Visited = true;
                visitedCount++;

                if (current.Row == end.r && current.Col == end.c)
                {
                    targetReached = true;
                    break;
                }

                // Punkt 10: Obsługa wizualizacji z pauzą stopera
                if (delayMs > 0 && onStep != null)
                {
                    sw.Stop();
                    if ((current.Row, current.Col) != start)
                        onStep.Invoke(current.Row, current.Col, CellType.Visited);

                    await Task.Delay(delayMs, token);
                    sw.Start();
                }

                foreach (var (dr, dc) in Directions)
                {
                    int nr = current.Row + dr;
                    int nc = current.Col + dc;

                    if (nr < 0 || nc < 0 || nr >= rows || nc >= cols) continue;

                    Node neighbor = nodes[nr, nc];
                    if (neighbor == null || neighbor.Visited) continue;

                    double tentativeG = current.Distance + 1;

                    if (tentativeG < neighbor.Distance)
                    {
                        neighbor.Parent = current;
                        neighbor.Distance = tentativeG;

                        double fScore = tentativeG + _heuristic.Calculate((nr, nc), end);
                        priorityQueue.Enqueue(neighbor, fScore);

                        if (delayMs > 0 && (nr, nc) != end)
                            onStep?.Invoke(nr, nc, CellType.Frontier);
                    }
                }
            }

            sw.Stop();

            if (!targetReached)
                return new PathfindingResult(new List<(int, int)>(), visitedCount, sw.Elapsed.TotalMilliseconds);

            // Punkt 17: Rekonstrukcja ścieżki (wywołujemy z klasy bazowej, by nie powtarzać kodu)
            var finalPath = await ReconstructAndDrawPath(nodes[end.r, end.c], start, end, onStep, token, delayMs);

            return new PathfindingResult(finalPath, visitedCount, sw.Elapsed.TotalMilliseconds);
        }
    }
}
