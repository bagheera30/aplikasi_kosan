using pembarayarn_onesiforus;
using System;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Contracts;

namespace pembayaran_onesiforus
{
    class Program
    {
        static void Main(string[] args)
        {
            pembayaranconfig pembayaranConfig = new pembayaranconfig();
            Console.WriteLine("Tagihan Anda: 1.000.000");

            Console.WriteLine("\nSilakan pilih metode pembayaran baru:");
            Console.WriteLine("1. E-Wallet");
            Console.WriteLine("2. Cash");
            Console.WriteLine("3. QRIS");

            int inputMetode = int.Parse(Console.ReadLine());
            pembayaranConfig.ubahMetode(inputMetode);
            Console.WriteLine("Metode Pembayaran : " + pembayaranConfig.config.metodePembayaran);

            Console.WriteLine("\nApakah Anda ingin mengkonfirmasi pembayaran ini? (Y/N)");
            string inputKonfirmasi = Console.ReadLine();

            Contract.Requires(!string.IsNullOrEmpty(inputKonfirmasi));
            Contract.Requires(inputKonfirmasi.Equals("Y", StringComparison.OrdinalIgnoreCase) || inputKonfirmasi.Equals("N", StringComparison.OrdinalIgnoreCase));

            if (inputKonfirmasi == "Y" || inputKonfirmasi == "y")
            {
                Console.WriteLine("Pembayaran telah dikonfirmasi.");

                // melakukan pembayaran
                pembayaranState pembayaranState = new pembayaranState();
                pembayaranState.ActivateTrigger(bayarTrigger.INPUT_PEMBAYARAN);
                pembayaranState.ActivateTrigger(bayarTrigger.CHECK_PEMBAYARAN);
                pembayaranState.ActivateTrigger(bayarTrigger.BALANCE);
                Console.WriteLine("Status pembayaran saat ini: " + pembayaranState.GetStatusAwal());
            }
            else
            {
                Console.WriteLine("Pembayaran dibatalkan.");

                Console.WriteLine("\nApakah Anda ingin mengubah metode pembayaran lagi? (Y/N)");
                string inputUlang = Console.ReadLine();

                Contract.Requires(!string.IsNullOrEmpty(inputUlang));
                Contract.Requires(inputUlang.Equals("Y", StringComparison.OrdinalIgnoreCase) || inputUlang.Equals("N", StringComparison.OrdinalIgnoreCase));

                if (inputUlang == "Y" || inputUlang == "y")
                {
                    Console.WriteLine("\nSilakan pilih metode pembayaran baru:");
                    Console.WriteLine("1. E-Wallet");
                    Console.WriteLine("2. Cash");
                    Console.WriteLine("3. QRIS");

                    inputMetode = int.Parse(Console.ReadLine());
                    pembayaranConfig.ubahMetode(inputMetode);
                    Console.WriteLine("Metode Pembayaran telah diubah menjadi: " + pembayaranConfig.config.metodePembayaran);

                    Console.WriteLine("\nApakah Anda ingin mengkonfirmasi pembayaran baru ini? (Y/N)");
                    inputKonfirmasi = Console.ReadLine();

                    Contract.Requires(!string.IsNullOrEmpty(inputKonfirmasi));
                    Contract.Requires(inputKonfirmasi.Equals("Y", StringComparison.OrdinalIgnoreCase) || inputKonfirmasi.Equals("N", StringComparison.OrdinalIgnoreCase));

                    if (inputKonfirmasi == "Y" || inputKonfirmasi == "y")
                    {
                        Console.WriteLine("Pembayaran telah dikonfirmasi.");

                        // melakukan pembayaran
                        pembayaranState pembayaranState = new pembayaranState();
                        pembayaranState.ActivateTrigger(bayarTrigger.INPUT_PEMBAYARAN);
                        pembayaranState.ActivateTrigger(bayarTrigger.CHECK_PEMBAYARAN);
                        pembayaranState.ActivateTrigger(bayarTrigger.BALANCE);
                        Console.WriteLine("Status pembayaran saat ini: " + pembayaranState.GetStatusAwal());
                    }
                    else
                    {
                        Console.WriteLine("Pembayaran dibatalkan.");
                    }
                }
                else
                {
                    Console.WriteLine("Terima kasih!");
                }
            }
            Console.ReadLine();
        }
    }
}


