using System;
using System.Windows.Forms;

namespace Norms
{
    public partial class MetallRazm : Form
    {
        public MetallRazm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.xRazm = ((double)numericUpDown1.Value);
            config.yRazm = ((double)numericUpDown2.Value);

            this.Close();
        }
    }
}
