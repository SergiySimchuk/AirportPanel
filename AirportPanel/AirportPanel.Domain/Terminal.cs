using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel.Domain
{
    [Table("Terminals")]
    public class Terminal
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int AirportID { get; set; }
        
        [Required]
        [ForeignKey("AirportID")]
        public virtual Airport Airport { get; set; }
        public virtual ICollection<Gate> Gates { get; set; }
    }
}
