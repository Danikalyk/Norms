using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Norms
{
    public partial class Stanok3030Form : Form
    {
        private float _incuttingTime;
        private float _cuttingSpeed;
        private List<Control> navigationControls = new List<Control>();
        private string _selectedStanok;
        private float _razmIncuttingTime;
        private float _razmCuttingSpeed;
        public int openedWindows = 0;
        private bool _listPanelEnabled = false;

        public Stanok3030Form(string stanok)
        {
            InitializeComponent();

            try
            {
                string getMachineInfo = "SELECT MACHINE.SHORT_NAME FROM MACHINE";

                SqlDataReader DR = GetData(getMachineInfo);

                while (DR.Read())
                {
                    comboBox5.Items.Add(DR[0]);
                }

                //Закрытие DataReader
                DR.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Код ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            radioButton3.Checked = true;

            navigationControls.Add(this.comboBox1);
            navigationControls.Add(this.comboBox2);
            navigationControls.Add(this.numericUpDown1);
            navigationControls.Add(this.numericUpDown2);

            foreach (Control control in navigationControls)
            {
                control.KeyDown += Control_KeyDown;
            }

            _selectedStanok = stanok;
        }

        private void GetStanok(string stanok)
        {
            int index = comboBox5.FindStringExact(stanok);
            if (index != -1)
            {
                comboBox5.SelectedIndex = index;
            }
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Предотвратить звук динга
                MoveToNextControl(sender, false);
            }
            else if (e.KeyCode == Keys.ControlKey)
            {
                e.SuppressKeyPress = true;
                MoveToNextControl(sender, true);
            }
        }

        private void Control_KeyDownMK(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Предотвратить звук динга
                MoveToNextControl(sender, false);
            }
            else if (e.KeyCode == Keys.ControlKey)
            {
                e.SuppressKeyPress = true;
                MoveToNextControl(sender, true);
            }
        }

        private void Control_KeyDownRazm(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Предотвратить звук динга
                MoveToNextControl(sender, false);
            }
            else if (e.KeyCode == Keys.ControlKey)
            {
                e.SuppressKeyPress = true;
                MoveToNextControl(sender, true);
            }
        }

        private void MoveToNextControl(object sender, bool reverse)
        {
            Control? currentControl = sender as Control;
            if (currentControl != null)
            {
                int currentIndex = navigationControls.IndexOf(currentControl);
                if (currentIndex >= 0)
                {
                    int nextIndex = reverse ? currentIndex - 1 : currentIndex + 1;
                    if (nextIndex < 0) nextIndex = navigationControls.Count - 1;
                    if (nextIndex >= navigationControls.Count) nextIndex = 0;

                    Control nextControl = navigationControls[nextIndex];
                    if (nextControl != null && nextControl.CanSelect)
                    {
                        nextControl.Select();
                        // Выделение текста, если элемент управления - текстовое поле
                        if (nextControl is TextBox textBox)
                        {
                            textBox.SelectAll();
                        }
                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        //калькулятор времени резки металла
        private void CuttingCalcution()
        {
            float cuttingTime = 0f;
            float sum = 0f;

            if (!String.IsNullOrEmpty(comboBox3.Text) && !String.IsNullOrEmpty(textBox5.Text) &&
                !String.IsNullOrEmpty(textBox6.Text) && !String.IsNullOrEmpty(Convert.ToString(numericUpDown1.Value)) &&
                !String.IsNullOrEmpty(Convert.ToString(numericUpDown2.Value)))
            {
                if (comboBox3.Text != "Воздух")
                {
                    if (comboBox5.Text == "600" || comboBox5.Text == "IGNIUS")
                    {
                        float cuttingPerimeter = (float)numericUpDown1.Value;
                        float nvrez = (float)numericUpDown2.Value;
                        float cuttingSpeed = Convert.ToSingle(textBox5.Text);
                        float vrezTime = Convert.ToSingle(textBox6.Text);

                        cuttingTime = (cuttingPerimeter / (cuttingSpeed * 1000)) + (nvrez * vrezTime);
                    }
                    else if (comboBox5.Text == "ГАР")
                    {
                        float cuttingPerimeter = (float)numericUpDown1.Value;
                        //float nvrez = (float)numericUpDown2.Value;
                        float cuttingSpeed = Convert.ToSingle(textBox5.Text);
                        //float vrezTime = Convert.ToSingle(textBox6.Text);

                        if (!checkBox7.Checked)
                            cuttingTime = (cuttingPerimeter / cuttingSpeed);
                        else
                            cuttingTime = (cuttingPerimeter / (cuttingSpeed * 0.75f));
                    }
                    else
                    {
                        float cuttingPerimeter = (float)numericUpDown1.Value;
                        float nvrez = (float)numericUpDown2.Value;
                        float cuttingSpeed = Convert.ToSingle(textBox5.Text);
                        float vrezTime = Convert.ToSingle(textBox6.Text);

                        cuttingTime = Convert.ToSingle(((cuttingPerimeter / (cuttingSpeed * 1000)) + (nvrez * vrezTime)) * 1.3);
                        textBox3.Text = Convert.ToString(cuttingTime);
                    }
                }
                else
                {
                    float cuttingPerimeter = (float)numericUpDown1.Value;
                    float nvrez = (float)numericUpDown2.Value;
                    float cuttingSpeed = Convert.ToSingle(textBox5.Text);
                    float vrezTime = Convert.ToSingle(textBox6.Text);

                    cuttingTime = (cuttingPerimeter / (cuttingSpeed * 1000)) + (nvrez * vrezTime);
                }


            }

            float cutting;
            if (checkBox3.Checked)
            {
                if (comboBox5.Text == "600")
                {
                    if (checkBox2.Checked && !checkBox1.Checked)
                    {
                        sum = CalculateRazmetka() + cuttingTime + CalculateProbivka();
                    }
                    else if (checkBox1.Checked && checkBox2.Checked)
                    {
                        sum = CalculateSmallConture() + CalculateRazmetka() + cuttingTime + CalculateProbivka();
                    }
                    else if (!checkBox2.Checked && !checkBox1.Checked)
                    {
                        sum = cuttingTime + CalculateProbivka();
                    }
                    else if (!checkBox2.Checked && checkBox1.Checked)
                    {
                        sum = CalculateSmallConture() + cuttingTime + CalculateProbivka();
                    }

                    cutting = sum;
                }
                else
                {
                    if (!checkBox1.Checked && checkBox2.Checked)
                    {
                        sum = CalculateRazmetka() + cuttingTime;
                    }
                    else if (checkBox1.Checked && checkBox2.Checked)
                    {
                        sum = CalculateSmallConture() + CalculateRazmetka() + cuttingTime;
                    }
                    else if (!checkBox2.Checked && !checkBox1.Checked)
                    {
                        sum = cuttingTime;
                    }
                    else if (checkBox1.Checked && !checkBox2.Checked)
                    {
                        sum = CalculateSmallConture() + cuttingTime;
                    }

                    cutting = sum;
                }
            }
            else
            {
                if (checkBox1.Checked)
                {
                    if (checkBox2.Checked)
                    {
                        sum = CalculateSmallConture() + CalculateRazmetka();
                    }
                    else
                    {
                        sum = CalculateSmallConture();
                    }

                    cutting = sum;
                }
                else
                {
                    if (checkBox2.Checked)
                    {
                        sum = CalculateRazmetka();
                    }

                    cutting = sum;
                }
            }

            textBox3.Text = cutting.ToString();
        }

        //метод для получения данных из базы данных
        private static SqlDataReader GetData(string query)
        {
            SqlConnection conn = new(config._connectionString);
            conn.Open();
            SqlCommand cmd = new(query, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            return DR;
        }
        //получение информации о металлах
        private void LoadMaterials()
        {
            comboBox1.Items.Clear();
            string machineName = comboBox5.Text;

            string sqlQueryMaterials = "SELECT DISTINCT MATERIAL.MATERIAL_NAME FROM " +
                "CUTTING_INFO INNER JOIN MATERIAL ON CUTTING_INFO.MATERIAL = MATERIAL.MATERIAL_CODE INNER JOIN MACHINE ON CUTTING_INFO.MACHINE = MACHINE.MACHINE_CODE " +
                $"WHERE MACHINE.SHORT_NAME = '{machineName}'";
            SqlDataReader DR = GetData(sqlQueryMaterials);

            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);
            }

            //Закрытие DataReader
            DR.Close();

            bool itemFound = false;

            foreach (var item in comboBox1.Items)
            {
                if (item.ToString() == "Конструкционная сталь")
                {
                    comboBox1.SelectedItem = item;
                    itemFound = true;
                    break;
                }
            }

            // Обработаем случай, когда элемент не найден
            if (!itemFound)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void Stanok3030Form_Load(object sender, EventArgs e)
        {
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            numericUpDown1.TextChanged += NumericUpDown1_TextChanged;
            numericUpDown2.TextChanged += NumericUpDown2_TextChanged;
            numericUpDown3.TextChanged += NumericUpDown3_TextChanged;
            numericUpDown4.TextChanged += NumericUpDown4_TextChanged;
            numericUpDown5.TextChanged += NumericUpDown5_TextChanged;
            numericUpDown6.TextChanged += NumericUpDown6_TextChanged;
            numericUpDown7.TextChanged += NumericUpDown7_TextChanged;
            numericUpDown8.TextChanged += NumericUpDown8_TextChanged;
            numericUpDown9.TextChanged += NumericUpDown9_TextChanged;
            button7.Click += IncreaseButton_Click;
            button8.Click += DecreaseButton_Click;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).

            numericUpDown1.Enter += new EventHandler(numericUpDown_Enter);
            numericUpDown1.GotFocus += new EventHandler(numericUpDown_GotFocus);
            numericUpDown1.Click += new EventHandler(numericUpDown_Click);

            numericUpDown2.Enter += new EventHandler(numericUpDown_Enter);
            numericUpDown2.GotFocus += new EventHandler(numericUpDown_GotFocus);
            numericUpDown2.Click += new EventHandler(numericUpDown_Click);
            GetStanok(_selectedStanok);
            comboBox2.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;

            if (comboBox5.Text == "3030" || comboBox5.Text == "5030" || comboBox5.Text == "AXEL" || comboBox5.Text == "ГАР" || comboBox5.Text == "IGNIUS")
            {
                groupBox3.Visible = true;
                groupBox4.Visible = false;
            }
            else
            {
                groupBox3.Visible = false;
                groupBox4.Visible = true;
            }
        }

        private void numericUpDown_Enter(object sender, EventArgs e)
        {
            NumericUpDown? numericUpDown = sender as NumericUpDown;
            numericUpDown?.Select(0, numericUpDown.Text.Length);
            // Или использовать numericUpDown.Select(0, numericUpDown.Value.ToString().Length);
        }

        // Или обработчик для GotFocus
        private void numericUpDown_GotFocus(object sender, EventArgs e)
        {
            NumericUpDown? numericUpDown = sender as NumericUpDown;
            numericUpDown?.Select(0, numericUpDown.Text.Length);
        }

        // Или обработчик события Click 
        private void numericUpDown_Click(object sender, EventArgs e)
        {
            NumericUpDown? numericUpDown = sender as NumericUpDown;
            numericUpDown?.Select(0, numericUpDown.Text.Length);
        }
        //получение информации о режущем газе
        private void GetInformationAboutGas(string material, string tickness, string machine)
        {
            string metallTickness = tickness.Replace(",", ".");
            comboBox3.Items.Clear();
            try
            {

                string sqlQueryGetGas = $"SELECT DISTINCT MACHINE.SHORT_NAME as 'Станок', " +
                $"MATERIAL.MATERIAL_NAME as 'Материал', " +
                $"CUTTING_INFO.TICKNESS as 'Толщина', " +
                $"GAS.SHORT_NAME AS 'Газ' FROM CUTTING_INFO " +
                $"INNER JOIN GAS ON CUTTING_INFO.GAS = GAS.GAS_CODE " +
                $"INNER JOIN MACHINE ON CUTTING_INFO.MACHINE = MACHINE.MACHINE_CODE " +
                $"INNER JOIN MATERIAL ON CUTTING_INFO.MATERIAL = MATERIAL.MATERIAL_CODE " +
                $"WHERE MACHINE.SHORT_NAME = '{machine}' AND CUTTING_INFO.TICKNESS = {metallTickness} " +
                $"AND MATERIAL.MATERIAL_NAME = '{material}'";

                SqlDataReader DR2 = GetData(sqlQueryGetGas);

                while (DR2.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(DR2["Газ"]));
                }

                DR2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string desiredItem = "Воздух";
            string alternateItem = "O2";
            int index = comboBox3.FindStringExact(desiredItem);
            if (index != -1)
            {
                comboBox3.SelectedIndex = index;
            }
            else
            {
                // Если заданный элемент не найден, ищем второй заданный
                index = comboBox3.FindStringExact(alternateItem);
                if (index != -1)
                {
                    comboBox3.SelectedIndex = index;
                }
                else
                {
                    // Если ни один из заданных элементов не найден, выберите первый элемент
                    if (comboBox3.Items.Count > 0)
                    {
                        comboBox3.SelectedIndex = 0;
                    }
                }
            }
        }
        //получение информации о различных параметрах резки
        private void GetInformationAboutCutting(string material, string tickness)
        {

            string metallTickness = tickness.Replace(",", ".");
            string machine = comboBox5.Text;
            string gas = comboBox3.Text;
            try
            {
                string sqlQuery = $"SELECT MACHINE.SHORT_NAME as 'Станок', MATERIAL.MATERIAL_NAME as 'Металл', " +
                    $"GAS.SHORT_NAME as 'Газ', CUTTING_INFO.TICKNESS as 'Толщина', CUTTING_INFO.ttMIN_SPEED as 'Минимальная скорость', " +
                    $"CUTTING_INFO.ttAVE_SPEED as 'Средняя скорость', CUTTING_INFO.ttMAX_SPEED as 'Максимальная скорость', " +
                    $"CUTTING_INFO.CUTTING_TIME as 'Время врезки' FROM CUTTING_INFO INNER JOIN GAS ON CUTTING_INFO.GAS = GAS.GAS_CODE " +
                    $"INNER JOIN MACHINE ON CUTTING_INFO.MACHINE = MACHINE.MACHINE_CODE " +
                    $"INNER JOIN MATERIAL ON CUTTING_INFO.MATERIAL = MATERIAL.MATERIAL_CODE " +
                    $"WHERE MACHINE.SHORT_NAME = '{machine}' AND CUTTING_INFO.TICKNESS = {metallTickness} AND MATERIAL.MATERIAL_NAME = '{material}' AND GAS.SHORT_NAME = '{gas}'";
                SqlDataReader DR = GetData(sqlQuery);

                while (DR.Read())
                {
                    _incuttingTime = Convert.ToSingle(DR["Время врезки"]);
                    textBox6.Text = _incuttingTime.ToString();
                }

                DR.Close();
                GetSpeed(metallTickness);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cutting Код ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //получение параметров скорости врезки
        private void GetSpeed(string tickness)
        {
            try
            {
                string metallTickness = tickness.Replace(",", ".");
                string materialName = comboBox1.Text;
                string machine = comboBox5.Text;
                string gas = comboBox3.Text;
                string sqlQuery = $"SELECT CUTTING_INFO.ttMIN_SPEED as 'Минимальная скорость', CUTTING_INFO.ttAVE_SPEED as 'Средняя скорость', CUTTING_INFO.ttMAX_SPEED as 'Максимальная скорость', MACHINE.SHORT_NAME as 'Станок', GAS.SHORT_NAME " +
                    $"FROM CUTTING_INFO INNER JOIN MATERIAL ON CUTTING_INFO.MATERIAL = MATERIAL.MATERIAL_CODE INNER JOIN MACHINE ON CUTTING_INFO.MACHINE = MACHINE.MACHINE_CODE INNER JOIN GAS ON CUTTING_INFO.GAS = GAS.GAS_CODE  " +
                    $"WHERE MATERIAL.MATERIAL_NAME = '{materialName}' AND CUTTING_INFO.TICKNESS = {metallTickness} AND MACHINE.SHORT_NAME = '{machine}' AND GAS.SHORT_NAME = '{gas}'";

                SqlDataReader DR = GetData(sqlQuery);
                while (DR.Read())
                {
                    if (radioButton1.Checked)
                    {
                        _cuttingSpeed = Convert.ToSingle(DR["Максимальная скорость"]);
                        textBox5.Text = _cuttingSpeed.ToString();

                    }
                    if (radioButton2.Checked)
                    {
                        _cuttingSpeed = Convert.ToSingle(DR["Средняя скорость"]);
                        textBox5.Text = _cuttingSpeed.ToString();
                    }
                    if (radioButton3.Checked)
                    {
                        _cuttingSpeed = Convert.ToSingle(DR["Минимальная скорость"]);
                        textBox5.Text = _cuttingSpeed.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Код ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //смена металла
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Очистка элементов comboBox перед добавлением новых
            comboBox2.Items.Clear();

            string selectedMaterial = comboBox1.Text;
            string machine = comboBox5.Text;

            if (!String.IsNullOrEmpty(selectedMaterial))
            {
                string sqlQueryTickness = $"SELECT DISTINCT CUTTING_INFO.TICKNESS, MACHINE.SHORT_NAME FROM CUTTING_INFO INNER JOIN MATERIAL ON CUTTING_INFO.MATERIAL = MATERIAL.MATERIAL_CODE INNER JOIN MACHINE ON CUTTING_INFO.MACHINE = MACHINE.MACHINE_CODE WHERE MATERIAL.MATERIAL_NAME = '{selectedMaterial}' AND MACHINE.SHORT_NAME = '{machine}'";
                SqlDataReader DR2 = GetData(sqlQueryTickness);

                while (DR2.Read())
                {
                    comboBox2.Items.Add(Convert.ToString(DR2[0]));
                }

                // Закрытие DataReader
                DR2.Close();
                comboBox2.SelectedIndex = 0;
            }
        }
        //смена толщины
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string machine = comboBox5.Text;
            string material = comboBox1.Text;
            string ticknessString = comboBox2.Text;
            GetInformationAboutCutting(material, ticknessString);
            GetInformationAboutGas(material, ticknessString, machine);
            GetSmallConturInfo();
            GetRazmetkaData();
            CuttingCalcution();
        }
        //максимальная скорость
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboBox2.Text))
            {
                string ticknessString = comboBox2.Text;
                GetSpeed(ticknessString);
                CuttingCalcution();
            }
        }
        //средняя скорость
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboBox2.Text))
            {
                string ticknessString = comboBox2.Text;
                GetSpeed(ticknessString);
                CuttingCalcution();
            }
        }
        //минимальная скорость
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboBox2.Text))
            {
                string ticknessString = comboBox2.Text;
                GetSpeed(ticknessString);
                CuttingCalcution();
            }
        }

        private void GetSmallConturInfo()
        {
            string tickness = comboBox2.Text;
            string metall = comboBox1.Text;
            string machine = comboBox5.Text;
            string sqlQuery = $"SELECT DISTINCT CUTTING_INFO_SMALL_CONTUR.ttSmallConOSPEED 'Скорость резки', " +
                $"CUTTING_INFO_SMALL_CONTUR.smallConINCUTTING_TIME 'Время врезки', " +
                $"CUTTING_INFO_SMALL_CONTUR.smallConCUTTING_WIDTH as 'Ширина реза', " +
                $"CUTTING_INFO_SMALL_CONTUR.TICKNESS as 'Толщина', " +
                $"GAS.SHORT_NAME as 'Газ', MACHINE.SHORT_NAME AS 'Станок', MATERIAL.MATERIAL_NAME as 'Металл'" +
                $"FROM CUTTING_INFO_SMALL_CONTUR INNER JOIN " +
                $"GAS ON CUTTING_INFO_SMALL_CONTUR.GAS = GAS.GAS_CODE INNER JOIN " +
                $"MACHINE ON CUTTING_INFO_SMALL_CONTUR.MACHINE = MACHINE.MACHINE_CODE INNER JOIN " +
                $"MATERIAL ON CUTTING_INFO_SMALL_CONTUR.MATERIAL = MATERIAL.MATERIAL_CODE " +
                $"WHERE CUTTING_INFO_SMALL_CONTUR.TICKNESS = {tickness.Replace(",", ".")} AND MATERIAL.MATERIAL_NAME = '{metall}' AND MACHINE.SHORT_NAME = '{machine}'";

            SqlDataReader DR = GetData(sqlQuery);
            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    textBox1.Text = Convert.ToString(DR["Газ"]);
                    textBox9.Text = Convert.ToString(DR["Скорость резки"]);
                    textBox10.Text = Convert.ToString(DR["Время врезки"]);
                }
            }
            else
            {
                textBox1.Text = null;
                textBox9.Text = null;
                textBox10.Text = null;
            }

            DR.Close();
        }

        //задание малого контура
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;

                label11.Visible = true;

                numericUpDown3.TabStop = true;
                numericUpDown4.TabStop = true;
                GetSmallConturInfo();
                CuttingCalcution();
            }
            else if (!checkBox1.Checked)
            {
                textBox1.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox9.Text = null;
                textBox10.Text = null;
                numericUpDown3.Visible = false;
                numericUpDown4.Visible = false;

                label11.Visible = false;
                textBox3.Text = null;

                numericUpDown3.TabStop = false;
                numericUpDown4.TabStop = false;
                CuttingCalcution();
            }
        }

        private void GetRazmetkaData()
        {
            string machine = comboBox5.Text;
            string material = comboBox1.Text;
            string tickness = comboBox2.Text;
            string replacedTickness = tickness.Replace(",", ".");
            string sqlQuery = $"SELECT MACHINE.SHORT_NAME as 'Станок', MATERIAL.MATERIAL_NAME as 'Материал', RAZMETKA.TICKNESS as 'Толщина', RAZMETKA.INCUTTING_TIME as 'Время врезки', RAZMETKA.CUTTING_SPEED as 'Скорость' FROM MACHINE INNER JOIN RAZMETKA ON MACHINE.MACHINE_CODE = RAZMETKA.MACHINE INNER JOIN MATERIAL ON RAZMETKA.MATERIAL = MATERIAL.MATERIAL_CODE WHERE MACHINE.SHORT_NAME = '{machine}' AND MATERIAL.MATERIAL_NAME = '{material}' AND RAZMETKA.TICKNESS = {replacedTickness}";
            SqlDataReader DR = GetData(sqlQuery);
            while (DR.Read())
            {
                _razmIncuttingTime = Convert.ToSingle(DR["Время врезки"]);
                _razmCuttingSpeed = Convert.ToSingle(DR["Скорость"]);
            }
            DR.Close();
        }

        private float CalculateRazmetka()
        {
            float razmTime = 0f;

            if (comboBox5.Text == "AXEL")
            {
                float per = (float)numericUpDown5.Value;
                float vrezCount = (float)numericUpDown6.Value;
                float vrezSpeed = (float)0.00025;
                float vrezTime = (float)0.02;

                razmTime = (per * vrezSpeed) + (vrezCount * vrezTime);
            }
            else if (comboBox5.Text == "600")
            {
                float per = (float)numericUpDown5.Value;
                float vrezCount = (float)numericUpDown6.Value;

                razmTime = (per * _razmCuttingSpeed) + (vrezCount * _razmIncuttingTime);

            }
            else if (comboBox5.Text == "5030" || comboBox5.Text == "3030")
            {
                float per = (float)numericUpDown5.Value;
                float vrezCount = (float)numericUpDown6.Value;

                razmTime = (per * _razmCuttingSpeed) + (vrezCount * _razmIncuttingTime);
            }

            return razmTime;
        }

        //задание разметки
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;

                numericUpDown5.TabStop = true;
                numericUpDown6.TabStop = true;
                CuttingCalcution();
            }
            else
            {
                numericUpDown5.Visible = false;
                numericUpDown6.Visible = false;

                numericUpDown5.TabStop = false;
                numericUpDown6.TabStop = false;
                CuttingCalcution();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void Stanok3030Form_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Stanok3030Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
        //включение и отключение большого контура
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                comboBox3.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
            }
            else
            {
                numericUpDown1.Visible = false;
                numericUpDown2.Visible = false;
                comboBox3.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox3.Text = null;
            }
        }
        //включение и отключение авторежима
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox4.Checked)
            {
                DialogResult result = MessageBox.Show(
            "Отключение авторежима позволит вводить значения вручную, при этом могут возникать непредвиденные ошибки, вы уверены, что хотите продолжить? Введённые данные не сохраняются в базе",
            "Внимание!",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    textBox5.ReadOnly = false;
                    textBox6.ReadOnly = false;
                    textBox9.ReadOnly = false;
                    textBox10.ReadOnly = false;
                }
                else
                {
                    textBox5.ReadOnly = true;
                    textBox6.ReadOnly = true;
                    checkBox4.Checked = true;
                    textBox9.ReadOnly = true;
                    textBox10.ReadOnly = true;
                }
            }
            if (checkBox4.Checked)
            {
                string material = comboBox1.Text;
                string ticknessString = comboBox2.Text;
                GetInformationAboutCutting(material, ticknessString);
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
            }
        }

        private void numericUpDown1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void NumericUpDown1_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void NumericUpDown2_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void NumericUpDown9_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != decimalSeparator))
            {
                e.Handled = true;
            }
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            if ((e.KeyChar == decimalSeparator) && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(decimalSeparator) > -1))
            {
                e.Handled = true;
            }
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != decimalSeparator))
            {
                e.Handled = true;
            }
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            if ((e.KeyChar == decimalSeparator) && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(decimalSeparator) > -1))
            {
                e.Handled = true;
            }
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string material = comboBox1.Text;
            string tickness = comboBox2.Text;
            GetInformationAboutCutting(material, tickness);

            CuttingCalcution();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private float CalculateSmallConture()
        {
            float smallCuttingTime = 0f;

            if (!String.IsNullOrEmpty(textBox9.Text) && !String.IsNullOrEmpty(textBox10.Text))
            {
                if (comboBox5.Text == "ГАР" || comboBox5.Text == "600")
                {
                    int per = Convert.ToInt32(numericUpDown3.Value);
                    int vrez_count = Convert.ToInt32(numericUpDown4.Value);
                    float vrez_time = Convert.ToSingle(textBox10.Text);
                    float vrez_speed = Convert.ToSingle(textBox9.Text);

                    smallCuttingTime = Convert.ToSingle((per / (vrez_speed * 1000)) + (vrez_count * vrez_time));
                }
                else
                {
                    int per = Convert.ToInt32(numericUpDown3.Value);
                    int vrez_count = Convert.ToInt32(numericUpDown4.Value);
                    float vrez_time = Convert.ToSingle(textBox10.Text);
                    float vrez_speed = Convert.ToSingle(textBox9.Text);

                    smallCuttingTime = Convert.ToSingle(((per / (vrez_speed * 1000)) + (vrez_count * vrez_time)) * 1.3);
                }

            }
            return smallCuttingTime;
        }

        private void NumericUpDown3_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void NumericUpDown4_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void NumericUpDown5_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void NumericUpDown6_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void NumericUpDown7_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void NumericUpDown8_TextChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            LoadMaterials();

            if (comboBox5.Text != "600")
            {
                groupBox3.Visible = true;
                groupBox4.Visible = false;
                checkBox6.Visible = false;
            }
            else
            {
                groupBox3.Visible = false;
                groupBox4.Visible = true;
                checkBox6.Visible = true;
            }

            if (comboBox5.Text == "AXEL")
            {
                checkBox2.Text = "Выпарив";
            }
            else
            {
                checkBox2.Text = "Разметка";
            }

            if (comboBox5.Text == "ГАР")
                checkBox7.Visible = true;
            else
                checkBox7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float OsnTime = 0f;

            if (config.openedWindows < 2)
            {
                if (comboBox5.Text != "600")
                {
                    if (!String.IsNullOrEmpty(textBox2.Text))
                    {
                        OsnTime = Convert.ToSingle(textBox2.Text);
                    }
                    DopTime dt = new DopTime(OsnTime);
                    dt.Show();
                }
                else
                {
                    Stanok600 st600 = new Stanok600();
                    st600.Show();
                }

                config.openedWindows += 1;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string addedTime = textBox3.Text;
            listBox1.Items.Add(addedTime);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            float sum = 0f;
            foreach (var item in listBox1.Items)
            {
                // Попытка преобразовать значение к целочисленному типу и сложение значений.
                if (float.TryParse(item.ToString(), out float number))
                {
                    sum += number;
                }
                else
                {
                    MessageBox.Show($"Невозможно преобразовать '{item}' к числовому значению.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Вывод результата в TextBox.
            textBox2.Text = sum.ToString();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void IncreaseButton_Click(object sender, EventArgs e)
        {
            if (!_listPanelEnabled)
            {
                ResizeForm(1.25); // увеличиваем на 10%
                _listPanelEnabled = true;
            }
        }

        private void DecreaseButton_Click(object sender, EventArgs e)
        {
            if (_listPanelEnabled)
            {
                ResizeForm(0.8); // уменьшаем на 10%
                _listPanelEnabled = false;
            }
        }

        private void ResizeForm(double factor)
        {
            // Изменяем размер формы, используя процентное соотношение
            this.Width = (int)(this.Width * factor);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private float CalculateProbivka()
        {
            float aveSum = 0f;

            if (!String.IsNullOrEmpty(comboBox4.Text) && !String.IsNullOrEmpty(comboBox6.Text))
            {
                float nOne = Convert.ToSingle(numericUpDown7.Value);
                float nTwo = Convert.ToSingle(numericUpDown8.Value);
                float vOne = Convert.ToSingle(comboBox4.Text);
                float vTwo = Convert.ToSingle(comboBox6.Text);
                float nRezb = Convert.ToSingle(numericUpDown9.Value);

                float sum = nOne / vOne + nTwo / vTwo;

                if (numericUpDown9.Value != 0)
                {
                    float rezb = Convert.ToSingle(nRezb * 0.11);
                    aveSum = sum + rezb;
                }
                else
                {
                    aveSum = sum;
                }
            }

            return aveSum;
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string input = textBox3.Text;

            if (double.TryParse(input, out double number))
            {
                double roundedValue = Math.Round(number, 2);
                textBox3.Text = roundedValue.ToString();
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(CalculateSmallConture());

            if (comboBox5.Text == "600")
            {
                textBox3.Text = CalculateProbivka().ToString();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(CalculateSmallConture());

            if (comboBox5.Text == "600")
            {
                textBox3.Text = CalculateProbivka().ToString();
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            string machine = comboBox5.Text;
            comboBox3.Items.Clear();
            string material = comboBox1.Text;
            string ticknessString = comboBox2.Text;
            GetInformationAboutCutting(material, ticknessString);
            GetInformationAboutGas(material, ticknessString, machine);
            GetSmallConturInfo();
            CuttingCalcution();

        }

        private void Stanok3030Form_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != decimalSeparator))
            {
                e.Handled = true;
            }
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            if ((e.KeyChar == decimalSeparator) && ((sender as System.Windows.Forms.ComboBox).Text.IndexOf(decimalSeparator) > -1))
            {
                e.Handled = true;
            }
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            CuttingCalcution();
        }

        private void checkBox7_CheckedChanged_1(object sender, EventArgs e)
        {
            CuttingCalcution();
        }
    }
}

