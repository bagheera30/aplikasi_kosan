using menu_pembelian;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class menuController : ControllerBase
    {
        private const string filePath = "daftar_menu.json";

        // GET: api/Menu
        [HttpGet]
        public ActionResult<List<menu>> Get()
        {
            return MenuManager.GetMenus();
        }
        [HttpGet("{id}")]
        public ActionResult<menu> GetMenuById(int id)
        {
            menu m = MenuManager.getmenusbyID(id);
            if (m != null)
            {
                return m;
            }
            else
            {
                return NotFound();
            }
        }
        // POST: api/Menu
        [HttpPost]
        public ActionResult Post([FromBody] menu menu)
        {
            MenuManager.addmenu(menu);
            MenuManager.Serialize();

            return CreatedAtAction(nameof(Get), null);
        }

        // PUT: api/Menu
        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] menu menu)
        {
            MenuManager.UpdateMenu(id, menu);
            MenuManager.Serialize();

            return NoContent();
        }

        // DELETE: api/Menu
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            MenuManager.DeleteMenu(id);
            MenuManager.Serialize();

            return NoContent();
        }

        
    }
}
