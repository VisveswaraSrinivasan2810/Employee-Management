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
    public class EmpService : IEmpService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmpService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.CreateEmployee(employee);
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            await _employeeRepository.DeleteEmployee(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            return await _employeeRepository.GetAll();
        }

        public Task<Employee> GetEmployeeAsync(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateEmployee(employee); 
        }
    }
}
