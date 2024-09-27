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
    public partial class DopTimeUgolok : Form
    {
        public DopTimeUgolok()
        {
            InitializeComponent();
        }

        private void DopTimeUgolok_Load(object sender, EventArgs e)
        {

        }

        private void FinalTime()
        {
            double finalTime = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text) + Convert.ToDouble(textBox3.Text);

            textBox4.Text = finalTime.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int t1 = CalculateTime(30, 12, 6, (int)numericUpDown1.Value);
            textBox1.Text = t1.ToString();

            FinalTime();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {


            int t2 = CalculateTime(30, 12, 6, (int)numericUpDown2.Value) + 1;
            textBox2.Text = t2.ToString();

            FinalTime();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            int t3 = CalculateTime(30, 12, 6, (int)numericUpDown3.Value) + 2;
            textBox3.Text = t3.ToString();

            FinalTime();
        }

        static int CalculateTime(int firstTime, int secondTime, int subsequentTime, int n)
        {
            if (n <= 0) return 0;

            int firstAngleTime = firstTime;
            int secondAngleTime = n > 1 ? secondTime : 0;
            int subsequentAnglesTime = (n > 2 ? n - 2 : 0) * subsequentTime;

            return firstAngleTime + secondAngleTime + subsequentAnglesTime;
        }

        private void DopTimeUgolok_FormClosed(object sender, FormClosedEventArgs e)
        {
            config.openedWindows -= 1;
        }
    }
}
