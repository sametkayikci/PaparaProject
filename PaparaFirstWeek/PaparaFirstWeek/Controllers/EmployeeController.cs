using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PaparaFirstWeek.Data;
using PaparaFirstWeek.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaparaFirstWeek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Route("Name")]
        [HttpGet]
        public string GetName()
        {
            return "Return Name";
        }

        [Route("Details")]
        [HttpGet]
        public Employee GetEmployeeDetails()
        {
            return new Employee
            {
                Id = 1,
                Name = "Samet",
                Age = 30,
                City = "İstanbul",
                Gender = "Male",
                Department = "Software"
            };
        }

        [Route("All")]
        [HttpGet]
        public List<Employee> GetAllEmployee()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Department = "HR",
                    Age = 24,
                    City = "New York",
                    Gender = "Male"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Elif",
                    Department = "IT",
                    Age = 23,
                    City = "Istanbul",
                    Gender = "FeMale"
                },
                 new Employee
                {
                    Id = 3,
                    Name = "Tuğba",
                    Department = "Mobil Software",
                    Age = 20,
                    City = "Istanbul",
                    Gender = "FeMale"
                }
            };

        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("AllEmployee")]
        [HttpGet]
        public IActionResult GetEmployee()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 100,
                    Name= "Kamuran",
                    Age = 19,
                    City = "Kilis",
                    Department = "IT",
                    Gender = "Female"
                },
                 new Employee
                {
                    Id = 200,
                    Name= "Samet",
                    Age = 30,
                    City = "Trabzon",
                    Department = "Software",
                    Gender = "Male"
                }
            };
            if (!employees.Any(e => e.Name.Contains("Elif")))
            {
                return BadRequest("Kullanıcı bulunamadı");
            }
            else
            {
                return Ok(employees);
            }
        }

        [Route("{Id}")]
        [HttpGet]
        public ActionResult<Employee> GetEmployeeDetails(int Id)
        {
            if (Id == 0)
            {
                return NotFound("Çalışan bulunamadı!");
            }
            else
            {
                return new Employee
                {
                    Id = 1001,
                    Name = "Anurag",
                    Age = 28,
                    City = "Mumbai",
                    Gender = "Male",
                    Department = "IT"
                };
            }
        }


        [HttpPost]
        public IActionResult AddEmployee(Employee model)
        {
            var employee = new List<Employee>();
            employee.Add(model);
            return Ok(employee);
        }

        [HttpPost("Create")]
        public IActionResult CreateEmployee(Employee employee)
        {
            if (employee == null)
                return BadRequest();

            return CreatedAtAction(nameof(CreateEmployee), employee);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var employees = new EmployeeData().GetAllEmployee();

            var employe = employees.FirstOrDefault(x => x.Id == id);

            if (employe == null)
                return NotFound($"{id} nolu müşteri bulunamadı");

            employees.Remove(employe);

            return Ok("Müşteri silindi");
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest("Müşteri Id'leri eşleşmedi");

            var employees = new EmployeeData().GetAllEmployee();

            var update = employees.FirstOrDefault(x => x.Id == id);

            update.Name = employee.Name.ToUpper();
            update.Department = employee.Department.ToLower();
            update.Age = employee.Age;
            update.Gender = employee.Gender;
            update.City = $"{employee.City} Şehri";

            return Ok(update);

        }

        [HttpPost("XMLPost")]
        [Consumes("application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult NewRequestFromBody(Employee employee)
        {
            return Ok();
        }
    }
}
