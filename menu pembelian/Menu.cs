using System.Text.Json;
using System.Text.Json.Serialization;

namespace menu_pembelian
{
    public class menu
    {
        public int id { get; set; }
        public string nama { get; set; }
        public int harga { get; set; }
        public string foto { get; set; }

    }
    public static class MenuManager
    {
        private static List<menu> menus;
        static MenuManager()
        {
            menus = new List<menu>();
        }
        public static void addmenu(menu m)
        {
            menus.Add(m);
        }
        public static void removemenu(menu m)
        {
            menus.Remove(m);
        }
        public static void removeMenu(menu m)
        {
            menus.Remove(m);
        }
        public static void saveJson(string f)
        {
            string json = JsonSerializer.Serialize(f);
            File.WriteAllText(f, json);
        }
        public static void bacaFile(string f)
        {
            if (!File.Exists(f))
            {
                throw new FileNotFoundException("file tidak ditemukan untuk nama file: ", f);
            }
            try
            {
                string json = File.ReadAllText(f);
                menus = JsonSerializer.Deserialize<List<menu>>(json);
            } catch (Exception e)
            {
                throw new Exception("json tidak sesuai format");
            }
        }
        public static List<menu> GetMenus()
        {
            return menus;
        }

    }
}