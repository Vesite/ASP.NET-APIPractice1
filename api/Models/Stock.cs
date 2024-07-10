using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Stocks")]
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18, 2)")]

        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18, 2)")]

        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }

        // One-to-many relationship
        public List<Comment> Comments { get; set; } = new List<Comment>();

        // Many-to-many relationship
        public List<Portfolio> PortFolios { get; set; } = new List<Portfolio>();
    }
}