#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proj1.with_relation.data;
using Proj1.with_relation.models;

namespace Proj1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerRsController : ControllerBase
    {
        private readonly PjContext _context;

        public PassengerRsController(PjContext context)
        {
            _context = context;
        }

        // GET: api/PassengerRs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassengerR>>> GetpassengerRs()
        {
            return await _context.passengerRs.ToListAsync();
        }

        // GET: api/PassengerRs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PassengerR>> GetPassengerR(int id)
        {
            var passengerR = await _context.passengerRs.FindAsync(id);

            if (passengerR == null)
            {
                return NotFound();
            }
            passengerR.bookings.ToList().ForEach(booking => Console.WriteLine($"{booking.flightR.Id} {booking.passengerR.Id}"));

            return passengerR;
        }

        // PUT: api/PassengerRs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassengerR(int id, PassengerR passengerR)
        {
            if (id != passengerR.Id)
            {
                return BadRequest();
            }

            _context.Entry(passengerR).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerRExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PassengerRs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PassengerR>> PostPassengerR(PassengerR passengerR)
        {
            _context.passengerRs.Add(passengerR);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassengerR", new { id = passengerR.Id }, passengerR);
        }




        [HttpPost("{Name}/{Job}/{Email}/{Age}")]
        public async Task<ActionResult<PassengerR>> PostPassengerR(String Name, String Job, String Email, int Age)
        {
            var passengerR = new PassengerR
            {
                Name = Name,
                Job = Job,
                Email = Email,
                Age = Age
            };
            _context.passengerRs.Add(passengerR);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPassengerR", new { id = passengerR.Id }, passengerR);
        }

        // DELETE: api/PassengerRs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassengerR(int id)
        {
            var passengerR = await _context.passengerRs.FindAsync(id);
            if (passengerR == null)
            {
                return NotFound();
            }

            _context.passengerRs.Remove(passengerR);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassengerRExists(int id)
        {
            return _context.passengerRs.Any(e => e.Id == id);
        }
    }
}
