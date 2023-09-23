namespace EFCoreRelationshipFluentAPI.Models
{
    public class EmployeeProfile
    {
        public int Id { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        //EmployeeId as FK
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
