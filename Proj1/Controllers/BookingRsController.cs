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
    public class BookingRsController : ControllerBase
    {
        private readonly PjContext _context;

        public BookingRsController(PjContext context)
        {
            _context = context;
        }

        // GET: api/BookingRs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingR>>> GetbookingRs()
        {
            return await _context.bookingRs.ToListAsync();
        }
        /*
         *         [HttpPut("{id}/{SongId}/")]
        public async Task<IActionResult> PutFavoriteSong(int id, int SongId)
        {
            var person = await _context.People.FindAsync(id);
            var song = await _context.Songs.FindAsync(SongId);
            if (song == null)
            {
                return NotFound();
            }
            if (person == null)
            {
                return NotFound();
            }
            person.FavoriteSong = song;
            await _context.SaveChangesAsync();

            return Ok(person);
        }
         */
        // GET: api/BookingRs/5
        [HttpGet("{passengerId}/{flightId}")]
        public async Task<ActionResult<BookingR>> GetBookingR(int passengerId, int flightId)
        {
            var bookingR = await _context.bookingRs
            .Include(p => p.passengerR)
            .Include(p => p.flightR)
            .FirstAsync(p => p.passengerR.Id == passengerId && p.flightR.Id == flightId);

            if (bookingR == null)
            {
                return NotFound();
            }

            return bookingR;
        }

        /*
        // GET: api/BookingRs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingR>> GetBookingToFlight(int id)
        {
            FlightR flightt = await _context.flightRs.Include(x => x.bookings).Where(x => x.Id == id).FirstAsync();
            var bookingR = await _context.bookingRs
            .Include(p => p.passengerR)
            .Include(p => p.flightR)
            .FirstAsync(p => p.passengerR.Id == passengerId && p.flightR.Id == flightId);

            if (bookingR == null)
            {
                return NotFound();
            }

            return bookingR;
        }*/
        // GET: api/BookingRs/{id}
        [HttpGet("{id}/BookingRs")]
        public async Task<ActionResult<IEnumerable<BookingR>>> GetPassengerToBookings(int id)
        {
            var bookings = await _context.bookingRs.Where(x => x.passengerRId == id).ToListAsync();
            Console.WriteLine("here\nhere\nhere\n");
            bookings.ToList().ForEach(x => Console.WriteLine($"flightid:{x.flightRId}\tpassengerid:{x.passengerRId}"));

            //var passengerR = await _context.passengerRs.FindAsync(id);

            if (bookings == null)
            {
                return NotFound();
            }
            //passengerR.bookings.ToList().ForEach(booking => Console.WriteLine($"{booking.flightR.Id} {booking.passengerR.Id}"));*/

            return bookings;
        }
        /*
        [HttpGet("{id}/BookingRs")]
        public async Task<ActionResult<IEnumerable<BookingR>>> GetFlightToBookings(int id)
        {
            var bookings = await _context.bookingRs.Where(x => x.passengerRId == id).ToListAsync();
            Console.WriteLine("here\nhere\nhere\n");
            bookings.ToList().ForEach(x => Console.WriteLine($"flightid:{x.flightRId}\tpassengerid:{x.passengerRId}"));

            //var passengerR = await _context.passengerRs.FindAsync(id);

            if (bookings == null)
            {
                return NotFound();
            }
            //passengerR.bookings.ToList().ForEach(booking => Console.WriteLine($"{booking.flightR.Id} {booking.passengerR.Id}"));

            return bookings;
        }
    */
        // GET: api/BookingRs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingR>> GetBookingR(int id)
        {
            BookingR bookingR = await _context.bookingRs.FindAsync(id);

            if (bookingR == null)
            {
                return NotFound();
            }

            return bookingR;
        }

        // PUT: api/BookingRs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingR(int id, BookingR bookingR)
        {
            if (id != bookingR.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookingR).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingRExists(id))
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

        // POST: api/BookingRs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingR>> PostBookingR(BookingR bookingR)
        {
            //Console.WriteLine{ }
            _context.bookingRs.Add(bookingR);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingR", new { id = bookingR.Id }, bookingR);
        }

        [HttpPost("PassengerR/{passengerId}/FlightR/{flightId}")]
        public async Task<ActionResult<BookingR>> PostBookingR(int passengerId,int flightId)
        {
            FlightR flightt = await _context.flightRs.Include(x=> x.bookings).Where(x=>x.Id==flightId).FirstAsync();
            PassengerR PassengerR = await _context.passengerRs.FindAsync(passengerId);
            BookingR bookingR = new BookingR 
            { 
                passengerR = PassengerR,
                flightR = flightt
            };            
            _context.bookingRs.Add(bookingR);
            await _context.SaveChangesAsync();
            return CreatedAtAction("PostBookingR", new { id = bookingR.Id }, bookingR);
        }

        [HttpPost("{bookingId}/{passengerId}/{flightId}")]
        public async Task<ActionResult<BookingR>> PostBookingR(int bookingId, int passengerId, int flightId)
        {
            FlightR flightt = await _context.flightRs.FindAsync(flightId);
            PassengerR passengert = await _context.passengerRs.FindAsync(passengerId);
            BookingR bookingR = new BookingR
            {
                Id = bookingId,
                passengerR = passengert,
                flightR = flightt
            };
            _context.bookingRs.Add(bookingR);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBookingR", new { id = bookingR.Id }, bookingR);
        }


        // DELETE: api/BookingRs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingR(int id)
        {
            var bookingR = await _context.bookingRs.FindAsync(id);
            if (bookingR == null)
            {
                return NotFound();
            }

            _context.bookingRs.Remove(bookingR);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingRExists(int id)
        {
            return _context.bookingRs.Any(e => e.Id == id);
        }

        private BookingDTO BookingToDTO(PjContext pj , BookingR booking)
        {
            BookingDTO bookingDTO = new BookingDTO
            {
                Id = booking.Id,
                passengerRId = booking.passengerRId,
                flightRId = booking.flightRId
            };
            return bookingDTO;
        }
    }
}
