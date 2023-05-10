using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pembarayarn_onesiforus
{
   public enum metodePembayaran 
    {
        E_WALLET,
        CASH,
        QRIS
    }

    public class pembayaranconfig
    {
        public Config config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string configFileName = "pembayaran_config.json";
        public pembayaranconfig()
        {
            try
            {
                ReadConfig();
            }
            catch
            {
                SetDefault();
                WriteConfig();
            }
        }
        private Config ReadConfig()
        {
            string jsonFromFile = File.ReadAllText(path + '/' + configFileName);
            config = JsonSerializer.Deserialize<Config>(jsonFromFile);
            return config;
        }

        public void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config, options);
            string fullPath = path + '/' + configFileName;
            File.WriteAllText(fullPath, jsonString);
        }

        private void SetDefault() 
        {
            config = new Config(metodePembayaran.E_WALLET,6000);
        }
        public metodePembayaran ubahMetode(int input) 
        {
            if (input == 1)
            {
                return config.metodePembayaran = metodePembayaran.E_WALLET;
            }
            else if (input == 2)
            {
                return config.metodePembayaran = metodePembayaran.CASH;
            }
            else 
            {
                return config.metodePembayaran = metodePembayaran.QRIS;
            }
        }
        public int biayaAdmin(metodePembayaran metode) 
        {
            if (metode == metodePembayaran.CASH)
            {
                return 8000;
            }
            else if (metode == metodePembayaran.QRIS)
            {
                return 5000;
            }
            else 
            {
                return config.biayaAdmin;
            }
        }

    }

    public class Config 
    {
        public metodePembayaran metodePembayaran { get; set; }
        public int biayaAdmin { get; set; }

        public Config() { }

        public Config(metodePembayaran metodePembayaran, int biayaAdmin) 
        {
            this.biayaAdmin = biayaAdmin;
            this.metodePembayaran = metodePembayaran;
        }

    }
}
