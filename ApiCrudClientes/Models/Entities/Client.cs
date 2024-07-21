using ApiCrud.Models.Entities;

namespace ApiCrudClientes.Models.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Employee? Employee { get; set; }
    }
}
