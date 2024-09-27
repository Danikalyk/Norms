namespace Norms
{
    partial class ProgrammConverter
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
            label1 = new System.Windows.Forms.Label();
            checkBox1 = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            comboBox2 = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            checkBox2 = new System.Windows.Forms.CheckBox();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            button3 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 39);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(154, 20);
            label1.TabIndex = 0;
            label1.Text = "Текущая программа:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox1.Enabled = false;
            checkBox1.Location = new System.Drawing.Point(9, 209);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(502, 24);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Указать путь сохранения программы/изменить номер программы";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(368, 39);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(140, 20);
            label2.TabIndex = 2;
            label2.Text = "Новая программа:";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 73);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(60, 20);
            label3.TabIndex = 3;
            label3.Text = "Станок:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(93, 73);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(161, 20);
            label4.TabIndex = 4;
            label4.Text = "Выберите программу";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(429, 86);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(60, 20);
            label5.TabIndex = 5;
            label5.Text = "Станок:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "5030", "3030", "1005" });
            comboBox1.Location = new System.Drawing.Point(495, 83);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(151, 28);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 171);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(34, 20);
            label6.TabIndex = 7;
            label6.Text = "Газ:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(93, 171);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(161, 20);
            label7.TabIndex = 8;
            label7.Text = "Выберите программу";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(429, 131);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(34, 20);
            label8.TabIndex = 9;
            label8.Text = "Газ:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "O2", "N2 (Воздух)" });
            comboBox2.Location = new System.Drawing.Point(495, 128);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(151, 28);
            comboBox2.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(529, 269);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(151, 54);
            button1.TabIndex = 11;
            button1.Text = "КОНВЕРТИРОВАТЬ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(9, 269);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(142, 54);
            button2.TabIndex = 12;
            button2.Text = "ЗАГРУЗИТЬ ПРОГРАММУ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new System.Drawing.Point(9, 239);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(380, 24);
            checkBox2.TabIndex = 13;
            checkBox2.Text = "Не изменять номер программы/путь сохранения";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(169, 39);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(161, 20);
            label9.TabIndex = 14;
            label9.Text = "Выберите программу";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(514, 39);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(58, 20);
            label10.TabIndex = 15;
            label10.Text = "label10";
            label10.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(170, 9);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(161, 20);
            label11.TabIndex = 16;
            label11.Text = "Выберите программу";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(9, 9);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(152, 20);
            label12.TabIndex = 17;
            label12.Text = "Путь до программы:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(12, 102);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(75, 20);
            label13.TabIndex = 18;
            label13.Text = "Толщина:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(93, 102);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(161, 20);
            label14.TabIndex = 19;
            label14.Text = "Выберите программу";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(12, 136);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(63, 20);
            label15.TabIndex = 20;
            label15.Text = "Металл:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(93, 136);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(161, 20);
            label16.TabIndex = 21;
            label16.Text = "Выберите программу";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(429, 167);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(217, 29);
            button3.TabIndex = 22;
            button3.Text = "УКАЗАТЬ РАЗМЕР ЛИСТА";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ProgrammConverter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            ClientSize = new System.Drawing.Size(686, 335);
            Controls.Add(button3);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(checkBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "ProgrammConverter";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Конвертация программ";
            FormClosing += ProgrammConverter_FormClosing;
            Load += ProgrammConverter_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button3;
    }
}