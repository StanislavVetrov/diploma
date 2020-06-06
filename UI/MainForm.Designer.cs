namespace UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.нейроннаяСетьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обучитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.какИспользоватьПрограммуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputsBox = new System.Windows.Forms.TextBox();
            this.answersBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ex1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.errorShow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SubmitInputs = new System.Windows.Forms.Button();
            this.SubmitAnswers = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(582, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.нейроннаяСетьToolStripMenuItem});
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // нейроннаяСетьToolStripMenuItem
            // 
            this.нейроннаяСетьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обучитьToolStripMenuItem});
            this.нейроннаяСетьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("нейроннаяСетьToolStripMenuItem.Image")));
            this.нейроннаяСетьToolStripMenuItem.Name = "нейроннаяСетьToolStripMenuItem";
            this.нейроннаяСетьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.нейроннаяСетьToolStripMenuItem.Text = "Нейронная сеть";
            // 
            // обучитьToolStripMenuItem
            // 
            this.обучитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("обучитьToolStripMenuItem.Image")));
            this.обучитьToolStripMenuItem.Name = "обучитьToolStripMenuItem";
            this.обучитьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.обучитьToolStripMenuItem.Text = "Обучить";
            this.обучитьToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.какИспользоватьПрограммуToolStripMenuItem});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // какИспользоватьПрограммуToolStripMenuItem
            // 
            this.какИспользоватьПрограммуToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("какИспользоватьПрограммуToolStripMenuItem.Image")));
            this.какИспользоватьПрограммуToolStripMenuItem.Name = "какИспользоватьПрограммуToolStripMenuItem";
            this.какИспользоватьПрограммуToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.какИспользоватьПрограммуToolStripMenuItem.Text = "Как использовать программу";
            // 
            // inputsBox
            // 
            this.inputsBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.inputsBox.Location = new System.Drawing.Point(211, 71);
            this.inputsBox.Name = "inputsBox";
            this.inputsBox.Size = new System.Drawing.Size(215, 20);
            this.inputsBox.TabIndex = 1;
            this.inputsBox.Text = "Путь к файлу с обучающей выборкой ...";
            // 
            // answersBox
            // 
            this.answersBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.answersBox.Location = new System.Drawing.Point(211, 114);
            this.answersBox.Name = "answersBox";
            this.answersBox.Size = new System.Drawing.Size(215, 20);
            this.answersBox.TabIndex = 4;
            this.answersBox.Text = "Путь к файлу с примерами...";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(280, 154);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(214, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Предполагаемые символы";
            // 
            // ex1
            // 
            this.ex1.Location = new System.Drawing.Point(121, 183);
            this.ex1.Name = "ex1";
            this.ex1.Size = new System.Drawing.Size(83, 23);
            this.ex1.TabIndex = 9;
            this.ex1.Text = "Пример №1";
            this.ex1.UseVisualStyleBackColor = true;
            this.ex1.Click += new System.EventHandler(this.ex1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(121, 212);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Пример №2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ex2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(121, 241);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Пример №3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ex3_Click);
            // 
            // errorShow
            // 
            this.errorShow.Location = new System.Drawing.Point(280, 227);
            this.errorShow.Multiline = true;
            this.errorShow.Name = "errorShow";
            this.errorShow.Size = new System.Drawing.Size(252, 103);
            this.errorShow.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Величина ошибки:";
            // 
            // SubmitInputs
            // 
            this.SubmitInputs.Location = new System.Drawing.Point(120, 71);
            this.SubmitInputs.Name = "SubmitInputs";
            this.SubmitInputs.Size = new System.Drawing.Size(75, 23);
            this.SubmitInputs.TabIndex = 2;
            this.SubmitInputs.Text = "Указать";
            this.SubmitInputs.UseVisualStyleBackColor = true;
            this.SubmitInputs.Click += new System.EventHandler(this.SubmitInputs_Click);
            // 
            // SubmitAnswers
            // 
            this.SubmitAnswers.Location = new System.Drawing.Point(120, 114);
            this.SubmitAnswers.Name = "SubmitAnswers";
            this.SubmitAnswers.Size = new System.Drawing.Size(75, 23);
            this.SubmitAnswers.TabIndex = 3;
            this.SubmitAnswers.Text = "Указать";
            this.SubmitAnswers.UseVisualStyleBackColor = true;
            this.SubmitAnswers.Click += new System.EventHandler(this.SubmitAnswers_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 342);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.errorShow);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ex1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.answersBox);
            this.Controls.Add(this.SubmitAnswers);
            this.Controls.Add(this.SubmitInputs);
            this.Controls.Add(this.inputsBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Персептрон";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem нейроннаяСетьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обучитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem какИспользоватьПрограммуToolStripMenuItem;
        private System.Windows.Forms.TextBox inputsBox;
        private System.Windows.Forms.TextBox answersBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ex3;
        private System.Windows.Forms.Button ex2;
        private System.Windows.Forms.Button ex1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox errorShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SubmitInputs;
        private System.Windows.Forms.Button SubmitAnswers;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

