using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proj1.with_relation.models
{
    [Index(nameof(passengerRId), nameof(flightRId), IsUnique = true)]
    public class BookingR
    {
        public int Id { get; set; }
       // [Index("IX_UniqueComposite", IsUnique = true, Order = 1)]
        public PassengerR? passengerR { get; set; }
       // [Index("IX_UniqueComposite", IsUnique = true, Order = 2)]
        public FlightR? flightR { get; set; }
        [ForeignKey("PassengerR")]
        public int passengerRId { get; set; }
        [ForeignKey("FlightR")]
        public int flightRId { get; set; }
    }
}
