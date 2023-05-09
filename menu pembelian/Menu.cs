using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace menu_pembelian
{
    public class menu
    {
        public int id { get; set; }
        public string Nama { get; set; }
        public int harga { get; set; }
        public string foto { get; set; }

    }
    public class detail
    {
        
    }
    public static class MenuManager
    {
        private static List<menu> menus;
        private static string fp;

        static MenuManager()
        {
            fp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "menu.json");
            menus = new List<menu>();
            if (File.Exists(fp))
            {
                Deserialize();
            }
        }


        public static List<menu> GetMenus()
        {
            return menus;
        }
        public static menu getmenusbyID(int id)
        {
            return menus.FirstOrDefault(m=>m.id==id);
        }
        

            
    
        public static void Deserialize()
        {
            try
            {
                string js = File.ReadAllText(fp);
                menus = JsonSerializer.Deserialize<List<menu>>(js);
                Console.WriteLine("berhasil deserialize");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while deserializing the library: {e.Message}");
            }
        }
        public static void Serialize()
        {
            try
            {
                string json = JsonSerializer.Serialize(menus);
                File.WriteAllText(fp, json);
                Console.WriteLine("Library has been serialized.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while serializing the library: {ex.Message}");
            }
        }
        public static void addmenu(menu m)
        {
            menus.Add(m);
            Console.WriteLine($"Menu '{m.Nama}' has been added to the library.");
        }
        public static void UpdateMenu(int id, menu updatedMenu)
        {
            menu menu = menus.FirstOrDefault(m => m.id ==id);
            if (menu != null)
            {
                menu.Nama = updatedMenu.Nama;
                Console.WriteLine($"Menu with id {id} has been updated: {menu.Nama}");
            }
            else
            {
                Console.WriteLine($"Menu with id {id} not found.");
            }
        }

        public static void DeleteMenu(int id)
        {
            menu menu = menus.FirstOrDefault(m => m.id == id);
            if (menu != null)
            {
                menus.Remove(menu);
                Console.WriteLine($"Menu with id {id} has been deleted from the library.");
            }
            else
            {
                Console.WriteLine($"Menu with id {id} not found.");
            }

        }
    }
}


