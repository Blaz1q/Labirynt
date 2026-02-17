using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labirynt.IPathfinder;
using static Labirynt.MazeControl;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Labirynt.MazeControl;

namespace Labirynt
{
    public class DijkstraPathfinder : PathfindingBase, IPathfinder
    {
        public async Task<PathfindingResult> FindPathAsync(
            MazeCell[,] maze, (int r, int c) start, (int r, int c) end,
            Action<int, int, CellType>? onStep = null, int delayMs = 15, CancellationToken token = default)
        {
            ValidatePoints(maze, start, end);

            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);
            Node[,] nodes = new Node[rows, cols];

            // Punkt 18: Użycie PriorityQueue zamiast List.OrderBy
            var priorityQueue = new PriorityQueue<Node, double>();
            int visitedCount = 0;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    if (maze[r, c].Type != CellType.Wall)
                        nodes[r, c] = new Node { Row = r, Col = c, Distance = double.MaxValue };

            Node startNode = nodes[start.r, start.c];
            startNode.Distance = 0;
            priorityQueue.Enqueue(startNode, 0);

            // Punkt 10: Pomiar czasu bez animacji
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (priorityQueue.Count > 0)
            {
                token.ThrowIfCancellationRequested();
                Node current = priorityQueue.Dequeue();

                if (current.Visited) continue;
                current.Visited = true;
                visitedCount++;

                // Wizualizacja z pauzą stopera
                if (delayMs > 0 && onStep != null)
                {
                    sw.Stop();
                    if ((current.Row, current.Col) != start && (current.Row, current.Col) != end)
                        onStep.Invoke(current.Row, current.Col, CellType.Visited);
                    await Task.Delay(delayMs, token);
                    sw.Start();
                }

                if (current.Row == end.r && current.Col == end.c) break;

                foreach (var (dr, dc) in Directions)
                {
                    int nr = current.Row + dr; int nc = current.Col + dc;
                    if (nr < 0 || nc < 0 || nr >= rows || nc >= cols) continue;
                    Node neighbor = nodes[nr, nc];
                    if (neighbor == null || neighbor.Visited) continue;

                    double newDist = current.Distance + 1;
                    if (newDist < neighbor.Distance)
                    {
                        neighbor.Distance = newDist;
                        neighbor.Parent = current;
                        priorityQueue.Enqueue(neighbor, newDist);

                        if (delayMs > 0 && (nr, nc) != end)
                            onStep?.Invoke(nr, nc, CellType.Frontier);
                    }
                }
            }
            sw.Stop();

            var path = await ReconstructAndDrawPath(nodes[end.r, end.c], start, end, onStep, token, delayMs);
            return new PathfindingResult(path, visitedCount, sw.Elapsed.TotalMilliseconds);
        }
    }
}