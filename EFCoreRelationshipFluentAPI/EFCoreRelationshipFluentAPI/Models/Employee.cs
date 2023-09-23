using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelationshipFluentAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public decimal Salary { get; set; }
        public DateTime JoinedDate { get; set; }

        public int DepId { get; set; }

        [ForeignKey("DepId")]
        public Department? Department { get; set; }

        public EmployeeProfile? Profile { get; set; }

        public List<Skill> Skills { get; set; } = new();
    }
}
