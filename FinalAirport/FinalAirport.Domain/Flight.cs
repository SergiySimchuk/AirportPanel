using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Domain
{
    [Table("Flights")]
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string FlightNumber { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public int DepartureAirportID { get; set; }
        public int ArrivalAirportID { get; set; }
        [ForeignKey("DepartureAirportID")]
        public virtual Airport DepartureAirport { get; set; }
        [ForeignKey("ArrivalAirportID")]
        public virtual Airport ArrivalAirport { get; set; }
        public int DepartureTerminalID { get; set; }
        public int ArrivalTerminalID { get; set; }
        [ForeignKey("DepartureTerminalID")]
        public virtual Terminal DepartureTerminal { get; set; }
        [ForeignKey("ArrivalTerminalID")]
        public virtual Terminal ArrivalTerminal { get; set; }
        public int DepartureGateID { get; set; }
        public int ArrivalGateID { get; set; }
        [ForeignKey("DepartureGateID")]
        public virtual Gate DepartureGate { get; set; }
        [ForeignKey("ArrivalGateID")]
        public virtual Gate ArrivalGate { get; set; }
    }
}
