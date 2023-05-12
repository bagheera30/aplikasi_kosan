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
                Console.WriteLine("Masukkan username anda: ");
                username = Console.ReadLine();
                if (checkUsername(username))
                {
                    Console.WriteLine("Username sudah ada, silahkan masukkan ulang.");
                }
            } while (checkUsername(username) == true || RegistrationLibrary.areNull(username) == true);

            do
            {
                Console.WriteLine("Masukkan password anda: ");
                pw = Console.ReadLine();
            } while (RegistrationLibrary.areNull(pw) == true);


            do
            {
                Console.WriteLine("Konfirmasi password anda: ");
                confirmpw = Console.ReadLine();
                if (pw != confirmpw)
                {
                    Console.WriteLine("password tidak sama, silahkan masukkan ulang");
                }
                else
                {
                    
                }
            } while (pw != confirmpw || RegistrationLibrary.areNull(confirmpw) == true);

            createAkun(name,username,pw);

            Console.WriteLine("Akun Berhasil dibuat!!!");
        }



        static bool checkUsername(string username)
        {
            var initialJson = File.ReadAllText("user.json");
            dynamic data = JArray.Parse(initialJson);

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].username == username) 
                { 
                    return true; 
                }
            }
            return false;
        }


        static void createAkun(string name, string username, string password)
        {
            var initialJson = File.ReadAllText("user.json");
            var array = JArray.Parse(initialJson);
            var itemToAdd = new JObject();
            itemToAdd["name"] = name;
            itemToAdd["username"] = username;
            itemToAdd["password"] = password;
            array.Add(itemToAdd);

            var jsonToOutput = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText("user.json", jsonToOutput);
        }






    }
}






