namespace Norms
{
    partial class WeldingCalcForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Amperage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TimeWelding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TimePlumbing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            WireMass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CrossSecArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            WireDiameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DetailsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SborkaMass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Electrod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            textBox1 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            textBox3 = new System.Windows.Forms.TextBox();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            comboBox2 = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            comboBox3 = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            button3 = new System.Windows.Forms.Button();
            label8 = new System.Windows.Forms.Label();
            numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            label9 = new System.Windows.Forms.Label();
            numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            label10 = new System.Windows.Forms.Label();
            comboBox4 = new System.Windows.Forms.ComboBox();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label17 = new System.Windows.Forms.Label();
            comboBox5 = new System.Windows.Forms.ComboBox();
            numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            checkBox2 = new System.Windows.Forms.CheckBox();
            comboBox6 = new System.Windows.Forms.ComboBox();
            checkBox3 = new System.Windows.Forms.CheckBox();
            label15 = new System.Windows.Forms.Label();
            button4 = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            comboBox8 = new System.Windows.Forms.ComboBox();
            label23 = new System.Windows.Forms.Label();
            textBox4 = new System.Windows.Forms.TextBox();
            label14 = new System.Windows.Forms.Label();
            textBox6 = new System.Windows.Forms.TextBox();
            label18 = new System.Windows.Forms.Label();
            textBox7 = new System.Windows.Forms.TextBox();
            label19 = new System.Windows.Forms.Label();
            textBox8 = new System.Windows.Forms.TextBox();
            label20 = new System.Windows.Forms.Label();
            textBox9 = new System.Windows.Forms.TextBox();
            label21 = new System.Windows.Forms.Label();
            checkBox1 = new System.Windows.Forms.CheckBox();
            label16 = new System.Windows.Forms.Label();
            comboBox7 = new System.Windows.Forms.ComboBox();
            textBox5 = new System.Windows.Forms.TextBox();
            label22 = new System.Windows.Forms.Label();
            button5 = new System.Windows.Forms.Button();
            checkBox4 = new System.Windows.Forms.CheckBox();
            label24 = new System.Windows.Forms.Label();
            comboBox9 = new System.Windows.Forms.ComboBox();
            label25 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = System.Drawing.Color.SteelBlue;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Number, Type, Length, Amperage, TimeWelding, TimePlumbing, WireMass, CrossSecArea, WireDiameter, DetailsCount, SborkaMass, Electrod });
            dataGridView1.Location = new System.Drawing.Point(12, 220);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new System.Drawing.Size(967, 261);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowHeaderMouseDoubleClick += dataGridView1_RowHeaderMouseDoubleClick;
            // 
            // Number
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            Number.DefaultCellStyle = dataGridViewCellStyle1;
            Number.HeaderText = "Номер шва";
            Number.MinimumWidth = 6;
            Number.Name = "Number";
            Number.ReadOnly = true;
            Number.Width = 50;
            // 
            // Type
            // 
            Type.HeaderText = "Тип шва";
            Type.MinimumWidth = 6;
            Type.Name = "Type";
            Type.ReadOnly = true;
            Type.Width = 125;
            // 
            // Length
            // 
            Length.HeaderText = "Длина шва";
            Length.MinimumWidth = 6;
            Length.Name = "Length";
            Length.ReadOnly = true;
            Length.Width = 125;
            // 
            // Amperage
            // 
            Amperage.HeaderText = "Сила тока";
            Amperage.MinimumWidth = 6;
            Amperage.Name = "Amperage";
            Amperage.ReadOnly = true;
            Amperage.Width = 125;
            // 
            // TimeWelding
            // 
            TimeWelding.HeaderText = "Время сварки";
            TimeWelding.MinimumWidth = 6;
            TimeWelding.Name = "TimeWelding";
            TimeWelding.ReadOnly = true;
            TimeWelding.Width = 125;
            // 
            // TimePlumbing
            // 
            TimePlumbing.HeaderText = "Время слесарных";
            TimePlumbing.MinimumWidth = 6;
            TimePlumbing.Name = "TimePlumbing";
            TimePlumbing.ReadOnly = true;
            TimePlumbing.Width = 125;
            // 
            // WireMass
            // 
            WireMass.HeaderText = "Масса проволоки";
            WireMass.MinimumWidth = 6;
            WireMass.Name = "WireMass";
            WireMass.ReadOnly = true;
            WireMass.Width = 125;
            // 
            // CrossSecArea
            // 
            CrossSecArea.HeaderText = "Площадь сечения";
            CrossSecArea.MinimumWidth = 6;
            CrossSecArea.Name = "CrossSecArea";
            CrossSecArea.ReadOnly = true;
            CrossSecArea.Visible = false;
            CrossSecArea.Width = 125;
            // 
            // WireDiameter
            // 
            WireDiameter.HeaderText = "Диаметр проволоки";
            WireDiameter.MinimumWidth = 6;
            WireDiameter.Name = "WireDiameter";
            WireDiameter.ReadOnly = true;
            WireDiameter.Visible = false;
            WireDiameter.Width = 125;
            // 
            // DetailsCount
            // 
            DetailsCount.HeaderText = "Количество деталаей";
            DetailsCount.MinimumWidth = 6;
            DetailsCount.Name = "DetailsCount";
            DetailsCount.ReadOnly = true;
            DetailsCount.Visible = false;
            DetailsCount.Width = 125;
            // 
            // SborkaMass
            // 
            SborkaMass.HeaderText = "Масса сборки";
            SborkaMass.MinimumWidth = 6;
            SborkaMass.Name = "SborkaMass";
            SborkaMass.ReadOnly = true;
            SborkaMass.Visible = false;
            SborkaMass.Width = 125;
            // 
            // Electrod
            // 
            Electrod.HeaderText = "Электрод";
            Electrod.MinimumWidth = 6;
            Electrod.Name = "Electrod";
            Electrod.ReadOnly = true;
            Electrod.Visible = false;
            Electrod.Width = 125;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(139, 491);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(122, 27);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(985, 417);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(84, 63);
            button1.TabIndex = 2;
            button1.Text = "Очистить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(985, 354);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(84, 57);
            button2.TabIndex = 3;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 495);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(121, 20);
            label1.TabIndex = 5;
            label1.Text = "Общее T сварки";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(267, 493);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(136, 20);
            label2.TabIndex = 8;
            label2.Text = "Общее T слесарки";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(790, 494);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(155, 20);
            label3.TabIndex = 10;
            label3.Text = "Общая M проволоки";
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(409, 490);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(122, 27);
            textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(951, 490);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new System.Drawing.Size(118, 27);
            textBox3.TabIndex = 12;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(802, 11);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(158, 28);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(726, 14);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(70, 20);
            label4.TabIndex = 14;
            label4.Text = "Тип шва:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(18, 55);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(81, 20);
            label5.TabIndex = 15;
            label5.Text = "Катет, мм.:";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(105, 52);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(100, 28);
            comboBox2.TabIndex = 16;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(211, 187);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(109, 20);
            label6.TabIndex = 17;
            label6.Text = "Длина шва, м.:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new System.Drawing.Point(399, 185);
            numericUpDown1.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(100, 27);
            numericUpDown1.TabIndex = 18;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(399, 89);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(100, 28);
            comboBox3.TabIndex = 19;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(211, 92);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(186, 20);
            label7.TabIndex = 20;
            label7.Text = "Диаметр проволоки, мм.:";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(985, 287);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(84, 61);
            button3.TabIndex = 21;
            button3.Text = "Добавить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(211, 124);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(180, 20);
            label8.TabIndex = 22;
            label8.Text = "Количество деталей, шт.:";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new System.Drawing.Point(400, 122);
            numericUpDown2.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new System.Drawing.Size(99, 27);
            numericUpDown2.TabIndex = 23;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(211, 154);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(132, 20);
            label9.TabIndex = 24;
            label9.Text = "Масса сборки, кг.:";
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 1;
            numericUpDown3.Location = new System.Drawing.Point(399, 152);
            numericUpDown3.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new System.Drawing.Size(100, 27);
            numericUpDown3.TabIndex = 25;
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(18, 14);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(81, 20);
            label10.TabIndex = 26;
            label10.Text = "Материал:";
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new System.Drawing.Point(105, 11);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new System.Drawing.Size(251, 28);
            comboBox4.TabIndex = 27;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(507, 155);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(97, 20);
            label11.TabIndex = 28;
            label11.Text = "Сила тока, A:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(610, 155);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(17, 20);
            label12.TabIndex = 29;
            label12.Text = "0";
            label12.Click += label12_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(507, 59);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(41, 20);
            label13.TabIndex = 31;
            label13.Text = "Tнш:";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox1.Image = Properties.Resources.laser_burst;
            pictureBox1.Location = new System.Drawing.Point(12, 124);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(121, 90);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(362, 14);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(87, 20);
            label17.TabIndex = 36;
            label17.Text = "Тип сварки";
            // 
            // comboBox5
            // 
            comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new System.Drawing.Point(455, 11);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new System.Drawing.Size(210, 28);
            comboBox5.TabIndex = 37;
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            // 
            // numericUpDown5
            // 
            numericUpDown5.DecimalPlaces = 2;
            numericUpDown5.Enabled = false;
            numericUpDown5.Location = new System.Drawing.Point(595, 54);
            numericUpDown5.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new System.Drawing.Size(125, 27);
            numericUpDown5.TabIndex = 39;
            numericUpDown5.ValueChanged += numericUpDown5_ValueChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox2.Location = new System.Drawing.Point(966, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(79, 44);
            checkBox2.TabIndex = 40;
            checkBox2.Text = "Авто\r\nрежим";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // comboBox6
            // 
            comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox6.FormattingEnabled = true;
            comboBox6.Items.AddRange(new object[] { "100", "200", "300" });
            comboBox6.Location = new System.Drawing.Point(680, 184);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new System.Drawing.Size(149, 28);
            comboBox6.TabIndex = 42;
            comboBox6.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new System.Drawing.Point(835, 186);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(63, 24);
            checkBox3.TabIndex = 43;
            checkBox3.Text = "Скос";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(505, 187);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(169, 20);
            label15.TabIndex = 45;
            label15.Text = "Шаг прихваток, мм. до:";
            // 
            // button4
            // 
            button4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button4.Location = new System.Drawing.Point(985, 220);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(84, 61);
            button4.TabIndex = 48;
            button4.Text = "<------";
            button4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox8);
            groupBox1.Controls.Add(label23);
            groupBox1.Location = new System.Drawing.Point(1075, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(228, 473);
            groupBox1.TabIndex = 49;
            groupBox1.TabStop = false;
            groupBox1.Text = "Коэффициенты";
            // 
            // comboBox8
            // 
            comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox8.FormattingEnabled = true;
            comboBox8.Items.AddRange(new object[] { "Нижнее", "Вертикальное", "Горизонтальное", "Потолочное", "Наклонное нижнее", "Наклонное потолочное" });
            comboBox8.Location = new System.Drawing.Point(6, 50);
            comboBox8.Name = "comboBox8";
            comboBox8.Size = new System.Drawing.Size(216, 28);
            comboBox8.TabIndex = 1;
            comboBox8.SelectedIndexChanged += comboBox8_SelectedIndexChanged;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(50, 27);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(123, 20);
            label23.TabIndex = 0;
            label23.Text = "Положение шва";
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(666, 490);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new System.Drawing.Size(118, 27);
            textBox4.TabIndex = 51;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(537, 494);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(123, 20);
            label14.TabIndex = 50;
            label14.Text = "Общее T сборки";
            // 
            // textBox6
            // 
            textBox6.Location = new System.Drawing.Point(835, 85);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new System.Drawing.Size(125, 27);
            textBox6.TabIndex = 55;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(726, 87);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(84, 20);
            label18.TabIndex = 54;
            label18.Text = "T слесарки";
            // 
            // textBox7
            // 
            textBox7.Location = new System.Drawing.Point(595, 121);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new System.Drawing.Size(125, 27);
            textBox7.TabIndex = 57;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(507, 124);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(69, 20);
            label19.TabIndex = 56;
            label19.Text = "T сварки";
            // 
            // textBox8
            // 
            textBox8.Enabled = false;
            textBox8.Location = new System.Drawing.Point(835, 117);
            textBox8.Name = "textBox8";
            textBox8.ReadOnly = true;
            textBox8.Size = new System.Drawing.Size(125, 27);
            textBox8.TabIndex = 59;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(726, 120);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(71, 20);
            label20.TabIndex = 58;
            label20.Text = "T правки";
            // 
            // textBox9
            // 
            textBox9.Location = new System.Drawing.Point(835, 152);
            textBox9.Name = "textBox9";
            textBox9.ReadOnly = true;
            textBox9.Size = new System.Drawing.Size(125, 27);
            textBox9.TabIndex = 61;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(726, 154);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(103, 20);
            label21.TabIndex = 60;
            label21.Text = "M проволоки";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(966, 119);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(82, 24);
            checkBox1.TabIndex = 62;
            checkBox1.Text = "Правка";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(211, 59);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(134, 20);
            label16.TabIndex = 64;
            label16.Text = "Площадь сечения";
            // 
            // comboBox7
            // 
            comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox7.FormattingEnabled = true;
            comboBox7.Location = new System.Drawing.Point(399, 56);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new System.Drawing.Size(100, 28);
            comboBox7.TabIndex = 63;
            comboBox7.SelectedIndexChanged += comboBox7_SelectedIndexChanged;
            // 
            // textBox5
            // 
            textBox5.Location = new System.Drawing.Point(595, 89);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new System.Drawing.Size(125, 27);
            textBox5.TabIndex = 66;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(507, 92);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(71, 20);
            label22.TabIndex = 65;
            label22.Text = "T сборки";
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new System.Drawing.Point(734, 52);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(226, 29);
            button5.TabIndex = 67;
            button5.Text = "КАНТОВКА";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new System.Drawing.Point(966, 55);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new System.Drawing.Size(95, 24);
            checkBox4.TabIndex = 68;
            checkBox4.Text = "Кантовка";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(18, 92);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(73, 20);
            label24.TabIndex = 69;
            label24.Text = "Электрод";
            // 
            // comboBox9
            // 
            comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox9.FormattingEnabled = true;
            comboBox9.Items.AddRange(new object[] { "Плав", "Неплав" });
            comboBox9.Location = new System.Drawing.Point(105, 89);
            comboBox9.Name = "comboBox9";
            comboBox9.Size = new System.Drawing.Size(100, 28);
            comboBox9.TabIndex = 70;
            comboBox9.SelectedIndexChanged += comboBox9_SelectedIndexChanged;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(1081, 14);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(92, 20);
            label25.TabIndex = 71;
            label25.Text = "Номер шва:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(1179, 15);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(17, 20);
            label26.TabIndex = 72;
            label26.Text = "0";
            // 
            // WeldingCalcForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            ClientSize = new System.Drawing.Size(1309, 523);
            Controls.Add(label26);
            Controls.Add(label25);
            Controls.Add(comboBox9);
            Controls.Add(label24);
            Controls.Add(checkBox4);
            Controls.Add(label6);
            Controls.Add(numericUpDown1);
            Controls.Add(button5);
            Controls.Add(textBox5);
            Controls.Add(label22);
            Controls.Add(label16);
            Controls.Add(comboBox7);
            Controls.Add(checkBox1);
            Controls.Add(textBox9);
            Controls.Add(label21);
            Controls.Add(textBox8);
            Controls.Add(label20);
            Controls.Add(textBox7);
            Controls.Add(label19);
            Controls.Add(textBox6);
            Controls.Add(label18);
            Controls.Add(textBox4);
            Controls.Add(label14);
            Controls.Add(groupBox1);
            Controls.Add(button4);
            Controls.Add(label15);
            Controls.Add(checkBox3);
            Controls.Add(comboBox6);
            Controls.Add(checkBox2);
            Controls.Add(numericUpDown5);
            Controls.Add(comboBox5);
            Controls.Add(label17);
            Controls.Add(pictureBox1);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(comboBox4);
            Controls.Add(label10);
            Controls.Add(numericUpDown3);
            Controls.Add(label9);
            Controls.Add(numericUpDown2);
            Controls.Add(label8);
            Controls.Add(button3);
            Controls.Add(label7);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "WeldingCalcForm";
            ShowIcon = false;
            Text = "Расчёт сварочных работ";
            Load += WeldingCalcForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amperage;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeWelding;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimePlumbing;
        private System.Windows.Forms.DataGridViewTextBoxColumn WireMass;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrossSecArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn WireDiameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SborkaMass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Electrod;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
    }
}