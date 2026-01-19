namespace Labirynt
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Labirynt = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            mazeControl1 = new MazeControl();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            ColsBox = new NumericUpDown();
            RowsBox = new NumericUpDown();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            CellSize = new NumericUpDown();
            label3 = new Label();
            Labirynt.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ColsBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RowsBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CellSize).BeginInit();
            SuspendLayout();
            // 
            // Labirynt
            // 
            Labirynt.Controls.Add(flowLayoutPanel1);
            Labirynt.Dock = DockStyle.Fill;
            Labirynt.Location = new Point(0, 0);
            Labirynt.Name = "Labirynt";
            Labirynt.Size = new Size(800, 450);
            Labirynt.TabIndex = 1;
            Labirynt.TabStop = false;
            Labirynt.Text = "Labirynt";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(mazeControl1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 23);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(794, 424);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // mazeControl1
            // 
            mazeControl1.Location = new Point(3, 3);
            mazeControl1.Name = "mazeControl1";
            mazeControl1.Size = new Size(59, 69);
            mazeControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.Location = new Point(482, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(318, 450);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // panel1
            // 
            panel1.Controls.Add(CellSize);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(ColsBox);
            panel1.Controls.Add(RowsBox);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 424);
            panel1.TabIndex = 0;
            // 
            // ColsBox
            // 
            ColsBox.Location = new Point(3, 89);
            ColsBox.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            ColsBox.Name = "ColsBox";
            ColsBox.Size = new Size(150, 27);
            ColsBox.TabIndex = 6;
            ColsBox.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // RowsBox
            // 
            RowsBox.Location = new Point(3, 28);
            RowsBox.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            RowsBox.Name = "RowsBox";
            RowsBox.Size = new Size(150, 27);
            RowsBox.TabIndex = 5;
            RowsBox.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // button1
            // 
            button1.Location = new Point(3, 218);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Generuj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 66);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 3;
            label2.Text = "Kolumny";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 1;
            label1.Text = "Wiersze";
            // 
            // CellSize
            // 
            CellSize.Location = new Point(3, 163);
            CellSize.Name = "CellSize";
            CellSize.Size = new Size(150, 27);
            CellSize.TabIndex = 8;
            CellSize.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 140);
            label3.Name = "label3";
            label3.Size = new Size(122, 20);
            label3.TabIndex = 7;
            label3.Text = "Rozmiar komórki";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(Labirynt);
            Name = "Form1";
            Text = "Form1";
            Labirynt.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ColsBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)RowsBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)CellSize).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox Labirynt;
        private FlowLayoutPanel flowLayoutPanel1;
        private MazeControl mazeControl1;
        private GroupBox groupBox1;
        private Panel panel1;
        private Button button1;
        private Label label2;
        private Label label1;
        private NumericUpDown ColsBox;
        private NumericUpDown RowsBox;
        private NumericUpDown CellSize;
        private Label label3;
    }
}