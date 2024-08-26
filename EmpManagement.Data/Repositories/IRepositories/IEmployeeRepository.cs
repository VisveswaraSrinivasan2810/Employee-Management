using EmpManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Data.Repositories.IRepositories
{
    public interface IEmployeeRepository
    {
        Task CreateEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int id);
        Task<IEnumerable<Employee>> GetAll();
        Task Save();
    }
}
