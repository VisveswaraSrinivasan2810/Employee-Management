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
    public class DepController : ControllerBase
    {
        private readonly IDepService _depService;
        private readonly IMapper _mapper;

        public DepController(IDepService depService,IMapper mapper)
        {
            _depService = depService;
            _mapper = mapper;   
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            var departments = await _depService.GetAllDepartmentAsync();
            if(departments == null)
            {
                return NotFound();  
            }
            return Ok(departments);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Department>> Get(int id)
        {
            var department = await _depService.GetDepartmentAsync(id);
            if(department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]CreateDep department)
        {
            if(department == null)
            {
                return BadRequest("Department Cannot be null");
            }
            //var dep = new Department()
            //{
            //    Name = department.Name
            //};
            var dep = _mapper.Map<Department>(department);
            await _depService.CreateDepartmentAsync(dep);
            return CreatedAtAction("Get", new { id = dep.DepId }, dep);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public async Task<IActionResult> Update(int id , [FromBody] UpdateDep department)
        {
            if(id != department.DepId || department == null)
            {
                return BadRequest();
            }
            var dep = _mapper.Map<Department>(department);
            await _depService.UpdateDepartmentAsync(dep);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
           var dep = await _depService.GetDepartmentAsync(id);
           if(dep == null )
            {
                return NotFound("Department not Fount");
            }
           await _depService.DeleteDepartmentAsync(dep);
            return NoContent(); 
        }
        
    }
}
