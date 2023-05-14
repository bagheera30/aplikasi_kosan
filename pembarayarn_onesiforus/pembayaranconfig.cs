using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
            Contract.Ensures(Contract.Result<pembayaranconfig>() != null);

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
            Contract.Ensures(Contract.Result<Config>() != null);

            string jsonFromFile = File.ReadAllText(path + '/' + configFileName);
            config = JsonSerializer.Deserialize<Config>(jsonFromFile);

            Contract.Assume(config != null);
            return config;
        }

        public void WriteConfig()
        {
            Contract.Requires(config != null);

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
            Contract.Ensures(config != null);

            config = new Config(metodePembayaran.E_WALLET,6000);

            Contract.Assume(config != null);
        }
        public metodePembayaran ubahMetode(int input) 
        {
            Contract.Requires(config != null);
            Contract.Ensures(Enum.IsDefined(typeof(metodePembayaran), Contract.Result<metodePembayaran>()));

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
            Contract.Assume(Enum.IsDefined(typeof(metodePembayaran), config.metodePembayaran));
            return config.metodePembayaran;
        }
        public int biayaAdmin(metodePembayaran metode) 
        {
            Contract.Requires(Enum.IsDefined(typeof(metodePembayaran), metode));

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
                Contract.Assume(config != null);
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
