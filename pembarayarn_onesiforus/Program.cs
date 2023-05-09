using pembarayarn_onesiforus;

class Program
{
    public static object ConfigurationManager { get; private set; }

    static void Main(string[] args)
    {
        // Ambil pengaturan dari runtime configuration
        double maxAmount = Convert.ToDouble(ConfigurationManager.["MaxAmount"]);
        string pin = ConfigurationManager.["PIN"];

        // Inisialisasi mesin pembayaran dengan pengaturan dari runtime configuration
        PaymentMachine machine = new PaymentMachine(maxAmount, pin);

        // Mulai mesin pembayaran
        machine.Start();

        // Loop untuk input
        while (true)
        {
            Console.WriteLine("Silakan masukkan nomor transaksi:");
            string input = Console.ReadLine();

            // Kirim input ke mesin pembayaran
            machine.ProcessInput(input);
        }
    }
}
