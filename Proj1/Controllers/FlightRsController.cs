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
    public class FlightRsController : ControllerBase
    {
        private readonly PjContext _context;

        public FlightRsController(PjContext context)
        {
            _context = context;
        }

        // GET: api/FlightRs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightR>>> GetflightRs()
        {
            return await _context.flightRs.ToListAsync();
        }

        // GET: api/FlightRs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightR>> GetFlightR(int id)
        {
            var flightR = await _context.flightRs.FindAsync(id);

            if (flightR == null)
            {
                return NotFound();
            }
            Console.WriteLine("HERE");
            Console.WriteLine(flightR.bookings.ToList().Count());
            flightR.bookings.ToList().ForEach(x => Console.WriteLine($"{x.flightR.Id} {x.passengerR.Id}"));
            return flightR;
        }

        // PUT: api/FlightRs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightR(int id, FlightR flightR)
        {
            if (id != flightR.Id)
            {
                return BadRequest();
            }

            _context.Entry(flightR).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightRExists(id))
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


        [HttpGet("{id}/BookingRs")]
        public async Task<ActionResult<IEnumerable<BookingR>>> GetFlightToBookings(int id)
        {

            var bookings = await _context.bookingRs.Where(x => x.flightRId == id).ToListAsync();
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

        [HttpGet("Airports")]
        public async Task<ActionResult<IEnumerable<string>>> GetAirports()
        {
            //var flights = _context.flightRs.ToListAsync().Select((x)=>x.ArrivalAirport) ;
            var Arrivals = await _context.flightRs.Select((x) => x.ArrivalAirport).ToListAsync();
            var Departures =  _context.flightRs.Select((x) => x.DepartureAirport).ToList();
            //var flights2 = _context.flightRs.ToList().Select((x) => x.ArrivalAirport);
            return Arrivals.Concat(Departures).ToList().Distinct().ToList();

            //return flights;
        }


        // POST: api/FlightRs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightR>> PostFlightR(FlightR flightR)
        {
            _context.flightRs.Add(flightR);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightR", new { id = flightR.Id }, flightR);
        }

        [HttpPost("{departureTime}/{arrivalTime}/{departureDate}/{arrivalDate}/{departureAirport}/{arrivalAirport}/{passengerLimit}")]
        public async Task<ActionResult<FlightR>> PostFlightR(String departureTime, String arrivalTime, DateTime departureDate,DateTime arrivalDate,String departureAirport, String arrivalAirport,int passengerLimit)
        {
            var flightR = new FlightR
            {
                DepartureTime = TimeSpan.Parse(departureTime),
                ArrivalTime = TimeSpan.Parse(arrivalTime),
                DepartureDate = departureDate,
                ArrivalDate = arrivalDate,
                DepartureAirport = departureAirport,
                ArrivalAirport = arrivalAirport,
                PassengerLimit = passengerLimit
            };
            _context.flightRs.Add(flightR);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightR", new { id = flightR.Id }, flightR);
        }

        // DELETE: api/FlightRs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightR(int id)
        {
            var flightR = await _context.flightRs.FindAsync(id);
            if (flightR == null)
            {
                return NotFound();
            }

            _context.flightRs.Remove(flightR);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightRExists(int id)
        {
            return _context.flightRs.Any(e => e.Id == id);
        }
    }
}
