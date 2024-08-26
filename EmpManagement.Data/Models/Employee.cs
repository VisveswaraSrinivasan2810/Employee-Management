using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmpManagement.Data.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [ForeignKey("Department")]
        public int DepId { get; set; }
        //Navigation Property 
        [JsonIgnore]
        public Department Department { get; set; }
    }
}
