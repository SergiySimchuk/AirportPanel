using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Domain
{
    [Table("Gates")]
    public class Gate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TerminalID { get; set; }

        [ForeignKey("TerminalID")]
        public virtual Terminal Terminal { get; set; }
    }
}
