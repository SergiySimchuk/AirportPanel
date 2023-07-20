using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Domain
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public int PassengerId { get; set; }

        [ForeignKey("PassengerId")]
        public virtual Passenger Passenger { get; set; }

        public int FlightId { get; set; }
        
        [ForeignKey("FlightId")]
        public virtual Flight Flight { get; set; }

        public int PriceClassId { get; set; }

        [ForeignKey("PriceClassId")]
        public virtual PriceClass PriceClass { get; set; }

        public decimal Price { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
    }
}
