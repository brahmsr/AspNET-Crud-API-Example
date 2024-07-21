using ApiCrud.Data;
using ApiCrud.Models.DTOs;
using ApiCrud.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DatabaseContext dbContext;

        public EmployeesController(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var allEmployees = dbContext.Employees.Include(e => e.Clients).ToList();

                return Ok(allEmployees);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Erro ocorrido ao buscar empregados", error = e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(Guid id) 
        {
            var getOneEmployee = dbContext.Employees.Include(e => e.Clients).FirstOrDefault(e => e.Id == id);

            if (getOneEmployee == null)
            {
                return NotFound(new { message = "Funcionário não encontrado." });
            }

            return Ok(getOneEmployee);
        }

        [HttpPost]
        public IActionResult AddEmployees(AddEmployeeDTO addEmployee)
        {
            try
            {
                var employeeEntity = new Employee()
                {
                    Name = addEmployee.Name,
                    Email = addEmployee.Email,
                    Phone = addEmployee.Phone,
                    Salary = addEmployee.Salary,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                dbContext.Employees.Add(employeeEntity);
                dbContext.SaveChanges();

                return Ok(employeeEntity);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Algo deu errado", error = e.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Guid id, EditEmployeeDTO editEmployee)
        {
            try
            {
                var employee = dbContext.Employees.Find(id);

                if (employee is null)
                {
                    return NotFound();
                }

                employee.Name = editEmployee.Name;
                employee.Email = editEmployee.Email;
                employee.Phone = editEmployee.Phone;
                employee.Salary = editEmployee.Salary;

                dbContext.SaveChanges();
                return Ok(employee);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Algo deu errado.", error = e.Message });
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if(employee is null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
