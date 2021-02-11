using System.Linq;
using BaladaIntergalactica.API.Entities;
using BaladaIntergalactica.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BaladaIntergalactica.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AlienController : ControllerBase
    {

        private readonly IntergalacticBalladDbContext _context;

        public AlienController(IntergalacticBalladDbContext context)
        {
            _context = context;
        }
       


        [HttpGet]
        public IActionResult Get()
        {
            var aliens = _context.Aliens;
            return Ok(aliens);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAlien(int id)
        {
            return Ok(_context.Aliens.First(x => x.Id == id));
            //return BadRequest();
        }

        [HttpPost]
        public IActionResult PostAlien([FromBody] Alien alien)
        {
                _context.Aliens.Add(alien);
                _context.SaveChanges();
                return Ok();
        }

    }
}
