using Proj1.with_relation.models;

namespace Proj1.DTO
{
    public class PassengerDTO
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Job { get; set; }
        public String? Email { get; set; }
        public int? Age { get; set; }
    }
}