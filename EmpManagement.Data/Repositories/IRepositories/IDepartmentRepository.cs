using EmpManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Data.Repositories.IRepositories
{
    public interface IDepartmentRepository
    {
        Task CreateDepartment(Department department);
        Task DeleteDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task<Department> GetDepartmentById(int id);
        Task<IEnumerable<Department>> GetAll();
        Task Save();
    }
}
