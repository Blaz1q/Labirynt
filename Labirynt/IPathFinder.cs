using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labirynt.MazeControl;

namespace Labirynt
{
    public interface IPathfinder
    {
        Task<List<(int r, int c)>> FindPathAsync(
            MazeCell[,] maze,
            (int r, int c) start,
            (int r, int c) end,
            Action<int, int, CellType>? onStep = null,
            int delayMs = 15,
            CancellationToken token = default);
    }
}
