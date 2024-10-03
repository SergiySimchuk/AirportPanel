using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel.Domain
{
    [Table("PriceList")]
    public class PriceList
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PriceClassID { get; set; }
        
        [ForeignKey("PriceClassID")]
        public virtual PriceClass PriceClass { get; set; }
        public int FlightID { get; set; }

        [ForeignKey("FlightID")]
        public virtual Flight Flight { get; set; }
        public decimal Price { get; set; }
    }
}
