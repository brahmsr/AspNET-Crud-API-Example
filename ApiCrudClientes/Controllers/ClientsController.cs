using ApiCrud.Data;
using ApiCrud.Models.DTOs;
using ApiCrudClientes.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly DatabaseContext dbContext;
        public ClientsController(DatabaseContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            try
            {
                return Ok(dbContext.Clients.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Algo deu errado.", e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(Guid id)
        {
            try
            {
                var getOneClient = dbContext.Clients.Find(id);

                if (getOneClient == null)
                {
                    return NotFound();
                }

                return Ok(getOneClient);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Algo deu errado", e.Message });
            }
        }

        [HttpPost]
        public IActionResult AddClient(AddClientDTO addClient)
        {
            try
            {
                var clientEntity = new Client()
                {
                    Name = addClient.Name,
                    Phone = addClient.Phone,
                    Email = addClient.Email,
                    EmployeeId = addClient.EmployeeId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                dbContext.Clients.Add(clientEntity);
                dbContext.SaveChanges();
                return Ok(clientEntity);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Algo deu errado. ", e.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditClient(Guid id, EditClientDTO editClient)
        {
            try
            {
                var client = dbContext.Clients.Find(id);
                if (client is null)
                {
                    return NotFound();
                }
                client.Name = editClient.Name;
                client.Phone = editClient.Phone;
                client.Email = editClient.Email;
                client.EmployeeId = editClient.EmployeeId;
                client.UpdatedAt = DateTime.Now;

                dbContext.SaveChanges();
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Algo deu errado", e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(Guid id)
        {
            var client = dbContext.Clients.Find(id);

            if(client is null)
            {
                return NotFound();
            }

            dbContext.Clients.Remove(client);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
