using AutoMapper;
using EmpManagement.Data.DTO;
using EmpManagement.Data.Models;
using EmpManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpManagement.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EmpController : ControllerBase
    {
        private readonly IEmpService _empService;
        private readonly IMapper _mapper;
        private readonly IDepService depService;

        public EmpController(IEmpService empService,IMapper mapper,IDepService depService)
        {
            _empService = empService;
            _mapper = mapper;
            this.depService = depService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var employees = await _empService.GetAllEmployeeAsync();
            if(employees==null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var emp = await _empService.GetEmployeeAsync(id);
            if(emp==null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateEmp employee)
            {
            if(employee==null)
            {
                return BadRequest("Employee Cannot be Null");
            }
            var dept = await depService.GetDepartmentAsync(employee.DeptId);
            if (dept == null)
            {
                return BadRequest("Department Not Found");
            }
            var emp = _mapper.Map<Employee>(employee);
            emp.Department = dept;
            await _empService.CreateEmployeeAsync(emp);
            return CreatedAtAction("Get",new {id = emp.EmpId},emp);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmp employee)
        {
            if(employee == null || employee.EmpId !=id)
            {
                return BadRequest();
            }
            var dept = await depService.GetDepartmentAsync(employee.DeptId);
            if(dept == null)
            {
                return NotFound("Department Not Found");
            }
           var emp=_mapper.Map<Employee>(employee);
           emp.Department = dept;
           await _empService.UpdateEmployeeAsync(emp);
           return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _empService.GetEmployeeAsync(id);
            if(emp ==null)
            {
                return NotFound();
            }
            await _empService.DeleteEmployeeAsync(emp);
            return NoContent();
        }
    }
    //Employee Controller//
}
