namespace ApiCrud.Models.DTOs
{
    public class EditClientDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
