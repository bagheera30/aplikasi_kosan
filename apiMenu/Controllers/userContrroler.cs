using menu_pembelian;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userContrroler : ControllerBase
    {
        private const string filePath = "users.json";
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<users>> Get()
        {
            return usermanegement.GetUsers();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{nama}")]
        public ActionResult<users> Get(string nama)
        {
            users u = usermanegement.getUsersbynama(nama);
            if (u != null)
            {
                return u;
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] users value)
        {
            usermanegement.addusers(value);
            usermanegement.Serialize();
            return CreatedAtAction(nameof(Get), null);
        }

        
    }
}
