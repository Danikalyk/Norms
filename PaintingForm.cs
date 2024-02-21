using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Norms
{
    public partial class PaintingForm : Form
    {
        private float _firstCoef = 0f;
        private float _secondCoef = 0f;
        private float _nextCoef = 0f;
        private float protirkaSalfSmochRastvr = 0f;
        private float protirkaSuhSalf = 0f;
        private float obduvkaVozduh = 0f;
        private float struinObmiv = 0f;
        private DataSet ds = new DataSet();
        public PaintingForm()
        {
            InitializeComponent();

            GetInformation();
        }

        private void GetInformation()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();

            try
            {
                string sqlQuery = $"SELECT DYE_MARK FROM DYE_INFO";
                SqlDataReader DR = GetData(sqlQuery);

                string sqlQuery2 = $"SELECT PROKAT_NAME FROM METALLOPROKAT";
                SqlDataReader DR2 = GetData(sqlQuery2);

                string sqlQuery3 = $"SELECT METHOD_NAME FROM PAINTING_METHOD";
                SqlDataReader DR3 = GetData(sqlQuery3);

                string sqlQuery4 = $"SELECT NUMBER_OF_GROUP FROM COMPLEXITY_GROUPS";
                SqlDataReader DR4 = GetData(sqlQuery4);

                while (DR.Read())
                {
                    comboBox1.Items.Add(DR[0]);
                }

                while (DR2.Read())
                {
                    comboBox3.Items.Add(DR2[0]);
                }

                while (DR3.Read())
                {
                    comboBox4.Items.Add(DR3[0]);
                }

                while (DR4.Read())
                {
                    comboBox2.Items.Add(DR4[0]);
                    comboBox5.Items.Add(DR4[0]);
                }

                //Закрытие DataReader
                DR.Close();
                DR2.Close();
                DR3.Close();
                DR4.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Код ошибки: " + ex.Message, "Произошла ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        private void PaintingForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.TextChanged += NumericUpDown1_TextChanged;
            numericUpDown6.TextChanged += NumericUpDown6_TextChanged;
        }

        private void NumericUpDown1_TextChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void NumericUpDown2_TextChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void NumericUpDown3_TextChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void NumericUpDown4_TextChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void CalculateMaterialsConsumption()
        {
            if (!String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(textBox7.Text))
            {
                float normsConsLkm = 100 * Convert.ToSingle(textBox6.Text) / (Convert.ToSingle(numericUpDown6.Value) * Convert.ToSingle(textBox5.Text));
                float ploshad = Convert.ToSingle(textBox4.Text);
                float counts = (float)numericUpDown1.Value;
                float coef = Convert.ToSingle(textBox7.Text);

                float sum = 0f;
                if (counts == 1)
                {
                    sum = _firstCoef;
                }
                else if (counts == 2)
                {
                    sum = _firstCoef + _secondCoef;
                }
                else if (counts >= 3)
                {
                    sum = _firstCoef + _secondCoef + _nextCoef * counts;
                }

                float rashod = normsConsLkm * ploshad * sum * coef;
                textBox3.Text = rashod.ToString();
            }
        }

        private static SqlDataReader GetData(string query)
        {
            SqlConnection conn = new(config._connectionString);
            conn.Open();
            SqlCommand cmd = new(query, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            return DR;
        }

        private void GetInformationAboutPodgotovka()
        {
            string sqlQuery = $"SELECT OPERATIONS.OPERATION_NAME as 'Оперция', COMPLEXITY_GROUPS.NUMBER_OF_GROUP as 'Группа', PLOSHADOBRABOTKI.DIAPOSON as 'Диапозон', PROTIRKASALFRASTVOR.OPER_TIME 'Время', PROTIRKASALFRASTVOR.STEPEN as 'Степень', " +
                $"PROTIRKASALFRASTVOR.VNUTR_POVERHN as 'Время внутр', PROTIRKASALFRASTVOR.STEPEN_VNUTR as 'Степень внутр' FROM COMPLEXITY_GROUPS INNER JOIN PROTIRKASALFRASTVOR ON COMPLEXITY_GROUPS.ID = PROTIRKASALFRASTVOR.COM_GROUP INNER JOIN " +
                $"PLOSHADOBRABOTKI ON PROTIRKASALFRASTVOR.DIAPOSON = PLOSHADOBRABOTKI.ID INNER JOIN OPERATIONS ON PROTIRKASALFRASTVOR.OPERATION = OPERATIONS.ID";
            using SqlConnection connection = new SqlConnection(config._connectionString);
            connection.Open();
            SqlDataAdapter adapter = new(sqlQuery, connection);

            adapter.Fill(ds);
        }

        private void GetInformationAboutMaterialsCharacteristics()
        {
            string sqlQuery = $"SELECT DENSITY as 'Плотность', MASS_FRAC_SUB as 'Массовая доля' FROM DYE_INFO WHERE DYE_MARK = '{comboBox1.Text}'";
            SqlDataReader DR = GetData(sqlQuery);

            while (DR.Read())
            {
                textBox6.Text = Convert.ToString(DR["Плотность"]);
                numericUpDown6.Value = Convert.ToDecimal(DR["Массовая доля"]);
            }

            DR.Close();
        }

        private void GetInformationAboutCoefUsing()
        {
            string sqlQuery = $"SELECT PAINTING_METHOD.METHOD_NAME, COMPLEXITY_GROUPS.NUMBER_OF_GROUP, COEF_USING.COEF AS 'Коэффициент использования' FROM COEF_USING INNER JOIN COMPLEXITY_GROUPS ON COEF_USING.COM_GROUP = COMPLEXITY_GROUPS.ID INNER JOIN PAINTING_METHOD ON COEF_USING.METHOD = PAINTING_METHOD.ID WHERE PAINTING_METHOD.METHOD_NAME = '{comboBox4.Text}' AND COMPLEXITY_GROUPS.NUMBER_OF_GROUP = {comboBox2.Text}";
            SqlDataReader DR = GetData(sqlQuery);

            while (DR.Read())
            {
                textBox5.Text = Convert.ToString(DR["Коэффициент использования"]);
            }

            DR.Close();
        }

        private void GetInformationAboutCoefSher()
        {
            string sqlQuery = $"SELECT METALLOPROKAT.PROKAT_NAME, SHER_COEF.COEF_FIRST as 'Первый', SHER_COEF.COEF_SECOND as 'Второй', SHER_COEF.COEF_NEXT as 'Последующие' FROM SHER_COEF INNER JOIN METALLOPROKAT ON SHER_COEF.METALL = METALLOPROKAT.ID WHERE METALLOPROKAT.PROKAT_NAME = '{comboBox3.Text}'";
            SqlDataReader DR = GetData(sqlQuery);

            while (DR.Read())
            {
                _firstCoef = Convert.ToSingle(DR["Первый"]);
                _secondCoef = Convert.ToSingle(DR["Второй"]);
                _nextCoef = Convert.ToSingle(DR["Последующие"]);
            }

            DR.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetInformationAboutMaterialsCharacteristics();
            CalculateMaterialsConsumption();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetInformationAboutCoefSher();
            CalculateMaterialsConsumption();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetInformationAboutCoefUsing();
            CalculateMaterialsConsumption();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetInformationAboutCoefUsing();
            CalculateMaterialsConsumption();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void numericUpDown3_ValueChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void numericUpDown5_ValueChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void numericUpDown6_ValueChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void NumericUpDown6_TextChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void NumericUpDown4_ValueChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            string input = textBox3.Text;

            if (double.TryParse(input, out double number))
            {
                double roundedValue = Math.Round(number, 2);
                textBox3.Text = roundedValue.ToString();
            }
        }

        private void PaintingForm_FormClosing(object sender, FormClosingEventArgs e) => this.Owner.Show();

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
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
                    numericUpDown6.Enabled = true;
                    numericUpDown6.ReadOnly = false;
                }
                else
                {
                    textBox5.ReadOnly = true;
                    textBox6.ReadOnly = true;
                    numericUpDown6.Enabled = false;
                    numericUpDown6.ReadOnly = true;
                    checkBox1.Checked = true;
                    GetInformation();
                }
            }
            else
            {
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                numericUpDown6.Enabled = false;
                numericUpDown6.ReadOnly = true;
                GetInformation();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void textBox5_TextChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void textBox6_TextChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void textBox7_TextChanged(object sender, EventArgs e) => CalculateMaterialsConsumption();

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CalculateTrudPodg()
        {
            if (checkBox3.Checked)
            {

            }
            if (checkBox4.Checked)
            {

            }
            if (checkBox5.Checked)
            {

            }
            if (checkBox6.Checked)
            {

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
