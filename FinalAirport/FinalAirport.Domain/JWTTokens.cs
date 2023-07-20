using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Domain
{
    [Table("JWTTokens")]
    public class JWTToken
    {
        [Key]
        public int ID { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set;  }
        public DateTime Expiration { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public DateTime Created { get; set; }
        public string IPAdress { get; set; } 
        public int UserID { get; set; }
        
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
