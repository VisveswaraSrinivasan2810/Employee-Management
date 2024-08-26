using AutoMapper;
using EmpManagement.Data.DTO;
using EmpManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Data.Automapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee,CreateEmp>().ReverseMap();   
            CreateMap<Employee,UpdateEmp>().ReverseMap();
            CreateMap<Department,CreateDep>().ReverseMap(); 
            CreateMap<Department,UpdateDep>().ReverseMap();
        }
    }
}
