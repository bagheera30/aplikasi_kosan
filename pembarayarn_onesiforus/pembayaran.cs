using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pembarayarn_onesiforus
{
    // Definisikan state mesin pembayaran
    enum PaymentState
    {
        Start,
        InputAmount,
        ConfirmAmount,
        InputPin,
        ProcessPayment,
        PaymentSuccess,
        PaymentFailed
    }

    class PaymentMachine
    {
        private double maxAmount;
        private string pin;
        private PaymentState currentState = PaymentState.Start;

        // Konstruktor
        public PaymentMachine(double maxAmount, string pin)
        {
            this.maxAmount = maxAmount;
            this.pin = pin;
        }

        // Method untuk memulai mesin pembayaran
        public void Start()
        {
            Console.WriteLine("Selamat datang di mesin pembayaran");
            Console.WriteLine("Silakan masukkan jumlah pembayaran (maksimum {0:C}):", maxAmount);
            currentState = PaymentState.InputAmount;
        }

        // Method untuk memproses input
        public void ProcessInput(string input)
        {
            switch (currentState)
            {
                case PaymentState.InputAmount:
                    // Validasi input jumlah pembayaran
                    if (double.TryParse(input, out double amount) && amount <= maxAmount)
                    {
                        Console.WriteLine("Anda akan membayar sebesar {0:C}", amount);
                        Console.WriteLine("Silakan konfirmasi pembayaran (y/n):");
                        currentState = PaymentState.ConfirmAmount;
                    }
                    else
                    {
                        Console.WriteLine("Masukkan jumlah pembayaran yang valid (maksimum {0:C}):", maxAmount);
                    }
                    break;

                case PaymentState.ConfirmAmount:
                    // Validasi input konfirmasi pembayaran
                    if (input.ToLower() == "y")
                    {
                        Console.WriteLine("Silakan masukkan PIN Anda:");
                        currentState = PaymentState.InputPin;
                    }
                    else if (input.ToLower() == "n")
                    {
                        Console.WriteLine("Pembayaran dibatalkan.");
                        currentState = PaymentState.Start;
                    }
                    else
                    {
                        Console.WriteLine("Masukkan konfirmasi yang valid (y/n):");
                    }
                    break;

                case PaymentState.InputPin:
                    // Validasi input PIN
                    if (input == pin)
                    {
                        Console.WriteLine("Pembayaran berhasil diproses.");
                        currentState = PaymentState.PaymentSuccess;
                    }
                    else
                    {
                        Console.WriteLine("PIN salah, silakan coba lagi:");
                        currentState = PaymentState.InputPin;
                    }
                    break;

                case PaymentState.PaymentSuccess:
                    Console.WriteLine("Terima kasih telah menggunakan mesin pembayaran.");
                    currentState = PaymentState.Start;
                    break;

                default:
                    break;
            }
        }
    }
}
