using menu_pembelian;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string filePath = "users.json";
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<users>> Get()
        {
            return usermanegement.GetUsers();
        }
    }

        // GET api/<ValuesController>/5
        [HttpGet("{nama}")]
        public ActionResult<users> Getbynama(string nama)
        {
        users u = usermanegement.getUsersbynama(nama); 
        if(u!= null)
        {
            return u;
        }
        else
        {
            return NotFound($"User with name '{nama}' not found.");
        }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
