using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proj1.with_relation.models
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int passengerRId { get; set; }
        public int flightRId { get; set; }
    }
}