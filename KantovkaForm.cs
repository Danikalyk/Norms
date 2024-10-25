using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Norms
{
    public partial class KantovkaForm : Form
    {
        public float _kantovka;

        public KantovkaForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            radioButton1.Checked = true;
            radioButton3.Checked = true;
        }

        private void KantovkaForm_Load(object sender, EventArgs e)
        {

        }

        public float SetKantovkaValue()
        {
            int setType = comboBox1.SelectedIndex;
            int wayStrpovka = comboBox2.SelectedIndex;
            float kantovka = 0f;

            if (setType == 0)
            {
                if (wayStrpovka == 0)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 3.23f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 5.43f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 7.56f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 9.72f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 1.94f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 3.26f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 4.54f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 5.83f;
                        }
                    }
                }
                if (wayStrpovka == 1)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 2.23f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 3.43f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 4.56f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 5.69f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 1.34f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 2.06f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 2.74f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 3.41f;
                        }
                    }
                }
                if (wayStrpovka == 2)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 2.63f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 4.23f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 5.76f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 7.29f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 1.58f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 2.54f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 3.46f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 4.37f;
                        }
                    }
                }
            }


            if (setType == 1)
            {
                if (wayStrpovka == 0)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 5.49f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 9.23f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 12.85f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 16.52f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 3.29f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 5.54f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 7.71f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 9.91f;
                        }
                    }
                }
                if (wayStrpovka == 1)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 3.79f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 5.83f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 7.75f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 9.67f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 2.27f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 3.50f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 4.65f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 5.80f;
                        }
                    }
                }
                if (wayStrpovka == 2)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 4.47f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 7.19f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 9.79f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 12.39f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 2.68f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 4.31f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 5.87f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 7.43f;
                        }
                    }
                }
            }

            if (setType == 2)
            {
                if (wayStrpovka == 0)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 6.14f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 10.32f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 14.36f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 18.47f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 3.68f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 6.19f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 8.62f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 11.08f;
                        }
                    }
                }
                if (wayStrpovka == 1)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 4.24f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 6.52f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 8.66f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 10.81f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 2.54f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 3.91f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 5.20f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 6.49f;
                        }
                    }
                }
                if (wayStrpovka == 2)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 5.00f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 8.04f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 10.94f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 13.85f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 3.00f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 4.82f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 6.56f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 8.31f;
                        }
                    }
                }
            }


            if (setType == 3)
            {
                if (wayStrpovka == 0)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 4.20f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 7.06f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 9.83f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 12.64f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 2.52f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 4.24f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 5.90f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 7.58f;
                        }
                    }
                }
                if (wayStrpovka == 1)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 2.90f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 4.46f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 5.93f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 7.40f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 1.74f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 2.68f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 3.56f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 4.44f;
                        }
                    }
                }
                if (wayStrpovka == 2)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 3.42f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 5.50f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 7.49f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 9.48f;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 2.05f;
                        }
                        else if (radioButton4.Checked)
                        {
                            kantovka = 3.30f;
                        }
                        else if (radioButton5.Checked)
                        {
                            kantovka = 4.49f;
                        }
                        else if (radioButton6.Checked)
                        {
                            kantovka = 5.59f;
                        }
                    }
                }
            }
            return kantovka;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _kantovka = SetKantovkaValue();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _kantovka = SetKantovkaValue();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _kantovka = SetKantovkaValue();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _kantovka = SetKantovkaValue();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _kantovka = SetKantovkaValue();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            _kantovka = SetKantovkaValue();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            _kantovka = SetKantovkaValue();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            _kantovka = SetKantovkaValue();
        }

        private void KantovkaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner is WeldingCalcForm mainForm)
            {
                mainForm._kantovka = _kantovka;
                mainForm.CalculateSlesarka();
                mainForm.CalculateSborkaTime();
                mainForm.CalculateWelding();
            }
        }
    }
}
