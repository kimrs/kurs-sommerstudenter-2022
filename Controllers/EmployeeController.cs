using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace kurs_sommerstudenter_2022.Controllers
{
    public class Employee
    {
        public string Name {get;set;}
        public string Occupation {get;set;}
    }

    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>()
        {
            new Employee { Name = "Stephen Crocker", Occupation = "Developer"},
            new Employee { Name = "Tim Berners-Lee", Occupation = "Project manager"}
        };

        [HttpGet]
        public IEnumerable<Employee> Get() => _employees;

        [HttpGet]
        [Route("{name}")]
        public Employee ReadEmployee(string name) 
            => _employees.FirstOrDefault(x => x.Name == name);

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            if(!_employees.Any(x => x.Name == employee.Name))
            {
                _employees.Add(employee);
                return Created($"employees/{employee.Name}".Replace(" ", "%20"), employee);
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateEmployee(Employee employee)
        {
            var existingEmployee = _employees.FirstOrDefault(x => x.Name == employee.Name);
            if(existingEmployee == null)
            {
                _employees.Add(employee);
                return Created($"employees/{employee.Name}".Replace(" ", "%20"), employee);
            }
            
            _employees.Remove(existingEmployee);
            _employees.Add(employee);
            return Ok();
        }

        [HttpDelete]
        [Route("{name}")]
        public ActionResult DeleteEmployee(string name)
        {
            var affectedRows = _employees.RemoveAll(x => x.Name == name);
            return affectedRows == 0
                ? Ok("Employee was not removed")
                : Ok($"{name} was removed");
        }
    }
}
