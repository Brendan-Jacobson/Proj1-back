
namespace Proj1.with_relation.models 
{
    public class PassengerR
    {
        public int Id { get; set; }
        public String? Name { get; set; }

        public String? Job { get; set; }
        public String? Email { get; set; }
        public int? Age { get; set; }
        public ICollection<BookingR> bookings { get; set; } = new List<BookingR>();
        public ICollection<FlightR> flightRs { get; set; } = new List<FlightR>();
        /*[Display(Name = "Song Name")]
        //[StringLength(50)]
        public string Title { get; set; } = String.Empty;

        [Required]
        [Display(Name = "Sound Specialist Esquire The Third")]
        public string Artist { get; set; } = String.Empty;

        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan Length { get; set; }
        public string AlbumTitle { get; set; } = String.Empty;

        public ICollection<PlaylistSong>? Playlists { get; set; }*/
    }
}