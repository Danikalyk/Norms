using System;
using System.Windows.Forms;
using ExcelDataReader;

namespace Norms
{
    public partial class ExcelSheetSelectedForm : Form
    {
        private string[] sheetNames;
        public int SelectedSheetIndex { get; private set; }

        public ExcelSheetSelectedForm(string filePath)
        {
            InitializeComponent();
            LoadSheets(filePath);
            SelectedSheetIndex = -1;
        }

        private void LoadSheets(string filePath)
        {
            using (var stream = System.IO.File.Open(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    sheetNames = new string[result.Tables.Count];

                    for (int i = 0; i < result.Tables.Count; i++)
                    {
                        sheetNames[i] = result.Tables[i].TableName;
                    }

                    listBox1.DataSource = sheetNames;
                }
            }
        }

        private void ExcelSheetSelectedForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                config.selectedSheet = listBox1.SelectedIndex;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите лист.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
