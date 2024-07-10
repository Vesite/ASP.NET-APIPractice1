using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be more than 10 characters")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(120, ErrorMessage = "CompanyName cannot be more than 120 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 500000000000000)]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(120, ErrorMessage = "Industry cannot be more than 120 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1, 500000000000000)]
        public long MarketCap { get; set; }
    }
}