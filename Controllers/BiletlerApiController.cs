using Microsoft.AspNetCore.Mvc;
using Proje.Models.siniflar;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiletlerApiController : ControllerBase
    {
        // GET: api/<BiletlerApiController>
        [HttpGet]
        public List<Biletler> Get()
        {
           return _context.biletlers.ToList();
        }

        private  Context _context;

        public BiletlerApiController(Context context, IConfiguration configuration)
        {
            _context = context;
        }

        // GET api/<BiletlerApiController>/5
        [HttpGet("{id}")]
        public List<Biletler> Get(long id)
        {
            var biletlerList = _context.biletlers.Where(x => x.KullaniciTc == id.ToString()).ToList();
            return biletlerList;
        }

        // POST api/<BiletlerApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BiletlerApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BiletlerApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
