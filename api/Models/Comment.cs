using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        // This is the convention syntax / variable name
        // Used in dotnet Core searching tools
        // This is the key ()
        public int? StockId { get; set; } 

         // This is called "Navigation Property"
         // (So we can type Stock.CompanyName)
        public Stock? Stock { get; set; }

    }
}