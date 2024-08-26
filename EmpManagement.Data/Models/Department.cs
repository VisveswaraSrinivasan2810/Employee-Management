using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmpManagement.Data.Models
{
    public class Department
    {
       [Key]
       public int DepId { get; set; }
       [Required]
       [MaxLength(100)]
       public string Name { get; set; }
        //Navigation Property 
        [JsonIgnore]
       public IEnumerable<Employee> Employees { get; set; } //One to Many Relationship
    }
}
