using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    // This is for the many-to-many thing
    [Table("Portfolios")]
    public class Portfolio
    {
        public string AppUserId { get; set; }
        public int StockId { get; set; }


        // These are just for us the dev?
        public AppUser AppUser { get; set; }
        public Stock Stock { get; set; }
    }
}