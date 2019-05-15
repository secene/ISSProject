using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IISProject.Models
{
    public class Order
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total price")]
        public decimal Price { get; set; }

        [Display(Name = "Order date")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
    }
}
