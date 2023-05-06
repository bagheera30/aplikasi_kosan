using menu_pembelian;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class menuController : ControllerBase
    {
        public static string filePath = "daftar_menu.json";

        // GET: api/<menuController>
        [HttpGet]
        public ActionResult<List<menu>> Get()
        {
            try
            {
                MenuManager.bacaFile(filePath);
                List<menu> menus = MenuManager.GetMenus();
                return Ok(menus);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<menuController>/5
        [HttpGet("{id}")]
        public ActionResult<menu> Get(int id)
        {
            try
            {
                MenuManager.bacaFile(filePath);
                menu menus = MenuManager.GetMenus().FirstOrDefault(m => m.id == id);
                if (menus != null)
                {
                    return Ok(menus);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<menuController>
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            try
            {
                menu menus = JsonSerializer.Deserialize<menu>(value);
                MenuManager.addmenu(menus);
                MenuManager.saveJson(filePath);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<menuController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            try
            {
                MenuManager.bacaFile(filePath);
                menu menus = MenuManager.GetMenus().FirstOrDefault(m => m.id == id);
                if (menus != null)
                {
                    menu updatedMenu = JsonSerializer.Deserialize<menu>(value);
                    menus.nama = updatedMenu.nama;
                    menus.harga = updatedMenu.harga;
                    menus.foto = updatedMenu.foto;
                    MenuManager.saveJson(filePath);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<menuController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                MenuManager.bacaFile(filePath);
                menu menus = MenuManager.GetMenus().FirstOrDefault(m => m.id == id);
                if (menus != null)
                {
                    MenuManager.removeMenu(menus);
                    MenuManager.saveJson(filePath);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
