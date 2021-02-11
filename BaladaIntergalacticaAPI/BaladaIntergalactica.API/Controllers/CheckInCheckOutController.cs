using BaladaIntergalactica.API.Entities;
using BaladaIntergalactica.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BaladaIntergalactica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckInCheckOutController : ControllerBase
    {

        private readonly IntergalacticBalladDbContext _context;

        public CheckInCheckOutController(IntergalacticBalladDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var CheckInCheckOuts = _context.CheckInCheckOuts
                .Include(e => e.Alien)
                .Include(e => e.Ballad)
                .Include(e => e.ObjectNotAllowed)
                .OrderBy(e => e.Ballad.Name)
                .ThenBy(e => e.Alien.Name)
                .ToList();

            return Ok(CheckInCheckOuts);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCheckInCheckOut(int id)
        {
            return Ok(_context.CheckInCheckOuts.First(e => e.Id == id));
        }


        [HttpGet]
        [Route("BuscaIdAlien/{idAlien}")]
        public IActionResult GetCheckInCheckOutAlien(int idAlien)
        {
            var search = _context.CheckInCheckOuts
                .Include(e => e.Alien)
                .Where(e => e.IdAlien == idAlien)
                .ToList();

            return Ok(search);
        }

        [HttpGet]
        [Route("AlienSemCheckOut")]
        public IActionResult GetAlienWithoutCheckOut()
        {
            var CheckInCheckOuts = _context.CheckInCheckOuts
                .Include(e => e.Alien)
                .Include(e => e.Ballad)
                .OrderBy(e => e.Ballad.Name)
                .ThenBy(e => e.Alien.Name)
                .ToList();

            return Ok(CheckInCheckOuts);
        }

        [HttpPost]
        public IActionResult PostCheckin([FromBody] CheckInCheckOut checkInCheckOut)
        {
             try
             {
                 var alien = _context.Aliens.SingleOrDefault(e => e.Id == checkInCheckOut.IdAlien);
                 if (alien is null)
                 {
                     return BadRequest("Alien não indentificado");
                 }

                var ballad = _context.Ballads.SingleOrDefault(e => e.Id == checkInCheckOut.IdBallad);
                if (ballad is null)
                {
                    return BadRequest("Balada não indentificado");
                }

                if (checkInCheckOut.IdObjectNotAllowed is not null)
                {
                    var objectNotAllowed = _context.ObjectNotAllowed.SingleOrDefault(e => e.Id == checkInCheckOut.IdObjectNotAllowed);
                    if (objectNotAllowed is null)
                    {
                        return BadRequest("Objeto proibido não indentificado");
                    }
                }

                if (!alien.AgeCheckMinimumAllowed())
                {
                     return BadRequest("Idade minima para entrada não permitida");
                }

                var CheckOut = _context.CheckInCheckOuts.SingleOrDefault(e => e.IdAlien == checkInCheckOut.IdAlien && e.DateTimeExit == null);
                if (CheckOut is not null) 
                {
                    return BadRequest("Alien já está em outra balada");
                }

                 checkInCheckOut.CheckIn();
                 _context.CheckInCheckOuts.Add(checkInCheckOut);
                 _context.SaveChanges();
             }
             catch(Exception e)
             {
                 return BadRequest(e.Message);
             }


            return Ok();

        }

        [HttpPut]
        [Route("Checkout/{id}")]
        public IActionResult PutCheckOut(int id, [FromBody] CheckInCheckOut checkInCheckOut)
        {
            var checkoutDoBanco = _context.CheckInCheckOuts.SingleOrDefault(e => e.Id == checkInCheckOut.Id);
           checkInCheckOut.CheckOut();
           checkoutDoBanco.DateTimeExit = checkInCheckOut.DateTimeExit;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var checkInCheckOutDataBase = _context.CheckInCheckOuts.SingleOrDefault(e => e.Id == id);

            if (checkInCheckOutDataBase == null)
                return NotFound("O Checkin não foi encontrado");

            _context.Remove(checkInCheckOutDataBase);
            _context.SaveChanges();

            return Ok();
        }


    }
    
}
