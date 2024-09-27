using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Norms
{
    public partial class ProgrammConverter : Form
    {
        private string _machine;
        private string _programmPath;
        private string _programmNumber;
        private string _metall;
        private double _tickness;
        private string _startGas;
        private string _startRule;
        private string _selectedGas;
        private string _changedRule;
        private string _gas;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public ProgrammConverter()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
            InitializeComponent();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void ProgrammConverter_Load(object sender, EventArgs e)
        {

        }

        private SQLiteDataReader SQLiteGetData(string query, out SQLiteConnection sqliteConn)
        {
            SQLiteDataReader SLDR = null;
            sqliteConn = new SQLiteConnection(config.sqLiteConnectionString);
            try
            {
                sqliteConn.Open();
                SQLiteCommand command = new SQLiteCommand(query, sqliteConn);
                SLDR = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
                sqliteConn.Close();
            }

            return SLDR;
        }

        private string GetGas(string rule)
        {
            string sqlQuery = $"SELECT MACHINE.SHORT_NAME as 'Станок', MATERIAL.MATERIAL_NAME 'Металл', GAS.SHORT_NAME AS 'Газ', RULESLIST.TICKNESS as 'Толщина', RULESLIST.MACHINE_RULE as 'Правило' FROM GAS INNER JOIN RULESLIST ON GAS.GAS_CODE = RULESLIST.GAS INNER JOIN MACHINE ON RULESLIST.MACHINE = MACHINE.MACHINE_CODE INNER JOIN MATERIAL ON RULESLIST.METALL = MATERIAL.MATERIAL_CODE WHERE RULESLIST.MACHINE_RULE = '{rule}'";

            SQLiteConnection sqliteConn;
            SQLiteDataReader SLDR = SQLiteGetData(sqlQuery, out sqliteConn);

            while (SLDR.Read())
            {
                //comboBox1.Items.Add(SLDR[0]);
                _gas = SLDR["Газ"].ToString();
            }

            SLDR.Close();
            sqliteConn.Close();

            return _gas;
        }

        private void Get3030Rule()
        {
            string metall = "";

            if (_metall == "St37-")
                metall = "Конструкционная сталь";
            else if (_metall == "4301-")
                metall = "Нержавеющая сталь";

            string sqlQuery = $"SELECT MACHINE.SHORT_NAME as 'Станок', MATERIAL.MATERIAL_NAME 'Металл', GAS.SHORT_NAME AS 'Газ', RULESLIST.TICKNESS as 'Толщина', RULESLIST.MACHINE_RULE as 'Правило' FROM GAS INNER JOIN RULESLIST ON GAS.GAS_CODE = RULESLIST.GAS INNER JOIN MACHINE ON RULESLIST.MACHINE = MACHINE.MACHINE_CODE INNER JOIN MATERIAL ON RULESLIST.METALL = MATERIAL.MATERIAL_CODE WHERE MATERIAL.MATERIAL_NAME = '{metall}' AND RULESLIST.TICKNESS = {_tickness} AND MACHINE.SHORT_NAME = '3030'";

            SQLiteConnection sqliteConn;
            SQLiteDataReader SLDR = SQLiteGetData(sqlQuery, out sqliteConn);

            while (SLDR.Read())
            {
                _changedRule = SLDR["Правило"].ToString();
            }

            SLDR.Close();
            sqliteConn.Close();
        }

        private void on5030to3030convert()
        {
            Get3030Rule();

            List<string> oldTexts = new List<string> { _startRule, "L3050", "TruLaser 5030 classic (L15)" };
            List<string> newTexts = new List<string> { _changedRule, "L20", "TruLaser 3030 (L20)" };

            if (oldTexts.Count != newTexts.Count)
            {
                MessageBox.Show("Количество элементов в списках замен не совпадает.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(_programmPath);

                for (int i = 0; i < oldTexts.Count; i++)
                {
                    fileContent = fileContent.Replace(oldTexts[i], newTexts[i]);
                }

                if (checkBox1.Checked)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.InitialDirectory = @"\\Rclz\tools";
                    saveFileDialog.Filter = "Text files (*.lst)|*.lst|All files (*.*)|*.*";
                    saveFileDialog.Title = "Сохранить изменённый файл";
                    saveFileDialog.FileName = _programmNumber;
                    saveFileDialog.InitialDirectory = @"\\Rclz\tools";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, fileContent);
                        MessageBox.Show("Конвертация прошла успешно!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Конвертация не выполнена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    File.WriteAllText(_programmPath, fileContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при конвертации: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void From3030to5030()
        {
            GetRule();

            List<string> oldTexts = new List<string> { _startRule, "L20", "TruLaser 3030 (L20)", config.BEGIN_SHEET_TECH_3030, config.BEGIN_MACHINE_LOAD_DATA, config.LTT_STAMM_3030_RULES, "ZA,MM,216", "TC23 Standard',1,0,'TC23',5000", "5000W 250mm", "TruLaser 3030", "1240,1500" };
            List<string> newTexts = new List<string> { _changedRule, "L3050", "TruLaser 5030 classic (L15)", config.BEGIN_SHEET_TECH_5030, config.BEGIN_SHEET_LOAD, "; удалены лишние правила\r\n", "ZA,MM,187", "TC16 Standard',1,0,'TC16',6000", "6000W 7.5Z", "TruLaser 5030 classic", $"{config.xRazm}, {config.yRazm}" };

            try
            {
                string fileContent = File.ReadAllText(_programmPath, Encoding.GetEncoding(1251));

                for (int i = 0; i < oldTexts.Count; i++)
                {
                    fileContent = fileContent.Replace(oldTexts[i], newTexts[i]);
                }

                if (checkBox1.Checked)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.InitialDirectory = @"\\Rclz\tools";
                    saveFileDialog.Filter = "Text files (*.lst)|*.lst|All files (*.*)|*.*";
                    saveFileDialog.Title = "Сохранить изменённый файл";
                    saveFileDialog.FileName = _programmNumber;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, fileContent, Encoding.GetEncoding(1251));
                        MessageBox.Show("Конвертация прошла успешно!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Конвертация не выполнена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    File.WriteAllText(_programmPath, fileContent, Encoding.GetEncoding(1251));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при конвертации: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GasChange3030()
        {
            Get3030Rule();
        }

        private void GasConvert()
        {
            GetRule();

            string oldText = _startRule;
            string newText = _changedRule;

            try
            {
                if (checkBox1.Checked)
                {
                    string fileContent = File.ReadAllText(_programmPath, Encoding.GetEncoding(1251));

                    fileContent = fileContent.Replace(oldText, newText);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.InitialDirectory = @"\\Rclz\tools";
                    saveFileDialog.Filter = "Text files (*.lst)|*.lst|All files (*.*)|*.*";
                    saveFileDialog.Title = "Сохранить изменённый файл";
                    saveFileDialog.FileName = _programmNumber;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, fileContent, Encoding.GetEncoding(1251));
                        MessageBox.Show("Конвертация прошла успешно!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Конвертация не выполнена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string fileContent = File.ReadAllText(_programmPath, Encoding.GetEncoding(1251));

                    fileContent = fileContent.Replace(oldText, newText);

                    File.WriteAllText(_programmPath, fileContent, Encoding.GetEncoding(1251));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при конвертации: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetRule()
        {
            _selectedGas = comboBox2.Text;
            string changeGas = "";
            string metall = "";

            if (_selectedGas == "O2")
                changeGas = "O2";
            else if (_selectedGas == "N2 (Воздух)")
                changeGas = "N2";

            if (_metall == "St37-")
                metall = "Конструкционная сталь";
            else if (_metall == "4301-")
                metall = "Нержавеющая сталь";

            string sqlQuery = $"SELECT MACHINE.SHORT_NAME as 'Станок', MATERIAL.MATERIAL_NAME 'Металл', GAS.SHORT_NAME AS 'Газ', RULESLIST.TICKNESS as 'Толщина', RULESLIST.MACHINE_RULE as 'Правило' FROM GAS INNER JOIN RULESLIST ON GAS.GAS_CODE = RULESLIST.GAS INNER JOIN MACHINE ON RULESLIST.MACHINE = MACHINE.MACHINE_CODE INNER JOIN MATERIAL ON RULESLIST.METALL = MATERIAL.MATERIAL_CODE WHERE GAS.SHORT_NAME = '{changeGas}' AND MACHINE.SHORT_NAME = '{comboBox1.Text}' AND RULESLIST.TICKNESS = {_tickness} AND MATERIAL.MATERIAL_NAME = '{metall}'";

            SQLiteConnection sqliteConn;
            SQLiteDataReader SLDR = SQLiteGetData(sqlQuery, out sqliteConn);

            while (SLDR.Read())
            {
                _changedRule = SLDR["Правило"].ToString();
            }

            SLDR.Close();
            sqliteConn.Close();
        }

        private void GasStanokChange()
        {
            string selectedChangeStanok = comboBox1.Text;
            string selectedChangeGas = comboBox2.Text;

            if (comboBox1.Text == "5030")
            {
                if (_machine == "L3050" && selectedChangeGas != _startGas)
                    GasConvert();
                else if (_machine == "L20")
                {
                    if (config.xRazm != 0 && config.xRazm != 0)
                        From3030to5030();
                    else
                        MessageBox.Show("Задайте минимальную карту программы!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Конвертация не произошла, проверьте, что вы выбрали станок/газ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox1.Text == "3030")
            {
                if (_machine == "L3050")
                    on5030to3030convert();
                else if (_machine == "L20")
                    GasChange3030();
            }
            else if (comboBox1.Text == "1005")
                MessageBox.Show("Конвертация на данный станок в данный момент невозможна!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private string ExtractSubstring(string text)
        {
            string result = "";

            string t2dMarker = "T2D";
            string endMarker = "30-2";

            int t2dIndex = text.IndexOf(t2dMarker);
            int endIndex = text.IndexOf(endMarker);

            if (t2dIndex != -1 && t2dIndex + t2dMarker.Length + 5 <= text.Length)
                result = text.Substring(t2dIndex, t2dMarker.Length + 5);
            if (endIndex != -1 && endIndex >= 14)
                result = text.Substring(endIndex - 14, 14) + endMarker;

            _startRule = result;

            return result;
        }

        private void ProcessFileContent(string content)
        {
            string[] searchLValues = { "L3050", "L20" };
            _machine = searchLValues.FirstOrDefault(value => content.Contains(value)) ?? "Не найдено";

            string[] searchStValues = { "St37", "4301" };
            string searchStValue = searchStValues.FirstOrDefault(value => content.Contains(value)) ?? "Не найдено";

            if (searchStValue != "Не найдено")
            {
                _metall = $"{searchStValue}-";
                int index = content.IndexOf(_metall) + _metall.Length;
                string numberPart = new string(content.Skip(index).TakeWhile(char.IsDigit).ToArray());

                if (double.TryParse(numberPart, out double number))
                    _tickness = number / 10;
            }

            string extractedSubstring = ExtractSubstring(content);

            label11.Text = $"{_programmPath}     Правило: {extractedSubstring}";
            label9.Text = _programmNumber;

            if (_machine == "L3050")
                label4.Text = "5030";
            else if (_machine == "L20")
                label4.Text = "3030";

            label14.Text = Convert.ToString(_tickness);

            if (_metall == "St37-")
                label16.Text = "Конструкционная сталь";
            else if (_metall == "4301-")
                label16.Text = "Нержавеющая сталь";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"\\Rclz\tools",
                Filter = "Text files (*.lst)|*.lst|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                _programmPath = filePath;
                _programmNumber = Path.GetFileName(filePath);

                if (_programmNumber.Length > 4)
                {
                    _programmNumber = _programmNumber.Substring(0, _programmNumber.Length - 4);
                }

                string fileContent = File.ReadAllText(filePath);
                ProcessFileContent(fileContent);
                _startGas = GetGas(_startRule);

                config.xRazm = 0;
                config.yRazm = 0;
            }

            label7.Text = _startGas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_machine) && !String.IsNullOrEmpty(_metall) && !String.IsNullOrEmpty(_startGas) && !String.IsNullOrEmpty(_startRule))
                GasStanokChange();
            else
                MessageBox.Show("Проверьте, что возможность переноса программ существует, если вы в этом уверены, но программа не работает, обратитесь к Инженеру-программисту Лукьянову Даниле из отдела ОТППиПр", "Что-то пошло не так!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "3030")
                comboBox2.Enabled = false;
            else if (comboBox1.Text == "5030")
                comboBox2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MetallRazm mr = new MetallRazm();
            mr.ShowDialog();
        }

        private void ProgrammConverter_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
