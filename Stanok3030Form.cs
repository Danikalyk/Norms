using System;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Norms
{
    public partial class Stanok3030Form : Form
    {
        private float _incuttingTime;
#pragma warning disable CS0649 // Полю "Stanok3030Form._cuttingWidth" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию 0.
        private float _cuttingWidth;
#pragma warning restore CS0649 // Полю "Stanok3030Form._cuttingWidth" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию 0.
        private float _cuttingSpeed;

        public Stanok3030Form()
        {
            InitializeComponent();
            GetInformationAboutMachine();

            radioButton1.Checked = true;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        //калькулятор времени резки металла
        private void CuttingCalcution()
        {
            if (!String.IsNullOrEmpty(comboBox3.Text) && !String.IsNullOrEmpty(textBox5.Text) &&
                !String.IsNullOrEmpty(textBox6.Text) && !String.IsNullOrEmpty(Convert.ToString(numericUpDown1.Value)) &&
                !String.IsNullOrEmpty(Convert.ToString(numericUpDown2.Value)))
            {
                float cuttingPerimeter = (float)numericUpDown1.Value;
                float nvrez = (float)numericUpDown2.Value;
                float cuttingSpeed = float.Parse(textBox5.Text, CultureInfo.InvariantCulture.NumberFormat);

                float cuttingTime = (cuttingPerimeter / cuttingSpeed) + (nvrez * Convert.ToSingle(textBox6.Text));
                textBox3.Text = Convert.ToString(cuttingTime);
            }
        }

        //метод для получения данных из базы данных
        private static SqlDataReader GetData(string query)
        {
            SqlConnection conn = new SqlConnection(config._connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
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
            comboBox1.SelectedIndex = 0;
        }
        //получение информации о толщинах выбранного металла
        private void LoadTickness()
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить данные, код ошибки: " + ex.Message);
            }

            comboBox2.SelectedIndex = 0;
        }

        private void GetInformationAboutMachine()
        {
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
        }

        private void Stanok3030Form_Load(object sender, EventArgs e)
        {
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            numericUpDown1.TextChanged += NumericUpDown1_TextChanged;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            numericUpDown2.TextChanged += NumericUpDown2_TextChanged;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).


#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            numericUpDown3.TextChanged += NumericUpDown3_TextChanged;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            numericUpDown4.TextChanged += NumericUpDown4_TextChanged;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).

            comboBox5.SelectedIndex = 0;
            //LoadMaterials();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }
        //получение информации о режущем газе
        private void GetInformationAboutGas(string material, string tickness, string machine)
        {

            string metallTickness = tickness.Replace(",", ".");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comboBox3.SelectedIndex = 0;
        }
        //получение информации о различных параметрах резки
        private void GetInformationAboutCutting(string material, string tickness)
        {
            string metallTickness = tickness.Replace(",", ".");
            string gas = comboBox3.Text;
            string machine = comboBox5.Text;
            try
            {
                string sqlQuery = $"SELECT GAS.SHORT_NAME as 'Газ', LENSES.LENS_FOCUS as 'Линза', " +
                    $"CUTTING_INFO.ttMIN_SPEED as 'Минимальная скорость', " +
                    $"CUTTING_INFO.ttAVE_SPEED as 'Средняя скорость', " +
                    $"CUTTING_INFO.ttMAX_SPEED as 'Максимальная скорость', " +
                    $"CUTTING_INFO.CUTTING_TIME as 'Время врезки', CUTTING_INFO.CUTTING_WIDTH as 'Ширина реза', " +
                    $"MATERIAL.MATERIAL_NAME as 'Материал', MACHINE.SHORT_NAME AS 'Станок' " +
                    $"FROM CUTTING_INFO INNER JOIN GAS ON CUTTING_INFO.GAS = GAS.GAS_CODE INNER JOIN LENSES ON " +
                    $"CUTTING_INFO.LENS = LENSES.LENS_CODE INNER JOIN MACHINE ON " +
                    $"CUTTING_INFO.MACHINE = MACHINE.MACHINE_CODE INNER JOIN MATERIAL ON " +
                    $"CUTTING_INFO.MATERIAL = MATERIAL.MATERIAL_CODE " +
                    $"WHERE MACHINE.SHORT_NAME = '{machine}' AND CUTTING_INFO.TICKNESS = {metallTickness} AND MATERIAL.MATERIAL_NAME = '{material}' AND GAS.SHORT_NAME = '{gas}'";
                SqlDataReader DR = GetData(sqlQuery);

                while (DR.Read())
                {
                    _incuttingTime = Convert.ToSingle(DR["Время врезки"]);
                    //_cuttingWidth = Convert.ToSingle(DR["Ширина реза"]);

                    textBox6.Text = _incuttingTime.ToString();
                    textBox7.Text = Convert.ToString(_cuttingWidth);
                }
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
                string sqlQuery = $"SELECT CUTTING_INFO.ttMIN_SPEED as 'Минимальная скорость', CUTTING_INFO.ttAVE_SPEED as 'Средняя скорость', CUTTING_INFO.ttMAX_SPEED as 'Максимальная скорость' " +
                    $"FROM CUTTING_INFO INNER JOIN MATERIAL ON CUTTING_INFO.MATERIAL = MATERIAL.MATERIAL_CODE " +
                    $"WHERE MATERIAL.MATERIAL_NAME = '{materialName}' AND CUTTING_INFO.TICKNESS = {metallTickness}";

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
            if (checkBox3.Checked)
            {
                string material = comboBox1.Text;
                LoadTickness();
                string ticknessString = comboBox2.Text;
                //GetInformationAboutGas(material, ticknessString, machine);
                GetInformationAboutCutting(material, ticknessString);
                CuttingCalcution();
            }
        }
        //смена толщины
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                string machine = comboBox5.Text;
                comboBox3.Items.Clear();
                string material = comboBox1.Text;
                string ticknessString = comboBox2.Text;
                GetInformationAboutCutting(material, ticknessString);
                GetInformationAboutGas(material, ticknessString, machine);
                CuttingCalcution();
            }
            if (checkBox1.Checked)
            {
                GetSmallConturInfo();
            }
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
            string sqlQuery = $"SELECT DISTINCT CUTTING_INFO_SMALL_CONTUR.ttSmallConOSPEED 'Скорость резки', " +
                $"CUTTING_INFO_SMALL_CONTUR.smallConINCUTTING_TIME 'Время врезки', " +
                $"CUTTING_INFO_SMALL_CONTUR.smallConCUTTING_WIDTH as 'Ширина реза', " +
                $"CUTTING_INFO_SMALL_CONTUR.TICKNESS as 'Толщина', " +
                $"GAS.SHORT_NAME as 'Газ', MACHINE.SHORT_NAME AS 'Станок', MATERIAL.MATERIAL_NAME as 'Металл'" +
                $"FROM CUTTING_INFO_SMALL_CONTUR INNER JOIN " +
                $"GAS ON CUTTING_INFO_SMALL_CONTUR.GAS = GAS.GAS_CODE INNER JOIN " +
                $"MACHINE ON CUTTING_INFO_SMALL_CONTUR.MACHINE = MACHINE.MACHINE_CODE INNER JOIN " +
                $"MATERIAL ON CUTTING_INFO_SMALL_CONTUR.MATERIAL = MATERIAL.MATERIAL_CODE " +
                $"WHERE CUTTING_INFO_SMALL_CONTUR.TICKNESS = {tickness.Replace(",", ".")} AND MATERIAL.MATERIAL_NAME = '{metall}'";

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

                GetSmallConturInfo();
                if (!String.IsNullOrEmpty(textBox9.Text) && !String.IsNullOrEmpty(textBox10.Text))
                {
                    CalculateSmallConture();
                }
            }
            else
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
                CuttingCalcution();
            }
        }
        //задание разметки
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;
            }
            else
            {
                numericUpDown5.Visible = false;
                numericUpDown6.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
                textBox7.Visible = true;
            }
            else
            {
                numericUpDown1.Visible = false;
                numericUpDown2.Visible = false;
                comboBox3.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CuttingCalcution();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Код ошибки: " + ex.Message, "Произошла ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if ((e.KeyChar == decimalSeparator) && ((sender as TextBox).Text.IndexOf(decimalSeparator) > -1))
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
            if ((e.KeyChar == decimalSeparator) && ((sender as TextBox).Text.IndexOf(decimalSeparator) > -1))
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).

            if (comboBox3.SelectedIndex != comboBox3.Items.Count - 1)
            {
                comboBox3.SelectedIndex += 1;
            }
            else
            {
                comboBox3.SelectedIndex = 0;
            }
        }

        private float CalculateSmallConture()
        {
            float cuttingTime = 0f;
            float aveCuttingTime = 0f;

            if (!String.IsNullOrEmpty(comboBox3.Text) && !String.IsNullOrEmpty(textBox5.Text) &&
               !String.IsNullOrEmpty(textBox6.Text) && !String.IsNullOrEmpty(Convert.ToString(numericUpDown1.Value)) &&
               !String.IsNullOrEmpty(Convert.ToString(numericUpDown2.Value)))
            {
                float cuttingPerimeter = (float)numericUpDown1.Value;
                float nvrez = (float)numericUpDown2.Value;
                float cuttingSpeed = float.Parse(textBox5.Text, CultureInfo.InvariantCulture.NumberFormat);

                cuttingTime = (cuttingPerimeter / cuttingSpeed) + (nvrez * Convert.ToSingle(textBox6.Text));
                textBox3.Text = Convert.ToString(cuttingTime);
            }

            if (!String.IsNullOrEmpty(textBox9.Text) && !String.IsNullOrEmpty(textBox10.Text))
            {
                int per = Convert.ToInt32(numericUpDown3.Value);
                int vrez_count = Convert.ToInt32(numericUpDown4.Value);
                float vrez_time = Convert.ToSingle(textBox10.Text);
                float vrez_speed = Convert.ToSingle(textBox9.Text);

                float smallCuttingTime = (per / vrez_speed) + (vrez_count * vrez_time);
                aveCuttingTime = cuttingTime + smallCuttingTime;
            }

            return aveCuttingTime;
        }

        private void NumericUpDown3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(CalculateSmallConture());
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(CalculateSmallConture());
        }

        private void NumericUpDown4_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(CalculateSmallConture());
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(CalculateSmallConture());
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadMaterials();

            string material = comboBox1.Text;
            string ticknessString = comboBox2.Text;
            GetInformationAboutCutting(material, ticknessString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float OsnTime = Convert.ToSingle(textBox3.Text);
            DopTime dt = new DopTime(OsnTime);
            dt.Show();
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
            this.Width = 870;
            this.Height = 370;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Width = 700;
            this.Height = 370;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }
    }
}

