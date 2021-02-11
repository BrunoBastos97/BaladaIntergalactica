using BaladaIntergalactica.API.Entities;
using BaladaIntergalactica.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BaladaIntergalactica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjectNotAllowedController: ControllerBase
    {
        private readonly IntergalacticBalladDbContext _context;

        public ObjectNotAllowedController(IntergalacticBalladDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var objetoProibido = _context.ObjectNotAllowed;
            return Ok(objetoProibido);

        }

        [HttpPost]
        public IActionResult PostHasObjectNotAllowed([FromBody] ObjectNotAllowed objectNotAllowed)
        {
            _context.ObjectNotAllowed.Add(objectNotAllowed);
            _context.SaveChanges();
            return Ok();

        }
    }
}
