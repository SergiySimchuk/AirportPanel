using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportPanel.Domain
{
    [Table("FlightStatuses")]
    public class FlightStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int SecondsTo { get; set; }
        public bool Arrival { get; set; }
    }
}
