using System.ComponentModel.DataAnnotations;

namespace Employeement.Api.Models
{
    public class Employee
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Phone { get; set; }
    }
}
