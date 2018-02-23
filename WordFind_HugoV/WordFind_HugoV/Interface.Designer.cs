namespace WordFind_HugoV
{
    partial class Interface
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
            this.wordEnterText = new System.Windows.Forms.TextBox();
            this.enterBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.rowText = new System.Windows.Forms.TextBox();
            this.columnText = new System.Windows.Forms.TextBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.rowLbl = new System.Windows.Forms.Label();
            this.columnLbl = new System.Windows.Forms.Label();
            this.loadBtn = new System.Windows.Forms.Button();
            this.puzzleCBox = new System.Windows.Forms.ComboBox();
            this.fileLbl = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.deleteFileBtn = new System.Windows.Forms.Button();
            this.solveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wordEnterText
            // 
            this.wordEnterText.Location = new System.Drawing.Point(12, 8);
            this.wordEnterText.Name = "wordEnterText";
            this.wordEnterText.Size = new System.Drawing.Size(100, 20);
            this.wordEnterText.TabIndex = 0;
            this.wordEnterText.TextChanged += new System.EventHandler(this.wordEnterText_TextChanged);
            // 
            // enterBtn
            // 
            this.enterBtn.Location = new System.Drawing.Point(119, 8);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(75, 23);
            this.enterBtn.TabIndex = 1;
            this.enterBtn.Text = "Enter";
            this.enterBtn.UseVisualStyleBackColor = true;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 446);
            this.listBox1.TabIndex = 2;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(200, 8);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // rowText
            // 
            this.rowText.Location = new System.Drawing.Point(70, 575);
            this.rowText.Name = "rowText";
            this.rowText.Size = new System.Drawing.Size(42, 20);
            this.rowText.TabIndex = 4;
            // 
            // columnText
            // 
            this.columnText.Location = new System.Drawing.Point(70, 601);
            this.columnText.Name = "columnText";
            this.columnText.Size = new System.Drawing.Size(42, 20);
            this.columnText.TabIndex = 5;
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(119, 573);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(75, 23);
            this.generateBtn.TabIndex = 8;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // rowLbl
            // 
            this.rowLbl.AutoSize = true;
            this.rowLbl.Location = new System.Drawing.Point(13, 575);
            this.rowLbl.Name = "rowLbl";
            this.rowLbl.Size = new System.Drawing.Size(29, 13);
            this.rowLbl.TabIndex = 9;
            this.rowLbl.Text = "Row";
            // 
            // columnLbl
            // 
            this.columnLbl.AutoSize = true;
            this.columnLbl.Location = new System.Drawing.Point(13, 608);
            this.columnLbl.Name = "columnLbl";
            this.columnLbl.Size = new System.Drawing.Size(42, 13);
            this.columnLbl.TabIndex = 10;
            this.columnLbl.Text = "Column";
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(178, 495);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 11;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // puzzleCBox
            // 
            this.puzzleCBox.FormattingEnabled = true;
            this.puzzleCBox.Location = new System.Drawing.Point(51, 496);
            this.puzzleCBox.Name = "puzzleCBox";
            this.puzzleCBox.Size = new System.Drawing.Size(121, 21);
            this.puzzleCBox.TabIndex = 12;
            // 
            // fileLbl
            // 
            this.fileLbl.AutoSize = true;
            this.fileLbl.Location = new System.Drawing.Point(13, 497);
            this.fileLbl.Name = "fileLbl";
            this.fileLbl.Size = new System.Drawing.Size(23, 13);
            this.fileLbl.TabIndex = 13;
            this.fileLbl.Text = "File";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 523);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 14;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(94, 523);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 552);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Make puzzle";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // deleteFileBtn
            // 
            this.deleteFileBtn.Location = new System.Drawing.Point(178, 522);
            this.deleteFileBtn.Name = "deleteFileBtn";
            this.deleteFileBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteFileBtn.TabIndex = 17;
            this.deleteFileBtn.Text = "Delete File";
            this.deleteFileBtn.UseVisualStyleBackColor = true;
            this.deleteFileBtn.Click += new System.EventHandler(this.deleteFileBtn_Click);
            // 
            // solveBtn
            // 
            this.solveBtn.Location = new System.Drawing.Point(13, 523);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(75, 23);
            this.solveBtn.TabIndex = 18;
            this.solveBtn.Text = "Solve";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 629);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.deleteFileBtn);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.fileLbl);
            this.Controls.Add(this.puzzleCBox);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.columnLbl);
            this.Controls.Add(this.rowLbl);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.columnText);
            this.Controls.Add(this.rowText);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.enterBtn);
            this.Controls.Add(this.wordEnterText);
            this.Name = "Interface";
            this.Text = "WordFind - HugoV";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wordEnterText;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.TextBox rowText;
        private System.Windows.Forms.TextBox columnText;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Label rowLbl;
        private System.Windows.Forms.Label columnLbl;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.ComboBox puzzleCBox;
        private System.Windows.Forms.Label fileLbl;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button deleteFileBtn;
        private System.Windows.Forms.Button solveBtn;
    }
}

