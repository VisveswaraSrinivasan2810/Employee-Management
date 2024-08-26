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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmpDbAuth _dbContext;

        //private readonly EmpDbContext _dbContext;

        public DepartmentRepository(EmpDbAuth dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateDepartment(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
            await Save();
        }

        public async Task DeleteDepartment(Department department)
        {
            _dbContext.Departments.Remove(department);
            await Save();
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public Task<Department> GetDepartmentById(int id)
        {
            return _dbContext.Departments.FirstOrDefaultAsync(x=>x.DepId == id);   
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDepartment(Department department)
        {
            _dbContext.Departments.Update(department);
            await Save();
        }
    }
}
