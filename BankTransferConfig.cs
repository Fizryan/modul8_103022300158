using System;
using System;
using System.IO;
using System.Text.Json;

namespace modul8_103022300158
{
    class BankTransferConfig
    {
        public string lang { get; set; }
        public string transfer_threshold { get; set; }
        public string transfer_low_fee { get; set; }
        public string transfer_high_fee { get; set; }
        public string[] methods { get; set; }
        public string confirmation { get; set; }

        private static readonly string configFilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\bank_transfer_config.json"));

        public BankTransferConfig()
        {
            ReadConfigFile();
        }

        public void UbahBahasa(string newLang)
        {
            if (lang == "en")
            {
                lang = "id";
            }
            else
            {
                lang = "en";
            }
            WriteNewConfig();
        }

        public static BankTransferConfig ReadConfigFile()
        {
            BankTransferConfig config;
            if (File.Exists(configFilePath)) {
                string json = File.ReadAllText(configFilePath);
                config = JsonSerializer.Deserialize<BankTransferConfig>(json);
            }
            else
            {
                config = new BankTransferConfig();
                config.WriteNewConfig();
            }
            return config;
        }
        private void setDefaultConfig()
        {
            lang = "eng";
            transfer_threshold = "25000000";
            transfer_low_fee = "6500";
            transfer_high_fee = "15000";
            methods = ["“RTO", "(real-time)”", "“SKN”", "“RTGS”", "“BI", "FAST”"];
            confirmation = "yes";
            WriteNewConfig();
        }

        private void WriteNewConfig()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(configFilePath, json);
        }

    }
}
