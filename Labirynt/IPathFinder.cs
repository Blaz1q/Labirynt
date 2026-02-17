using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labirynt.MazeControl;

namespace Labirynt
{
    public record PathfindingResult(
        List<(int r, int c)> Path,
        int VisitedCount,
        double ComputationTimeMs // Czas bez animacji
    );

    public interface IPathfinder
    {
        Task<PathfindingResult> FindPathAsync(
            MazeControl.MazeCell[,] maze,
            (int r, int c) start,
            (int r, int c) end,
            Action<int, int, MazeControl.CellType>? onStep = null,
            int delayMs = 15,
            CancellationToken token = default);
    }
}
