using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;

namespace Norms
{
    public partial class WeldingCalcForm : Form
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public WeldingCalcForm()
        {
            InitializeComponent();
            GetMaterials();
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        }

        private async Task GetMaterials()
        {
            string url = "http://localhost:3000/welding_materials";

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
            string url = $"http://localhost:3000/welding_types?material_name={material}";

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

            string url = $"http://localhost:3000/katets?material_name={material}&welding_type_name={welding_type}";

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
            float katet = Convert.ToSingle(comboBox2.Text);

            string url = $"http://localhost:3000/seam_type?material_name={material}&welding_type_name={welding_type}&katet_value={katet}";

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

            string url = $"http://localhost:3000/cross_sec_area?material_name={material}&welding_type_name={welding_type}&katet_value={katet}&seam_type_name={seamType}";

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

            string url = $"http://localhost:3000/wire_diameter?material_name={material}&welding_type_name={welding_type}&katet_value={katet}&seam_type_name={seamType}&area_value={crossSecArea}";

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

            string url = $"http://localhost:3000/tnsh?material_name={material}&welding_type_name={welding_type}&katet_value={katet}&seam_type_name={seamType}&area_value={crossSecArea}&diameter_value={wireDiameter}";

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
            GetWeldingType();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetKatet();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSeamType();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCrossSecArea();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetWireDiameter();
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
            KantovkaForm kf = new KantovkaForm();
            kf.Owner = this;
            kf.ShowDialog();
        }
    }

    public class Materials
    {
        [JsonPropertyName("material_name")]
        public string MaterialName { get; set; }
    }

    public class WeldingTypes
    {
        [JsonPropertyName("welding_type_name")]
        public string WeldingTypeName { get; set; }
    }

    public class Katets
    {
        [JsonPropertyName("katet_value")]
        public string KatetValue { get; set; }
    }

    public class SeamTypes
    {
        [JsonPropertyName("seam_type_name")]
        public string SeamTypeName { get; set; }
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