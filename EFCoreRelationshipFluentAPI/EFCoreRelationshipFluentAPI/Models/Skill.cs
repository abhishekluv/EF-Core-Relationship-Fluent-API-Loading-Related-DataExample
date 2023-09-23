namespace EFCoreRelationshipFluentAPI.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        //navigation property
        public List<Employee> Employees { get; set; } = new();
    }
}
