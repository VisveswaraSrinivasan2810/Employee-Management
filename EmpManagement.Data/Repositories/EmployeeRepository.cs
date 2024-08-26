using EmpManagement.Data.DataContext;
using EmpManagement.Data.Models;
using EmpManagement.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpDbAuth _dbContext;

        //private readonly EmpDbContext _dbContext;


        public EmployeeRepository(EmpDbAuth dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateEmployee(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await Save();
        }

        public async Task DeleteEmployee(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
             await Save();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await  _dbContext.Employees.FirstOrDefaultAsync(x=>x.EmpId == id);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();    
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            await Save();
        }
    }
}
