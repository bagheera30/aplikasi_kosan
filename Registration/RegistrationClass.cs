using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    public class RegistrationClass
    {
        public RegistrationClass() { }
        public static bool checkUsername(string username)
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

        public static bool checkPassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            return true;
        }

        public static void createAkun(string name, string username, string password)
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
