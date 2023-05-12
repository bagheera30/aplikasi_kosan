// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using UtilityLibrary;
using Newtonsoft.Json.Linq;

namespace Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string username;
            string pw;
            string confirmpw;

            Console.WriteLine("Registration page\n");

            do
            {
                Console.WriteLine("Masukkan nama anda: ");
                name = Console.ReadLine();
            } while (RegistrationLibrary.areNull(name) == true);

            do
            {
                Console.WriteLine("\nMasukkan username anda: ");
                username = Console.ReadLine();
                if (RegistrationClass.checkUsername(username))
                {
                    Console.WriteLine("Username sudah ada, silahkan masukkan ulang.");
                }
            } while (RegistrationClass.checkUsername(username) == true || RegistrationLibrary.areNull(username) == true);

            do
            {
                Console.WriteLine("\nMasukkan password anda: ");
                pw = Console.ReadLine();
                if (!RegistrationClass.checkPassword(pw))
                {
                    Console.WriteLine("Password minimal 8 karakter\n");
                }
            } while (RegistrationLibrary.areNull(pw) == true || RegistrationClass.checkPassword(pw) == false);


            do
            {
                Console.WriteLine("\nKonfirmasi password anda: ");
                confirmpw = Console.ReadLine();
                if (pw != confirmpw)
                {
                    Console.WriteLine("password tidak sama, silahkan masukkan ulang\n");
                }
                else
                {
                    
                }
            } while (pw != confirmpw || RegistrationLibrary.areNull(confirmpw) == true);

            RegistrationClass.createAkun(name,username,pw);

            Console.WriteLine("\nAkun Berhasil dibuat!!!");
        }

    }
}






