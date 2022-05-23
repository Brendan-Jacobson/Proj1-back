using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Proj1.with_relation.models
{
    public class FlightR
    {
        public int Id { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan DepartureTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan ArrivalTime { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DepartureDate { get; set; } = new DateTime();

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime ArrivalDate { get; set; } = new DateTime();
        public String? DepartureAirport { get; set; }
        public String? ArrivalAirport { get; set; }
        public int  PassengerLimit { get; set; }
        public ICollection<BookingR> bookings { get; set; } = new List<BookingR>();
        public ICollection<PassengerR> passengerRs { get; set; } = new List<PassengerR>();

    }
}
