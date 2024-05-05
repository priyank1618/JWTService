using JWTService.Interface;
using JWTService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            var employee = _employeeService.GetEmployees();
            return employee;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            return employee;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public Employee Post([FromBody] Employee employee)
        {
            var employees = _employeeService.UpdateEmployee(employee);
            return employees;
        }

       

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
        }
    }
}
