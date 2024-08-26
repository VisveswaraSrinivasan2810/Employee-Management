using EmpManagement.Data.Models;
using EmpManagement.Data.Repositories;
using EmpManagement.Data.Repositories.IRepositories;
using EmpManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Services.Services
{
    public class DepService : IDepService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task CreateDepartmentAsync(Department department)
        {
           await _departmentRepository.CreateDepartment(department);
        }

        public async Task DeleteDepartmentAsync(Department department)
        {
           await _departmentRepository.DeleteDepartment(department);
        }

        public Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
            return _departmentRepository.GetAll();
        }

        public Task<Department> GetDepartmentAsync(int id)
        {
            return _departmentRepository.GetDepartmentById(id);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            await _departmentRepository.UpdateDepartment(department);
        }
    }
}
