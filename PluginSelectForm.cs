using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Norms
{
    public partial class PluginSelectForm : Form
    {
        public PluginSelectForm()
        {
            InitializeComponent();
            LoadPlugins();
        }

        private void PluginSelectForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadPlugins()
        {
            // Получение пути к папке с плагинами
            string pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, config.pluginFolder);

            // Проверка существования папки и получение файлов .exe
            if (Directory.Exists(pluginsPath))
            {
                var exeFiles = Directory.GetFiles(pluginsPath, "*.exe");

                // Заполнение ListBox именами файлов
#pragma warning disable CS8620 // Аргумент запрещено использовать для параметра из-за различий в отношении допустимости значений NULL для ссылочных типов.
                listBox1.Items.AddRange(items: exeFiles.Select(Path.GetFileName).ToArray());
#pragma warning restore CS8620 // Аргумент запрещено использовать для параметра из-за различий в отношении допустимости значений NULL для ссылочных типов.
            }
            else
            {
                MessageBox.Show($"Папка {config.pluginFolder} не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // Проверка, что элемент был выбран
            if (listBox1.SelectedItem != null)
            {
                string selectedFile = listBox1.SelectedItem.ToString();
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, config.pluginFolder, selectedFile);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

                try
                {
                    // Запуск выбранного файла
                    Process process = Process.Start(filePath);
                    process.WaitForExit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось запустить приложение: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
