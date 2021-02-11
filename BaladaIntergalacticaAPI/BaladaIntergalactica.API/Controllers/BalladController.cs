using BaladaIntergalactica.API.Persistence;
using BaladaIntergalactica.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BaladaIntergalactica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalladController : ControllerBase
    {
        private readonly IntergalacticBalladDbContext _context;

        public BalladController(IntergalacticBalladDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ballads = _context.Ballads;
            return Ok(ballads);
        }

        [HttpPost]
        public IActionResult PostBallad([FromBody] Ballad ballad)
        {
            _context.Ballads.Add(ballad);
            _context.SaveChanges();
            return Ok();
        }


    }
}
