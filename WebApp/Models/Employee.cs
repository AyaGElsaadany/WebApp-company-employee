using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [ForeignKey("company")]
        public int Company_ID { get; set; }
        public virtual Company company { get; set; }
    }
}
