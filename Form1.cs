﻿using System;
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
            this.Hide();
            Stanok3030Form s3030 = new Stanok3030Form("IGNIUS");
            s3030.Owner = this;
            s3030.ShowDialog();
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

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Спасибо, что вы это читаете! Принимая данное соглашение вы отдаёте свою душу в полноправное пользование Лукьянову 'Nevelin' Даниле! Чтобы расторгнуть договор заполните заявление в свободной форме и передайте в течении трёх дней с даты заключения договора. В противном случае ваша душа навсегда останется в рабстве!",
        "Сообщение",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);

            if (result == DialogResult.OK)
                MessageBox.Show("Договор успешно заключен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProgrammConverter pc = new ProgrammConverter();
            pc.Owner = this;
            pc.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PluginSelectForm psf = new();
            psf.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FAQForm fAQForm = new FAQForm();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WeldingCalcForm wcf = new WeldingCalcForm();
            wcf.Show();
        }
    }
}
