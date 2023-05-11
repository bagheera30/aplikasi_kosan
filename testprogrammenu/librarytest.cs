using menu_pembelian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testprogrammenu
{
    [TestClass]
    public class librarytest
    {
        private const string testFilePath = "daftar_menu.json";

        [TestMethod]
        public void Serialize_SavesMenuToFile()
        {
            // Arrange
            var menu1 = new menu { id = 1, Nama = "Menu 1", harga = 10 };
            var menu2 = new menu { id = 2, Nama = "Menu 2", harga = 13 };

            // Add menus to the MenuManager
            MenuManager.addmenu(menu1);
            MenuManager.addmenu(menu2);

            // Act
            MenuManager.Serialize();

            // Assert
            Assert.IsTrue(File.Exists(testFilePath));
        }

        [TestMethod]
        public void Deserialize_LoadsMenuFromFile()
        {
            // Arrange
            // Arrange
            MenuManager.ClearMenus();
            MenuManager.Deserialize();

            // Act
            List<menu> loadedMenus = MenuManager.GetMenus();

            // Assert
            Assert.AreEqual(2, loadedMenus.Count, "Unexpected number of menus loaded from the file.");
        }
        [TestMethod]
        public void AddMenu_ShouldAddMenuToList()
        {
            // Arrange
            var menu = new menu { id = 1, Nama = "Menu 1", harga = 10, foto = "menu1.jpg" };

            // Act
            MenuManager.addmenu(menu);
            var menus = MenuManager.GetMenus();

            // Assert
            Assert.IsTrue(menus.Contains(menu));
        }

        [TestMethod]
        public void UpdateMenu_ShouldUpdateExistingMenu()
        {
            // Arrange
            var menu = new menu { id = 1, Nama = "Menu 1", harga = 10, foto = "menu1.jpg" };
            MenuManager.addmenu(menu);

            var updatedMenu = new menu { id = 1, Nama = "Updated Menu 1", harga = 15, foto = "menu1-updated.jpg" };

            // Act
            updatedMenu.harga = 15; // Pastikan nilai harga sudah diperbarui
            MenuManager.UpdateMenu(menu.id, updatedMenu);
            var updated = MenuManager.getmenusbyID(menu.id);

            // Assert
            Assert.AreEqual(updatedMenu.Nama, updated.Nama);
            Assert.AreEqual(updatedMenu.harga, updated.harga);
            Assert.AreEqual(updatedMenu.foto, updated.foto);
        }

        [TestMethod]
        public void DeleteMenu_ShouldRemoveMenuFromList()
        {
            // Arrange
            MenuManager.ClearMenus();
            menu m1 = new menu { id = 1, Nama = "Menu 1", harga = 11 };
            MenuManager.addmenu(m1);

            // Act
            MenuManager.DeleteMenu(1);

            // Assert
            menu deletedMenu = MenuManager.getmenusbyID(1);
            Assert.IsNull(deletedMenu, "Menu with id 1 still exists in the library.");
        }
    }
}
