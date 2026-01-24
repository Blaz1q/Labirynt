using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirynt
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            mazeControl1.CreateMaze(10, 10, 0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rows = int.Parse(RowsBox.Text.Trim());
            int cols = int.Parse(ColsBox.Text.Trim());
            double density = double.Parse(densityBox.Text.Trim());
            if (rows < 0 || cols < 0) return;
            mazeControl1.CellSize = int.Parse(CellSize.Text);
            mazeControl1.CreateMaze(rows, cols, density);
            mazeControl1.OnSolveFinished += (time) =>
            {
                timeLabel.Text = $"Czas: {time} ms";
            };
        }

        private void button2_Click(object sender, EventArgs e) // Bellman-Ford
        {
            mazeControl1.SolveAlgorithmAsync(new BellmanFordPathfinder());
        }

        private void button3_Click(object sender, EventArgs e) // Dijkstra
        {
            mazeControl1.SolveAlgorithmAsync(new DijkstraPathfinder());
        }

        private void button4_Click(object sender, EventArgs e) // A*
        {
            mazeControl1.SolveAlgorithmAsync(new AStarPathfinder());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            mazeControl1.PrepareForNewAlgorithm();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mazeControl1.delay = int.Parse(numericUpDown1.Text);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void changeBrush() {
            if (radioButton1.Checked)
            {
                mazeControl1.UserBrush = MazeControl.CellType.Wall;
            }
            else if (radioButton2.Checked)
            {
                mazeControl1.UserBrush = MazeControl.CellType.Start;
            }
            else {
                mazeControl1.UserBrush = MazeControl.CellType.End;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.changeBrush();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.changeBrush();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.changeBrush();
        }
    }
}
