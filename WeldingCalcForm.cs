using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Norms
{
    public partial class WeldingCalcForm : Form
    {
        private static readonly HttpClient _httpClient = new();
        public float _kantovka;
        public float _pravka;
        public int _plotnostMaterial;
        public int _plotnostMaterialForMassa;
        public float _zachistkaSvarki;
        public float _zachistkaPodSvarku;
        public float _pravkaValue;
        public float _slesarka;
        public float _mWire;
        public float _electricPower;
        public float _weldingTime;
        public float _ustanovkaPodduva;
        public float _katet;
        public float _numberCount = 1;
        public float _sumWeldingTime;
        public float _sumPlumbingTime;
        public float _sumWireMass;
        public float _coeffPrihvatka;
        public float _coefMetallNaplavka;
        public WeldingCalcForm()
        {
            InitializeComponent();
            GetMaterials();
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            comboBox6.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
        }

        private async Task GetMaterials()
        {
            string url = "http://192.168.71.83:3000/welding_materials";

            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                List<Materials> materials = await JsonSerializer.DeserializeAsync<List<Materials>>(stream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultBufferSize = 15360,
                    IgnoreNullValues = true,
                });

                comboBox4.DataSource = materials;
                comboBox4.DisplayMember = "MaterialName";
                comboBox4.ValueMember = "MaterialName";
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Ошибка запроса: {e.Message}");
            }
            catch (JsonException e)
            {
                MessageBox.Show($"Ошибка десериализации JSON: {e.Message}");
            }
        }

        private async Task GetWeldingType()
        {
            string material = comboBox4.Text;
            string url = $"http://192.168.71.83:3000/welding_types?material_name={material}";

            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                List<WeldingTypes> weldingTypes = await JsonSerializer.DeserializeAsync<List<WeldingTypes>>(stream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultBufferSize = 15360,
                    IgnoreNullValues = true,
                });

                comboBox5.DataSource = weldingTypes;
                comboBox5.DisplayMember = "WeldingTypeName";
                comboBox5.ValueMember = "WeldingTypeName";
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Ошибка запроса: {e.Message}");
            }
            catch (JsonException e)
            {
                MessageBox.Show($"Ошибка десериализации JSON: {e.Message}");
            }
        }

        private async Task GetKatet()
        {
            string material = comboBox4.Text;
            string welding_type = comboBox5.Text;
            string seam_type_name = comboBox1.Text;

            string url = $"http://192.168.71.83:3000/katets?material_name={material}&welding_type_name={welding_type}&seam_type_name={seam_type_name}";

            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                List<Katets> katets = await JsonSerializer.DeserializeAsync<List<Katets>>(stream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultBufferSize = 15360,
                    IgnoreNullValues = true,
                });

                comboBox2.DataSource = katets;
                comboBox2.DisplayMember = "KatetValue";
                comboBox2.ValueMember = "KatetValue";
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Ошибка запроса: {e.Message}");
            }
            catch (JsonException e)
            {
                MessageBox.Show($"Ошибка десериализации JSON: {e.Message}");
            }
        }

        private async Task GetSeamType()
        {
            string material = comboBox4.Text;
            string welding_type = comboBox5.Text;

            string url = $"http://192.168.71.83:3000/seam_type?material_name={material}&welding_type_name={welding_type}";

            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                List<SeamTypes> katets = await JsonSerializer.DeserializeAsync<List<SeamTypes>>(stream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultBufferSize = 15360,
                    IgnoreNullValues = true,
                });

                comboBox1.DataSource = katets;
                comboBox1.DisplayMember = "SeamTypeName";
                comboBox1.ValueMember = "SeamTypeName";
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"SeamTypeName|Ошибка запроса: {e.Message}");
            }
            catch (JsonException e)
            {
                MessageBox.Show($"Ошибка десериализации JSON: {e.Message}");
            }
        }

        private async Task GetCrossSecArea()
        {
            string material = comboBox4.Text;
            string welding_type = comboBox5.Text;
            float katet = Convert.ToSingle(comboBox2.Text);
            string seamType = comboBox1.Text;

            string url = $"http://192.168.71.83:3000/cross_sec_area?material_name={material}&welding_type_name={welding_type}&katet_value={katet}&seam_type_name={seamType}";

            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                List<CrossSecArea> crossSecArea = await JsonSerializer.DeserializeAsync<List<CrossSecArea>>(stream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultBufferSize = 15360,
                    IgnoreNullValues = true,
                });

                comboBox7.DataSource = crossSecArea;
                comboBox7.DisplayMember = "CrossSecAreaName";
                comboBox7.ValueMember = "CrossSecAreaName";
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"CrossSecAreaName|Ошибка запроса: {e.Message}");
            }
            catch (JsonException e)
            {
                MessageBox.Show($"Ошибка десериализации JSON: {e.Message}");
            }
        }

        private async Task GetWireDiameter()
        {
            string material = comboBox4.Text;
            string welding_type = comboBox5.Text;
            float katet = Convert.ToSingle(comboBox2.Text);
            string seamType = comboBox1.Text;
            float crossSecArea = Convert.ToSingle(comboBox7.Text);

            string url = $"http://192.168.71.83:3000/wire_diameter?material_name={material}&welding_type_name={welding_type}&katet_value={katet}&seam_type_name={seamType}&area_value={crossSecArea}";

            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                List<WireDiameter> wireDiameter = await JsonSerializer.DeserializeAsync<List<WireDiameter>>(stream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultBufferSize = 15360,
                    IgnoreNullValues = true,
                });

                comboBox3.DataSource = wireDiameter;
                comboBox3.DisplayMember = "WireDiameterValue";
                comboBox3.ValueMember = "WireDiameterValue";
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"WireDiameterValue|Ошибка запроса: {e.Message}");
            }
            catch (JsonException e)
            {
                MessageBox.Show($"Ошибка десериализации JSON: {e.Message}");
            }
        }

        private async Task GetTnsh()
        {
            string material = comboBox4.Text;
            string welding_type = comboBox5.Text;
            float katet = Convert.ToSingle(comboBox2.Text);
            string seamType = comboBox1.Text;
            float crossSecArea = Convert.ToSingle(comboBox7.Text);
            float wireDiameter = Convert.ToSingle(comboBox3.Text);

            string url = $"http://192.168.71.83:3000/tnsh?material_name={material}&welding_type_name={welding_type}&katet_value={katet}&seam_type_name={seamType}&area_value={crossSecArea}&diameter_value={wireDiameter}";

            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                List<Tnsh> tnshList = await JsonSerializer.DeserializeAsync<List<Tnsh>>(stream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultBufferSize = 15360,
                    IgnoreNullValues = true,
                });

                if (tnshList != null && tnshList.Count > 0)
                {
                    Tnsh tnsh = tnshList[0];

                    decimal valueToDisplay = Convert.ToDecimal(tnsh.TNSHValue);

                    if (valueToDisplay >= numericUpDown5.Minimum && valueToDisplay <= numericUpDown5.Maximum)
                    {
                        numericUpDown5.Value = valueToDisplay;
                    }
                    else
                    {
                        MessageBox.Show("Полученное значение вне допустимого диапазона.");
                    }
                }
                else
                {
                    MessageBox.Show("Данные не были получены с сервера.");
                }
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Ошибка запроса: {e.Message}");
            }
            catch (JsonException e)
            {
                MessageBox.Show($"Ошибка десериализации JSON: {e.Message}");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void WeldingCalcForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Титан")
            {
                _plotnostMaterial = 7840;
                _plotnostMaterialForMassa = 4500;

                comboBox9.Enabled = true;
                comboBox9.SelectedIndex = 0;
                _coefMetallNaplavka = 12;
            }
            else if (comboBox4.Text == "Аллюминий и сплавы")
            {
                _plotnostMaterial = 2700;
                _plotnostMaterialForMassa = 2700;

                comboBox9.SelectedIndex = 1;
                comboBox9.Enabled = false;
                _coefMetallNaplavka = 2;
            }
            else if (comboBox4.Text == "Высоколегированные стали")
            {
                _plotnostMaterial = 7840;
                _plotnostMaterialForMassa = 7840;

                comboBox9.Enabled = true;
                comboBox9.SelectedIndex = 0;
                _coefMetallNaplavka = 12;
            }
            else if (comboBox4.Text == "Низколегированные стали")
            {
                _plotnostMaterial = 7840;
                _plotnostMaterialForMassa = 7840;

                _coefMetallNaplavka = 14;
                comboBox9.Enabled = false;
            }


            GetWeldingType();

            CalculateSlesarka();
            CalculateProvoloka();
        }

        private void CalculateProvoloka()
        {
            if (!String.IsNullOrEmpty(comboBox7.Text))
            {
                float seamLength = (float)numericUpDown1.Value * _coeffPrihvatka;
                float crossSecArea = Convert.ToSingle(comboBox7.Text);

                _mWire = 0.000001f * seamLength * crossSecArea * _plotnostMaterialForMassa;
                textBox9.Text = Math.Round(_mWire, 2).ToString();
            }
        }

        private void CalculateElectricPower()
        {
            if (!String.IsNullOrEmpty(comboBox7.Text))
            {
                _electricPower = (Convert.ToSingle(comboBox7.Text) * _plotnostMaterial * 0.06f) / ((float)numericUpDown5.Value * _coefMetallNaplavka * 0.8f);
                label12.Text = Math.Round(_electricPower, 0).ToString();
            }
        }

        public void CalculateWelding()
        {
            float seamOstiv = (float)numericUpDown1.Value * _coeffPrihvatka * 5;
            float tnshneizkart = (float)numericUpDown5.Value + 1;
            float tvi = _ustanovkaPodduva;

            float tsht = (tnshneizkart * ((float)numericUpDown1.Value * _coeffPrihvatka + tvi) * 1.69f);
            _weldingTime = tsht + seamOstiv;
            textBox7.Text = Math.Round(_weldingTime, 2).ToString();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSeamType();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCrossSecArea();
            CalculateSlesarka();
            CalculateProvoloka();
        }

        private void SeamTypeImageVisualization(string seamTypeName)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetKatet();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetWireDiameter();
            CalculateElectricPower();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                numericUpDown5.ReadOnly = true;
                numericUpDown5.Enabled = false;

                GetTnsh();
            }
            else
            {
                numericUpDown5.ReadOnly = false;
                numericUpDown5.Enabled = true;
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTnsh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KantovkaForm kf = new KantovkaForm
            {
                Owner = this
            };
            kf.ShowDialog();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                button5.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
                _kantovka = 0f;
            }

            CalculateSborkaTime();
            CalculateWelding();
            CalculateSlesarka();
        }

        public void CalculateSborkaTime()
        {
            float transp = 14.4f * Convert.ToSingle(numericUpDown2.Value);
            float normTimeSborka = (transp + _kantovka + 15) / 2;
            textBox4.Text = Math.Round(normTimeSborka, 2).ToString();
            textBox5.Text = Math.Round(normTimeSborka, 2).ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            CalculateSborkaTime();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textBox8.Text = "0";
                _pravkaValue = 0f;
                textBox8.Enabled = false;
            }
            else
            {
                textBox8.Enabled = true;
            }

            CalculateSlesarka();
        }

        public void CalculateSlesarka()
        {
            float seamlengh = (float)numericUpDown1.Value * _coeffPrihvatka;

            _zachistkaSvarki = seamlengh * 10;
            _zachistkaPodSvarku = seamlengh * 7;
            if (!String.IsNullOrEmpty(comboBox2.Text))
            {
                _katet = Convert.ToSingle(comboBox2.Text);

                if (!checkBox1.Checked)
                {
                    _pravkaValue = 0f;
                }
                else
                {
                    _pravkaValue = ((((int)numericUpDown3.Value / ((_plotnostMaterial * (_katet * 0.001f))) * 10000) / 500) * 1.55f * _katet) / 4;
                }
                _slesarka = _zachistkaSvarki + _zachistkaPodSvarku + _pravkaValue;
                textBox8.Text = Math.Round(_pravkaValue, 2).ToString();
                textBox6.Text = Math.Round(_slesarka, 2).ToString();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CalculateSlesarka();
            CalculateWelding();
            CalculateProvoloka();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            CalculateWelding();
            CalculateElectricPower();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            CalculateSlesarka();
        }

        public void CalculateSum()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[4].Value != null)
                    {
                        if (double.TryParse(row.Cells[4].Value.ToString(), out double value5))
                        {
                            _sumWeldingTime += (float)value5;
                        }
                    }

                    if (row.Cells[5].Value != null)
                    {
                        if (double.TryParse(row.Cells[5].Value.ToString(), out double value6))
                        {
                            _sumPlumbingTime += (float)value6;
                        }
                    }

                    if (row.Cells[6].Value != null)
                    {
                        if (double.TryParse(row.Cells[6].Value.ToString(), out double value7))
                        {
                            _sumWireMass += (float)value7;
                        }
                    }
                }
            }

            textBox1.Text = Math.Round(_sumWeldingTime, 2).ToString();
            textBox2.Text = Math.Round(_sumPlumbingTime, 2).ToString();
            textBox3.Text = Math.Round(_sumWireMass, 2).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string seamType = comboBox1.Text;
            string seamLength = Convert.ToString((float)numericUpDown1.Value * _coeffPrihvatka);
            string amperage = label12.Text;
            string timeWelding = textBox7.Text;
            string timePlumbing = textBox6.Text;
            string wireMass = textBox9.Text;
            string crossSecArea = comboBox7.Text;
            string wireDiameter = comboBox3.Text;
            string detailsCount = Convert.ToString(numericUpDown2.Value);
            string sborkaMass = Convert.ToString(numericUpDown3.Value);
            string electrod = comboBox9.Text;

            dataGridView1.Rows.Add(_numberCount, seamType, seamLength, amperage, timeWelding, timePlumbing, wireMass, crossSecArea, wireDiameter, detailsCount, sborkaMass, electrod);

            _numberCount++;

            CalculateSum();

            label26.Text = Convert.ToString(_numberCount + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Выберите строку для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }
                    dataGridView1.Rows.Remove(row);
                }
            }

            CalculateSum();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";

            _sumWeldingTime = 0f;
            _sumPlumbingTime = 0f;
            _sumWireMass = 0f;
        }

        private void PrihvatkaCoef()
        {
            _coeffPrihvatka = 1.2f;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            PrihvatkaCoef();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrihvatkaCoef();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex == 0 && comboBox4.Text == "Высоколегированные стали" ||
                comboBox9.SelectedIndex == 0 && comboBox4.Text == "Титан")
            {
                _coefMetallNaplavka = 12;
            }
            else if (comboBox9.SelectedIndex == 1 && comboBox4.Text == "Высоколегированные стали" ||
                comboBox9.SelectedIndex == 1 && comboBox4.Text == "Титан")
            {
                _coefMetallNaplavka = 4;
            }
        }
    }

    public class Materials
    {
        [JsonPropertyName("material_name")]
        public string? MaterialName { get; set; }
    }

    public class WeldingTypes
    {
        [JsonPropertyName("welding_type_name")]
        public string? WeldingTypeName { get; set; }
    }

    public class Katets
    {
        [JsonPropertyName("katet_value")]
        public string? KatetValue { get; set; }
    }

    public class SeamTypes
    {
        [JsonPropertyName("seam_type_name")]
        public string? SeamTypeName { get; set; }
    }

    public class CrossSecArea
    {
        [JsonPropertyName("area_value")]
        public float CrossSecAreaName { get; set; }
    }

    public class WireDiameter
    {
        [JsonPropertyName("diameter_value")]
        public float WireDiameterValue { get; set; }
    }

    public class Tnsh
    {
        [JsonPropertyName("tnsh_value")]
        public float TNSHValue { get; set; }
    }
}
