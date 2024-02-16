using System;
using System.Windows.Forms;

namespace Norms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stanok3030Form s3030 = new Stanok3030Form("3030");
            s3030.Owner = this;
            s3030.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stanok3030Form s3030 = new Stanok3030Form("600");
            s3030.Owner = this;
            s3030.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stanok3030Form s3030 = new Stanok3030Form("ГАР");
            s3030.Owner = this;
            s3030.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stanok3030Form s3030 = new Stanok3030Form("5030");
            s3030.Owner = this;
            s3030.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stanok3030Form s3030 = new Stanok3030Form("AXEL");
            s3030.Owner = this;
            s3030.ShowDialog();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Вы действительно хотите выйти?",
            "Сообщение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;

            this.TopMost = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaintingForm paint = new PaintingForm();
            paint.Owner = this;
            paint.ShowDialog();
        }
    }
}
