using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace menu_pembelian
{
    public class users
    {
        public int Id { get; set; }
        public string nama{ get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
    public static class usermanegement
    {
        private static List<users> Users = new List<users>();
        
        private static string fp;

        static usermanegement()
        {
            fp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");
            Users = new List<users>();
            if (File.Exists(fp))
            {
                Deserialize();
            }
        }
        public static List<users> GetUsers()
        {
           return Users;
        }
        public static users getUsersbynama(string nama)
        {
            return Users.FirstOrDefault(U => U.nama == nama);
        }
        public static void Deserialize()
        {
            try
            {
                string jsonData = File.ReadAllText(fp);
                List<users> deserializedMenus = JsonSerializer.Deserialize<List<users>>(jsonData);
                ClearMenus();

                foreach (var us in deserializedMenus)
                {
                    Users.Add(us);
                    Console.WriteLine($"Menu '{us.nama}' has been added to the library.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while deserializing the library: {e.Message}");
            }
        }
        public static void ClearMenus()
        {
            Users.Clear();
        }
        public static void Serialize()
        {
            try
            {
                string json = JsonSerializer.Serialize(Users);
                File.WriteAllText(fp, json);
                Console.WriteLine("Library has been serialized.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while serializing the library: {ex.Message}");
            }
        }
        public static void addusers(users us)
        {
            if (us == null)
            {
                Console.WriteLine("Menu object is null.");
                return;
            }

            Users.Add(us);
            Console.WriteLine($"Menu '{us.nama}' has been added to the library.");
        }
        
    }
}
