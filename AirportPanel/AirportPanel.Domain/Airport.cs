using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportPanel.Domain
{
    [Table("Airports")]
    public class Airport
    {
        [Key]
        public int ID { get; set; }

        [Required] 
        public string Name { get; set; }
        [Required]
        public string City { get; set;  }
        [Required]
        public string Country { get; set; }
        public virtual ICollection<Terminal> Terminals { get; set; }
    }
}
