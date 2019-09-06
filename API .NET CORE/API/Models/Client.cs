using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Campo comporta apenas {0} caracteres")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "Campo comporta apenas {0} caracteres")]
        public string Email { get; set; }

        public bool Active { get; set; }
        public Client()
        {
        }
    }
}
