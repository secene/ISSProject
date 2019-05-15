using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IISProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Last modified date")]
        [DataType(DataType.DateTime)]
        public DateTime ModificationData { get; set; }

        [Required]
        [Range(1,1000)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Display(Name = "The quantity you want")]
        public int WantedQuantity { get; set; }
    }
}
