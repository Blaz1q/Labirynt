using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Labirynt.MazeControl;

namespace Labirynt
{
    public class MazeTester
    {
        private readonly MazeGeneratorPrim _generator = new MazeGeneratorPrim();

        public async Task RunAutomatedTests(int rows, int cols, double density, string filePath)
        {
            var configurations = new Dictionary<string, IPathfinder>
            {
                { "Dijkstra", new DijkstraPathfinder() },
                { "A-Star Manhattan", new AStarPathfinder(new ManhattanHeuristic()) },
                { "A-Star Euclidean", new AStarPathfinder(new EuclideanHeuristic()) },
                { "Bellman-Ford", new BellmanFordPathfinder() }
            };
            int Rows = rows * 2 + 1;
            int Cols = cols * 2 + 1;
            StringBuilder csv = new StringBuilder();

            // Punkt 3 i 5: Rozbudowany nagłówek dla każdego pojedynczego testu
            csv.AppendLine("ID_Proby;Algorytm;Otwartosc;Czas_ms;Odwiedzone_Wezly;Dlugosc_Sciezki;Rozmiar");

            foreach (var config in configurations)
            {
                // Pętla 30 losowych labiryntów (Punkt: "minimum 30")
                for (int i = 1; i <= 30; i++)
                {
                    // 1. Generowanie nowej instancji problemu
                    var maze = _generator.Generate(rows, cols, density);
                    var start = (1, 1);
                    var end = (Rows - 2, Cols - 2);

                    // 2. Parametry struktury (Punkt 5)
                    double openness = CalculateOpenness(maze)/(Rows*Cols);

                    // 3. Wykonanie algorytmu (Punkt 10 - delayMs = 0 dla czystych pomiarów)
                    var res = await config.Value.FindPathAsync(maze, start, end, null, 0, CancellationToken.None);

                    // 4. Zapis surowego wyniku (Punkt 3 i 9)
                    // Format: ID;Algorytm;Otwartość;Czas;Odwiedzone;Długość;Wielkość
                    // Używamy :F4, aby wymusić zapis 4 miejsc po przecinku w CSV
                    string opennessStr = openness.ToString("F4", CultureInfo.InvariantCulture);
                    string timeStr = res.ComputationTimeMs.ToString("F4", CultureInfo.InvariantCulture);

                    csv.AppendLine($"{i};{config.Key};{opennessStr};{timeStr};{res.VisitedCount};{res.Path.Count};{Rows}x{Cols}");
                    //csv.AppendLine($"{i};{config.Key};{(openness/Rows*Cols):F4};{res.ComputationTimeMs:F4};{res.VisitedCount};{res.Path.Count};{rows}x{cols}");
                }
            }

            // Punkt 19: Pełna automatyzacja zapisu
            try
            {
                File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
            }
            catch (IOException ex)
            {
                // Zabezpieczenie przed błędem dostępu do pliku (np. gdy plik CSV jest otwarty w Excelu)
                Console.WriteLine($"Błąd zapisu pliku: {ex.Message}");
            }
        }

        private double CalculateOpenness(MazeCell[,] maze)
        {
            int empty = 0;
            int total = maze.Length; // total to iloczyn rows * cols
            foreach (var cell in maze)
            {
                if (cell.Type != CellType.Wall)
                    empty++;
            }

            // Rzutujemy empty na double, aby wynik dzielenia był ułamkiem
            return empty;
        }
    }
}