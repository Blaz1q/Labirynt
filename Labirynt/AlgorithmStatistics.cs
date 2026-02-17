using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt
{
    public class AlgorithmStatistics
    {
        public double AverageTime { get; private set; }
        public double MedianTime { get; private set; }
        public double StdDev { get; private set; }
        public int AvgVisited { get; private set; }

        public AlgorithmStatistics(List<PathfindingResult> results)
        {
            var times = results.Select(r => r.ComputationTimeMs).OrderBy(t => t).ToList();

            AverageTime = times.Average();
            MedianTime = times[times.Count / 2];
            StdDev = Math.Sqrt(times.Average(v => Math.Pow(v - AverageTime, 2)));
            AvgVisited = (int)results.Average(r => r.VisitedCount);
        }
    }
}
