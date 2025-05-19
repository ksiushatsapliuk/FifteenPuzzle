namespace FifteenPuzzle
{
    partial class FifteenPuzzleForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Label moveCounterLabel;
        private System.Windows.Forms.Label recordLabel;
        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FifteenPuzzleForm));
            newGameButton = new Button();
            solveButton = new Button();
            moveCounterLabel = new Label();
            recordLabel = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            button16 = new Button();
            button15 = new Button();
            button14 = new Button();
            button13 = new Button();
            button12 = new Button();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // newGameButton
            // 
            newGameButton.BackColor = Color.DarkViolet;
            newGameButton.FlatStyle = FlatStyle.Flat;
            newGameButton.Font = new Font("Cambria", 14F, FontStyle.Bold);
            newGameButton.ForeColor = Color.White;
            newGameButton.Location = new Point(120, 12);
            newGameButton.Name = "newGameButton";
            newGameButton.Size = new Size(150, 50);
            newGameButton.TabIndex = 0;
            newGameButton.Text = "New Game";
            newGameButton.UseVisualStyleBackColor = false;
            newGameButton.Click += newGameButton_Click;
            // 
            // solveButton
            // 
            solveButton.BackColor = Color.DarkViolet;
            solveButton.FlatStyle = FlatStyle.Flat;
            solveButton.Font = new Font("Cambria", 14F, FontStyle.Bold);
            solveButton.ForeColor = Color.White;
            solveButton.Location = new Point(120, 72);
            solveButton.Name = "solveButton";
            solveButton.Size = new Size(150, 43);
            solveButton.TabIndex = 0;
            solveButton.Text = "Auto Solve";
            solveButton.UseVisualStyleBackColor = false;
            solveButton.Click += solveButton_Click;
            // 
            // moveCounterLabel
            // 
            moveCounterLabel.Font = new Font("Cambria", 14F, FontStyle.Bold);
            moveCounterLabel.ForeColor = Color.Purple;
            moveCounterLabel.Location = new Point(369, 65);
            moveCounterLabel.Name = "moveCounterLabel";
            moveCounterLabel.Size = new Size(200, 50);
            moveCounterLabel.TabIndex = 0;
            moveCounterLabel.Text = "Moves: 0";
            moveCounterLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // recordLabel
            // 
            recordLabel.Font = new Font("Cambria", 14F, FontStyle.Bold);
            recordLabel.ForeColor = Color.Purple;
            recordLabel.Location = new Point(369, 12);
            recordLabel.Name = "recordLabel";
            recordLabel.Size = new Size(200, 50);
            recordLabel.TabIndex = 0;
            recordLabel.Text = "Record: N/A";
            recordLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.DarkViolet;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(button16, 3, 3);
            tableLayoutPanel1.Controls.Add(button15, 2, 3);
            tableLayoutPanel1.Controls.Add(button14, 1, 3);
            tableLayoutPanel1.Controls.Add(button13, 0, 3);
            tableLayoutPanel1.Controls.Add(button12, 3, 2);
            tableLayoutPanel1.Controls.Add(button11, 2, 2);
            tableLayoutPanel1.Controls.Add(button10, 1, 2);
            tableLayoutPanel1.Controls.Add(button9, 0, 2);
            tableLayoutPanel1.Controls.Add(button8, 3, 1);
            tableLayoutPanel1.Controls.Add(button7, 2, 1);
            tableLayoutPanel1.Controls.Add(button6, 1, 1);
            tableLayoutPanel1.Controls.Add(button5, 0, 1);
            tableLayoutPanel1.Controls.Add(button4, 3, 0);
            tableLayoutPanel1.Controls.Add(button3, 2, 0);
            tableLayoutPanel1.Controls.Add(button2, 1, 0);
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Location = new Point(119, 129);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(450, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button16
            // 
            button16.BackColor = Color.FromArgb(255, 210, 255);
            button16.Dock = DockStyle.Fill;
            button16.FlatStyle = FlatStyle.Flat;
            button16.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button16.ForeColor = Color.Purple;
            button16.Location = new Point(337, 337);
            button16.Margin = new Padding(1);
            button16.Name = "button16";
            button16.Size = new Size(112, 112);
            button16.TabIndex = 15;
            button16.Text = "-";
            button16.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            button15.BackColor = Color.FromArgb(255, 210, 255);
            button15.Dock = DockStyle.Fill;
            button15.FlatStyle = FlatStyle.Flat;
            button15.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button15.ForeColor = Color.Purple;
            button15.Location = new Point(225, 337);
            button15.Margin = new Padding(1);
            button15.Name = "button15";
            button15.Size = new Size(110, 112);
            button15.TabIndex = 14;
            button15.Text = "-";
            button15.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            button14.BackColor = Color.FromArgb(255, 210, 255);
            button14.Dock = DockStyle.Fill;
            button14.FlatStyle = FlatStyle.Flat;
            button14.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button14.ForeColor = Color.Purple;
            button14.Location = new Point(113, 337);
            button14.Margin = new Padding(1);
            button14.Name = "button14";
            button14.Size = new Size(110, 112);
            button14.TabIndex = 13;
            button14.Text = "-";
            button14.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            button13.BackColor = Color.FromArgb(255, 210, 255);
            button13.Dock = DockStyle.Fill;
            button13.FlatStyle = FlatStyle.Flat;
            button13.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button13.ForeColor = Color.Purple;
            button13.Location = new Point(1, 337);
            button13.Margin = new Padding(1);
            button13.Name = "button13";
            button13.Size = new Size(110, 112);
            button13.TabIndex = 12;
            button13.Text = "-";
            button13.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            button12.BackColor = Color.FromArgb(255, 210, 255);
            button12.Dock = DockStyle.Fill;
            button12.FlatStyle = FlatStyle.Flat;
            button12.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button12.ForeColor = Color.Purple;
            button12.Location = new Point(337, 225);
            button12.Margin = new Padding(1);
            button12.Name = "button12";
            button12.Size = new Size(112, 110);
            button12.TabIndex = 11;
            button12.Text = "-";
            button12.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            button11.BackColor = Color.FromArgb(255, 210, 255);
            button11.Dock = DockStyle.Fill;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button11.ForeColor = Color.Purple;
            button11.Location = new Point(225, 225);
            button11.Margin = new Padding(1);
            button11.Name = "button11";
            button11.Size = new Size(110, 110);
            button11.TabIndex = 10;
            button11.Text = "-";
            button11.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(255, 210, 255);
            button10.Dock = DockStyle.Fill;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button10.ForeColor = Color.Purple;
            button10.Location = new Point(113, 225);
            button10.Margin = new Padding(1);
            button10.Name = "button10";
            button10.Size = new Size(110, 110);
            button10.TabIndex = 9;
            button10.Text = "-";
            button10.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(255, 210, 255);
            button9.Dock = DockStyle.Fill;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button9.ForeColor = Color.Purple;
            button9.Location = new Point(1, 225);
            button9.Margin = new Padding(1);
            button9.Name = "button9";
            button9.Size = new Size(110, 110);
            button9.TabIndex = 8;
            button9.Text = "-";
            button9.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(255, 210, 255);
            button8.Dock = DockStyle.Fill;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button8.ForeColor = Color.Purple;
            button8.Location = new Point(337, 113);
            button8.Margin = new Padding(1);
            button8.Name = "button8";
            button8.Size = new Size(112, 110);
            button8.TabIndex = 7;
            button8.Text = "-";
            button8.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(255, 210, 255);
            button7.Dock = DockStyle.Fill;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button7.ForeColor = Color.Purple;
            button7.Location = new Point(225, 113);
            button7.Margin = new Padding(1);
            button7.Name = "button7";
            button7.Size = new Size(110, 110);
            button7.TabIndex = 6;
            button7.Text = "-";
            button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(255, 210, 255);
            button6.Dock = DockStyle.Fill;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button6.ForeColor = Color.Purple;
            button6.Location = new Point(113, 113);
            button6.Margin = new Padding(1);
            button6.Name = "button6";
            button6.Size = new Size(110, 110);
            button6.TabIndex = 5;
            button6.Text = "-";
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 210, 255);
            button5.Dock = DockStyle.Fill;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button5.ForeColor = Color.Purple;
            button5.Location = new Point(1, 113);
            button5.Margin = new Padding(1);
            button5.Name = "button5";
            button5.Size = new Size(110, 110);
            button5.TabIndex = 4;
            button5.Text = "-";
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(255, 210, 255);
            button4.Dock = DockStyle.Fill;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button4.ForeColor = Color.Purple;
            button4.Location = new Point(337, 1);
            button4.Margin = new Padding(1);
            button4.Name = "button4";
            button4.Size = new Size(112, 110);
            button4.TabIndex = 3;
            button4.Text = "-";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 210, 255);
            button3.Dock = DockStyle.Fill;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button3.ForeColor = Color.Purple;
            button3.Location = new Point(225, 1);
            button3.Margin = new Padding(1);
            button3.Name = "button3";
            button3.Size = new Size(110, 110);
            button3.TabIndex = 2;
            button3.Text = "-";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 210, 255);
            button2.Dock = DockStyle.Fill;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.ForeColor = Color.Purple;
            button2.Location = new Point(113, 1);
            button2.Margin = new Padding(1);
            button2.Name = "button2";
            button2.Size = new Size(110, 110);
            button2.TabIndex = 1;
            button2.Text = "-";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 210, 255);
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.Purple;
            button1.Location = new Point(1, 1);
            button1.Margin = new Padding(1);
            button1.Name = "button1";
            button1.Size = new Size(110, 110);
            button1.TabIndex = 0;
            button1.Text = "-";
            button1.UseVisualStyleBackColor = false;
            // 
            // FifteenPuzzleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Plum;
            ClientSize = new Size(692, 603);
            Controls.Add(recordLabel);
            Controls.Add(moveCounterLabel);
            Controls.Add(solveButton);
            Controls.Add(newGameButton);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FifteenPuzzleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "15 Game";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;

        private Button button16;
        private Button button15;
        private Button button14;
        private Button button13;
        private Button button12;
        private Button button11;
        private Button button10;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
    }

}
