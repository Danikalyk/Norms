using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Norms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["localWork"].Value = checkBox1.Checked.ToString().ToLower();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            bool localWork = Convert.ToBoolean(ConfigurationManager.AppSettings["localWork"]);
            MessageBox.Show("Тип получения данных изменён! Работать локально: " + localWork, "ВНИМАНИЕ", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentDirectory = Environment.CurrentDirectory;

            string executableName = "Updater.exe";

            string executablePath = Path.Combine(currentDirectory, executableName);

            if (File.Exists(executablePath))
            {
                // Запускаем процесс и ждем его завершения
                Process process = new Process();
                process.StartInfo.FileName = executablePath;
                process.Start();

                // Отключаем элементы управления на форме
                SetControlsEnabled(false);
                // Ждем завершения процесса
                process.WaitForExit();

                // Включаем элементы управления на форме после завершения процесса
                SetControlsEnabled(true);
            }
            else
            {
                MessageBox.Show($"Файл {executableName} не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            // Отключаем все элементы управления на форме
            foreach (Control control in this.Controls)
            {
                control.Enabled = enabled;
            }
        }
    }
}
