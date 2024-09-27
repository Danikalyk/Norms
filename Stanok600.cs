using System;
using System.Windows.Forms;

namespace Norms
{
    public partial class Stanok600 : Form
    {
        public Stanok600()
        {
            InitializeComponent();
        }

        private void numericUpDown8_ValueChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private float Calculate600DopTime()
        {
            float listTime = 0f;
            float programmTime = 0f;

            if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0)
            {
                listTime = (float)numericUpDown1.Value * 1;
                programmTime = (float)numericUpDown2.Value * 3;
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1)
            {
                listTime = (float)numericUpDown1.Value * 2;
                programmTime = (float)numericUpDown2.Value * 3;
            }
            else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 0)
            {
                listTime = (float)numericUpDown1.Value * 1;
                programmTime = (float)numericUpDown2.Value * 5;
            }
            else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 1)
            {
                listTime = (float)numericUpDown1.Value * 1;
                programmTime = (float)numericUpDown2.Value * 5;
            }

            float listProgrammTime = listTime + programmTime;

            return listProgrammTime;
        }

        private double Razgruzka()
        {
            double razrTime = Convert.ToDouble(numericUpDown3.Value) * 1;
            return razrTime;
        }

        private double HandDeleted()
        {
            double handDeledet = Convert.ToDouble(numericUpDown4.Value) * 0.5;
            return handDeledet;
        }

        private double Pereustanovka()
        {
            double pereustanovka = Convert.ToDouble(numericUpDown5.Value) * 3;
            return pereustanovka;
        }

        private float Control()
        {
            float controlTime = 0f;

            if (numericUpDown3.Value < 6)
            {
                controlTime = 3;
            }
            else if (numericUpDown3.Value >= 6)
            {
                float controlCount = Convert.ToSingle(numericUpDown3.Value - 5);
                controlTime = Convert.ToSingle(3 + controlCount * 0.5);
            }

            return controlTime;
        }

        private float Probivka()
        {
            float probivkaTime = 0f;
            float probivkaCount = Convert.ToSingle(numericUpDown7.Value);
            probivkaTime = Convert.ToSingle(probivkaCount) * 4;

            return probivkaTime;
        }

        private float Zatochka()
        {
            float zatochkaTime = 0f;
            int oneTime = 0;
            int twoTime = 0;
            int threeTime = 0;

            if (comboBox3.Text == "Сталь")
            {
                if (numericUpDown8.Value >= 2000)
                {
                    oneTime = Convert.ToInt32(numericUpDown8.Value / 2000 * 1);
                }
                if (numericUpDown9.Value >= 2000)
                {
                    twoTime = Convert.ToInt32(numericUpDown9.Value / 2000 * 1);
                }
                if (numericUpDown10.Value >= 2000)
                {
                    threeTime = Convert.ToInt32(numericUpDown10.Value / 2000 * 1);
                }

                zatochkaTime = oneTime + twoTime + threeTime;
            }
            else if (comboBox3.Text == "Нержавейка")
            {
                if (numericUpDown8.Value >= 1000)
                {
                    oneTime = Convert.ToInt32(numericUpDown8.Value / 1000 * 1);
                }
                if (numericUpDown9.Value >= 1000)
                {
                    twoTime = Convert.ToInt32(numericUpDown9.Value / 1000 * 1);
                }
                if (numericUpDown10.Value >= 1000)
                {
                    threeTime = Convert.ToInt32(numericUpDown10.Value / 1000 * 1);
                }

                zatochkaTime = oneTime + twoTime + threeTime;
            }
            else if (comboBox3.Text == "Алюминий")
            {
                if (numericUpDown8.Value >= 2000)
                {
                    oneTime = Convert.ToInt32(numericUpDown8.Value / 2000 * 1);
                }
                if (numericUpDown9.Value >= 2000)
                {
                    twoTime = Convert.ToInt32(numericUpDown9.Value / 2000 * 1);
                }
                if (numericUpDown10.Value >= 2000)
                {
                    threeTime = Convert.ToInt32(numericUpDown10.Value / 2000 * 1);
                }

                zatochkaTime = oneTime + twoTime + threeTime;
            }

            return zatochkaTime;
        }

        private double AverengeTime()
        {
            double calcTime = Calculate600DopTime();
            double razr = 0f;
            double handDel = 0f;
            double pereustanovka = 0f;
            double controlTime = 0f;
            double probivka = 0f;
            double aveTime;
            double zatochka = 0f;

            if (checkBox1.Checked)
            {
                razr = Razgruzka();
            }

            if (checkBox2.Checked)
            {
                handDel = HandDeleted();
            }

            if (checkBox3.Checked)
            {
                pereustanovka = Pereustanovka();
            }

            if (checkBox4.Checked)
            {
                controlTime = Control();
            }

            if (checkBox5.Checked)
            {
                probivka = Probivka();
            }

            if (checkBox6.Checked)
            {
                zatochka = Zatochka();
            }

            aveTime = calcTime + razr + handDel + pereustanovka + controlTime + probivka + zatochka;

            return aveTime;
        }

        private void Stanok600_Load(object sender, System.EventArgs e)
        {
            numericUpDown1.TextChanged += NumericUpDown1_TextChanged;
            numericUpDown2.TextChanged += NumericUpDown2_TextChanged;
            numericUpDown3.TextChanged += NumericUpDown3_TextChanged;
            numericUpDown4.TextChanged += NumericUpDown4_TextChanged;
            numericUpDown5.TextChanged += NumericUpDown5_TextChanged;
            numericUpDown6.TextChanged += NumericUpDown6_TextChanged;
            numericUpDown7.TextChanged += NumericUpDown7_TextChanged;
            numericUpDown8.TextChanged += NumericUpDown8_TextChanged;
            numericUpDown9.TextChanged += NumericUpDown9_TextChanged;
            numericUpDown10.TextChanged += NumericUpDown10_TextChanged;

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }
        private void NumericUpDown1_TextChanged(object? sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void NumericUpDown2_TextChanged(object? sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void NumericUpDown3_TextChanged(object? sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void NumericUpDown4_TextChanged(object? sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void NumericUpDown5_TextChanged(object? sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void NumericUpDown6_TextChanged(object? sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void NumericUpDown7_TextChanged(object? sender, System.EventArgs e)
        {
            if (numericUpDown7.Value == 2)
            {
                if (checkBox6.Checked)
                    numericUpDown9.Visible = true;
            }
            if (numericUpDown7.Value >= 3)
            {
                if (checkBox6.Checked)
                {
                    numericUpDown9.Visible = true;
                    numericUpDown10.Visible = true;
                }
            }
            if (numericUpDown7.Value < 2)
            {
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
            }

            textBox1.Text = AverengeTime().ToString();
        }

        private void NumericUpDown8_TextChanged(object? sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }
        private void NumericUpDown9_TextChanged(object? sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void NumericUpDown10_TextChanged(object? sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }


        private void checkBox5_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox5.Checked)
            {
                numericUpDown7.Visible = true;
                checkBox6.Visible = true;
            }
            else
            {
                numericUpDown7.Visible = false;
                numericUpDown8.Visible = false;
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
                checkBox6.Visible = false;
                label7.Visible = false;
            }

            textBox1.Text = AverengeTime().ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void numericUpDown6_ValueChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void numericUpDown7_ValueChanged(object sender, System.EventArgs e)
        {

            if (numericUpDown7.Value == 2)
            {
                if (checkBox6.Checked)
                    numericUpDown9.Visible = true;
            }
            if (numericUpDown7.Value >= 3)
            {
                if (checkBox6.Checked)
                {
                    numericUpDown9.Visible = true;
                    numericUpDown10.Visible = true;
                }
            }
            if (numericUpDown7.Value < 2)
            {
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
            }
            if (numericUpDown7.Value < 3)
            {
                numericUpDown10.Visible = false;
            }

            textBox1.Text = AverengeTime().ToString();
        }

        private void numericUpDown7_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void numericUpDown9_ValueChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void numericUpDown10_ValueChanged(object sender, System.EventArgs e)
        {
            textBox1.Text = AverengeTime().ToString();
        }

        private void checkBox6_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox6.Checked)
            {
                label7.Visible = true;
                numericUpDown8.Visible = true;
                comboBox3.Visible = true;
            }
            else
            {
                label7.Visible = false;
                numericUpDown8.Visible = false;
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
                comboBox3.Visible = true;
            }

            if (numericUpDown7.Value == 2)
            {
                if (checkBox6.Checked)
                    numericUpDown9.Visible = true;
            }
            if (numericUpDown7.Value >= 3)
            {
                if (checkBox6.Checked)
                {
                    numericUpDown9.Visible = true;
                    numericUpDown10.Visible = true;
                }
            }
            if (numericUpDown7.Value < 2)
            {
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
            }
            if (numericUpDown7.Value < 3)
            {
                numericUpDown10.Visible = false;
            }

            textBox1.Text = AverengeTime().ToString();
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown3.Visible = true;
            }
            else
            {
                numericUpDown3.Visible = false;
            }

            textBox1.Text = AverengeTime().ToString();
        }

        private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox2.Checked)
            {
                numericUpDown4.Visible = true;
            }
            else
            {
                numericUpDown4.Visible = false;
            }

            textBox1.Text = AverengeTime().ToString();
        }

        private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox3.Checked)
            {
                numericUpDown5.Visible = true;
            }
            else
            {
                numericUpDown5.Visible = false;
            }

            textBox1.Text = AverengeTime().ToString();
        }

        private void checkBox4_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox4.Checked)
            {
                numericUpDown6.Visible = true;
            }
            else
            {
                numericUpDown6.Visible = false;
            }

            textBox1.Text = AverengeTime().ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Stanok600_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.openedWindows -= 1;
        }
    }
}
