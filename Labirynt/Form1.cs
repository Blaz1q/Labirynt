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
            mazeControl1.CreateMaze(10, 10);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rows = int.Parse(RowsBox.Text.Trim()); 
            int cols = int.Parse(ColsBox.Text.Trim());
            if (rows < 0 || cols < 0) return;
            mazeControl1.CellSize = int.Parse(CellSize.Text);
            mazeControl1.CreateMaze(rows, cols);
        }
    }
}
