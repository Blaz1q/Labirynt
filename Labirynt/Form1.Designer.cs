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
            groupBox2 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            densityBox = new NumericUpDown();
            label6 = new Label();
            numericUpDown1 = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            timeLabel = new Label();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            CellSize = new NumericUpDown();
            label3 = new Label();
            ColsBox = new NumericUpDown();
            RowsBox = new NumericUpDown();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            button6 = new Button();
            Labirynt.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)densityBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CellSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ColsBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RowsBox).BeginInit();
            SuspendLayout();
            // 
            // Labirynt
            // 
            Labirynt.Controls.Add(flowLayoutPanel1);
            Labirynt.Dock = DockStyle.Fill;
            Labirynt.Location = new Point(0, 0);
            Labirynt.Name = "Labirynt";
            Labirynt.Size = new Size(1014, 597);
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
            flowLayoutPanel1.Size = new Size(1008, 571);
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
            groupBox1.Location = new Point(696, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(318, 597);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // panel1
            // 
            panel1.Controls.Add(button6);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(densityBox);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(timeLabel);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
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
            panel1.Size = new Size(312, 571);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton3);
            groupBox2.Controls.Add(radioButton2);
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Location = new Point(147, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(156, 155);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Wstaw";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(9, 86);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(61, 24);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "Stop";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(9, 56);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(61, 24);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "Start";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(9, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(72, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Ściany";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // densityBox
            // 
            densityBox.DecimalPlaces = 2;
            densityBox.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            densityBox.Location = new Point(3, 240);
            densityBox.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            densityBox.Name = "densityBox";
            densityBox.Size = new Size(85, 27);
            densityBox.TabIndex = 18;
            densityBox.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 217);
            label6.Name = "label6";
            label6.Size = new Size(104, 20);
            label6.TabIndex = 17;
            label6.Text = "Gęstość (0 - 1)";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown1.Location = new Point(3, 187);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(85, 27);
            numericUpDown1.TabIndex = 16;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 164);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 15;
            label5.Text = "Opóźnienie";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(151, 341);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 14;
            label4.Text = "Czas";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(151, 374);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(44, 20);
            timeLabel.TabIndex = 13;
            timeLabel.Text = "00:00";
            // 
            // button5
            // 
            button5.Location = new Point(151, 296);
            button5.Name = "button5";
            button5.Size = new Size(122, 29);
            button5.TabIndex = 12;
            button5.Text = "STOP";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(3, 434);
            button4.Name = "button4";
            button4.Size = new Size(122, 29);
            button4.TabIndex = 11;
            button4.Text = "A*";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(3, 388);
            button3.Name = "button3";
            button3.Size = new Size(122, 29);
            button3.TabIndex = 10;
            button3.Text = "Djikstra";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(3, 341);
            button2.Name = "button2";
            button2.Size = new Size(122, 29);
            button2.TabIndex = 9;
            button2.Text = "BellmanFord";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // CellSize
            // 
            CellSize.Location = new Point(3, 134);
            CellSize.Name = "CellSize";
            CellSize.Size = new Size(85, 27);
            CellSize.TabIndex = 8;
            CellSize.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 111);
            label3.Name = "label3";
            label3.Size = new Size(122, 20);
            label3.TabIndex = 7;
            label3.Text = "Rozmiar komórki";
            // 
            // ColsBox
            // 
            ColsBox.Location = new Point(3, 81);
            ColsBox.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            ColsBox.Name = "ColsBox";
            ColsBox.Size = new Size(85, 27);
            ColsBox.TabIndex = 6;
            ColsBox.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // RowsBox
            // 
            RowsBox.Location = new Point(3, 28);
            RowsBox.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            RowsBox.Name = "RowsBox";
            RowsBox.Size = new Size(85, 27);
            RowsBox.TabIndex = 5;
            RowsBox.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // button1
            // 
            button1.Location = new Point(3, 296);
            button1.Name = "button1";
            button1.Size = new Size(122, 29);
            button1.TabIndex = 4;
            button1.Text = "Generuj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 58);
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
            // button6
            // 
            button6.Location = new Point(3, 478);
            button6.Name = "button6";
            button6.Size = new Size(122, 29);
            button6.TabIndex = 20;
            button6.Text = "Testuj";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 597);
            Controls.Add(groupBox1);
            Controls.Add(Labirynt);
            Name = "Form1";
            Text = "Form1";
            Labirynt.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)densityBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)CellSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)ColsBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)RowsBox).EndInit();
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
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label timeLabel;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private NumericUpDown densityBox;
        private Label label6;
        private GroupBox groupBox2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Button button6;
    }
}