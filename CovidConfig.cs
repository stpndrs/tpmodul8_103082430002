using System;
using System.IO;
using System.Text.Json;

namespace tpmodul8_103082430002
{
    public class CovidConfig
    {
        public class ConfigData
        {
            public string satuan_suhu { get; set; }
            public int batas_hari_deman { get; set; }
            public string pesan_ditolak { get; set; }
            public string pesan_diterima { get; set; }
        }

        public ConfigData config;
        private const string filePath = "covid_config.json";

        public CovidConfig()
        {
            try
            {
                ReadConfig();
            }
            catch (Exception)
            {
                SetDefault();
                WriteConfig();
            }
        }

        private void SetDefault()
        {
            // set value untuk properti di config
            config = new ConfigData();
            config.satuan_suhu = "celcius";
            config.batas_hari_deman = 14;
            config.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            config.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        private void ReadConfig()
        {
            // lalu set value ke file confignya
            string jsonString = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<ConfigData>(jsonString);
        }

        private void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void UbahSatuan()
        {
            config.satuan_suhu = (config.satuan_suhu == "celcius") ? "fahrenheit" : "celcius";
            WriteConfig(); // Simpan permanen ke JSON
        }
    }
}