using System;
using System.Globalization;
using System.Windows.Forms;

namespace Norms
{
    public partial class DopTime : Form
    {
        public DopTime(float osnTime)
        {
            InitializeComponent();
            GetTime(osnTime);
        }

        private void GetTime(float osnTime)
        {
            if (osnTime < 3)
            {
                radioButton1.Checked = true;
            }
            else if (osnTime > 3 && osnTime < 5)
            {
                radioButton2.Checked = true;
            }
            else if (osnTime > 5)
            {
                radioButton3.Checked = true;
            }
        }

        private void DopTime_Load(object sender, EventArgs e)
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

            comboBox1.SelectedIndex = 0;
        }

        private float CalculateMetallWeight()
        {
            float xMetall = Convert.ToSingle(numericUpDown3.Value);
            float yMetall = Convert.ToSingle(numericUpDown4.Value);
            float selectedMetallTickness = Convert.ToSingle(comboBox1.Text);
            float metallWeight = 0f;

            if (radioButton6.Checked)
            {
                metallWeight = Convert.ToSingle(((xMetall) * (yMetall) * selectedMetallTickness * 7.9) / 1000000);
            }
            else if (radioButton7.Checked)
            {
                metallWeight = Convert.ToSingle(((xMetall) * (yMetall) * selectedMetallTickness * 2.7) / 1000000);
            }
            else if (radioButton8.Checked)
            {
                metallWeight = Convert.ToSingle(((xMetall) * (yMetall) * selectedMetallTickness * 4.5) / 1000000);
            }

            return metallWeight;
        }

        private float CalculteDopTime()
        {
            float dopTime = 0f;

            if (radioButton1.Checked && radioButton4.Checked)
            {
                //3 мин и менее, масса 50 кг и менее
                if (!checkBox1.Checked)
                {
                    dopTime = 11 + 2 * (float)numericUpDown1.Value + 2 * (float)numericUpDown2.Value;
                }
                else
                {
                    dopTime = (11 + 2 * (float)numericUpDown1.Value + 2 * (float)numericUpDown2.Value) + 3;
                }
            }
            else if (radioButton1.Checked && radioButton5.Checked)
            {
                //3 мин и менее, масса более 50 кг 
                if (!checkBox1.Checked)
                {
                    dopTime = 11 + 4 * (float)numericUpDown1.Value + 2 * (float)numericUpDown2.Value;
                }
                else
                {
                    dopTime = (11 + 4 * (float)numericUpDown1.Value + 2 * (float)numericUpDown2.Value) + 3;
                }

            }
            else if (radioButton2.Checked && radioButton5.Checked)
            {
                //от 3 до 5 минут, масса более 50 кг
                if (!checkBox1.Checked)
                {
                    dopTime = 11 + 2 * (float)numericUpDown1.Value + 2 * (float)numericUpDown2.Value;
                }
                else
                {
                    dopTime = (11 + 2 * (float)numericUpDown1.Value + 2 * (float)numericUpDown2.Value) + 3;
                }
            }
            else if (radioButton2.Checked && radioButton4.Checked)
            {
                //от 3 до 5 минут, масса 50 и менее
                if (!checkBox1.Checked)
                {
                    dopTime = 11 + (float)numericUpDown1.Value + 2 * (float)numericUpDown2.Value;
                }
                else
                {
                    dopTime = (11 + (float)numericUpDown1.Value + 2 * (float)numericUpDown2.Value) + 3;
                }
            }
            else if (radioButton3.Checked)
            {
                if (!checkBox1.Checked)
                {
                    dopTime = 11 + (float)numericUpDown1.Value + 2 * (float)numericUpDown2.Value;
                }
                else
                {
                    dopTime = (11 + (float)numericUpDown1.Value + 2 * (float)numericUpDown2.Value) + 3;
                }
            }

            return dopTime;
        }

        private void NumericUpDown1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(CalculteDopTime());
        }

        private void NumericUpDown2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(CalculteDopTime());
        }

        private void NumericUpDown3_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(CalculateMetallWeight());
        }

        private void NumericUpDown4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(CalculateMetallWeight());
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(CalculteDopTime());
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(CalculteDopTime());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(CalculateMetallWeight());
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(CalculateMetallWeight());
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(CalculateMetallWeight());
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(CalculateMetallWeight());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(CalculateMetallWeight());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(CalculteDopTime());
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(CalculteDopTime());
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(CalculteDopTime());
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(CalculteDopTime());
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(CalculteDopTime());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(CalculteDopTime());
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(CalculateMetallWeight());
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToSingle(textBox4.Text) <= 50)
            {
                radioButton4.Checked = true;
                radioButton5.Checked = false;
            }
            else
            {
                radioButton5.Checked = true;
                radioButton4.Checked = false;
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(CalculateMetallWeight());
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(CalculateMetallWeight());
        }

        private void DopTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.openedWindows -= 1;
        }
    }
}
