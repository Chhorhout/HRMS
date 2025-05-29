using Microsoft.AspNetCore.Mvc;
using HRMS.API.Models;
using HRMS.API.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using HRMS.API.Dtos;
namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
        

        public EmployeeController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            var employeesDto = _mapper.Map<List<EmployeeResponseDto>>(employees);
            return Ok(employeesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDto = _mapper.Map<EmployeeResponseDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeCreateDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = _mapper.Map<Employee>(employeeDto);
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            var employeeResponseDto = _mapper.Map<EmployeeResponseDto>(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employeeResponseDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, EmployeeCreateDto employeeDto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _mapper.Map(employeeDto, employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employeeDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok("Employee deleted successfully");
        }
        
        
        
}
}
