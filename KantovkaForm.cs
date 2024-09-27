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

            if(setType == 0)
            {
                if(wayStrpovka == 0)
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton3.Checked)
                        {
                            kantovka = 2.23f;
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
                    if (radioButton3.Checked)
                    {
                        kantovka = 2.23f;
                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
                if (wayStrpovka == 2)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
            }


            if (setType == 1)
            {
                if (wayStrpovka == 0)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
                if (wayStrpovka == 1)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
                if (wayStrpovka == 2)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
            }
            if (setType == 1)
            {
                if (wayStrpovka == 0)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
                if (wayStrpovka == 1)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
                if (wayStrpovka == 2)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
            }
            

            if (setType == 2)
            {
                if (wayStrpovka == 0)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
                if (wayStrpovka == 1)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
                if (wayStrpovka == 2)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
            }
            

            if (setType == 3)
            {
                if (wayStrpovka == 0)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
                if (wayStrpovka == 1)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
                if (wayStrpovka == 2)
                {
                    if (radioButton3.Checked)
                    {

                    }
                    else if (radioButton4.Checked)
                    {

                    }
                    else if (radioButton5.Checked)
                    {

                    }
                    else if (radioButton6.Checked)
                    {

                    }
                }
            }
            
        }
    }
}
