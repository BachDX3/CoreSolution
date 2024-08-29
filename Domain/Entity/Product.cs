using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Product")]
    public class Product: BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0.01, 1000.00)]
        public decimal Price { get; set; }
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

    }
}
