using EmpManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Services.Interfaces
{
    public interface IEmpService
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync();   
        Task<Employee> GetEmployeeAsync(int id);
        Task CreateEmployeeAsync(Employee employee);    
        Task DeleteEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
    }
}
