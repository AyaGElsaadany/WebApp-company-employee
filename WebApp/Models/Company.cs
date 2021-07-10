using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string Website { get; set; }

        [MaxLength(300)]
        public string Address { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
