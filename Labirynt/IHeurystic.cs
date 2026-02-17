using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt
{
    public interface IHeuristic
    {
        string Name { get; }
        double Calculate((int r, int c) current, (int r, int c) target);
    }

    public class ManhattanHeuristic : IHeuristic
    {
        public string Name => "Manhattan";
        public double Calculate((int r, int c) a, (int r, int c) b) =>
            Math.Abs(a.r - b.r) + Math.Abs(a.c - b.c);
    }

    public class EuclideanHeuristic : IHeuristic
    {
        public string Name => "Euclidean";
        public double Calculate((int r, int c) a, (int r, int c) b) =>
            Math.Sqrt(Math.Pow(a.r - b.r, 2) + Math.Pow(a.c - b.c, 2));
    }
}
