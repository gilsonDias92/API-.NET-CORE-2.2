using API.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(50, ErrorMessage = "Field must have {50} characteres")]
        [Required]
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
