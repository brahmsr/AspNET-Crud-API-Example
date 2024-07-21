using ApiCrudClientes.Models.Entities;

namespace ApiCrud.Models.Entities
{
    public class Employee
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary{ get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Client> Clients { get; set; } = new List<Client>();
    }
}
