using pembarayarn_onesiforus;
using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace pembayaran_onesiforus
{
    class Program
    {
        static void Main(string[] args)
        {/*
            // Inisialisasi pembayaranState
            pembayaranState pembayaran = new pembayaranState();

            // Mulai mesin pembayaran
            while (true)
            {
                Console.WriteLine("Silakan masukkan tindakan (input_pembayaran/check_pembayaran/balance/unbalance):");
                string input = Console.ReadLine();

                // Kirim tindakan ke pembayaranState
                switch (input)
                {
                    case "input_pembayaran":
                        pembayaran.ActivateTrigger(bayarTrigger.INPUT_PEMBAYARAN);
                        break;
                    case "check_pembayaran":
                        pembayaran.ActivateTrigger(bayarTrigger.CHECK_PEMBAYARAN);
                        break;
                    case "balance":
                        pembayaran.ActivateTrigger(bayarTrigger.BALANCE);
                        break;
                    case "unbalance":
                        pembayaran.ActivateTrigger(bayarTrigger.UNBALANCE);
                        break;
                    default:
                        Console.WriteLine("Tindakan tidak dikenal.");
                        break;
                }

            }
            */
            pembayaranconfig config = new pembayaranconfig();
            Console.WriteLine("Metode pembayaran saat ini: " + config.config.metodePembayaran);
            Console.WriteLine("Biaya admin saat ini: " + config.config.biayaAdmin);

            Console.WriteLine("Apakah Anda ingin mengubah metode pembayaran? (y/n)");
            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.WriteLine("Pilih metode pembayaran baru: ");
                Console.WriteLine("1. E-Wallet");
                Console.WriteLine("2. Cash");
                Console.WriteLine("3. QRIS");

                int metodeInput = Convert.ToInt32(Console.ReadLine());
                config.ubahMetode(metodeInput);
                config.WriteConfig();
                Console.WriteLine("Metode pembayaran berhasil diubah menjadi: " + config.config.metodePembayaran);
            }

            Console.WriteLine("Biaya admin untuk metode pembayaran ini adalah: " + config.biayaAdmin(config.config.metodePembayaran));

        }
    }
}


