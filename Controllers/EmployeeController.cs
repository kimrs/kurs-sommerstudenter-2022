using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace kurs_sommerstudenter_2022.Controllers
{
    public class Employee 
    {
        public string Name {get; set;}
        public int Age {get; set;}
    }

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>()
        {
            new Employee
            {
                Name = "Ole-Magnus Vian Norum",
                Age = 22
            },

            new Employee
            {
                Name = "Marius Jensen",
                Age = 26
            }
        };

        [HttpGet]
        public List<Employee> ReadEmployee()
        {
            return _employees;
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            if (!_employees.Any(x => x.Name == employee.Name)) {
                _employees.Add(employee);
                return Created();
            }
            return Ok();
        }
    }

}
