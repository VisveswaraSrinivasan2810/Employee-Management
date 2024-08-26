using EmpManagement.Data.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Data.DTO
{
    public class CreateEmp
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DeptId { get; set; } 
    }
}
