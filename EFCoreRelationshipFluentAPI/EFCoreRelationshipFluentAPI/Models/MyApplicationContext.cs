using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipFluentAPI.Models
{
    public class MyApplicationContext : DbContext
    {
        public MyApplicationContext(DbContextOptions<MyApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to many relationship
            modelBuilder.Entity<Employee>()
                        .HasOne(x => x.Department)
                        .WithMany(x => x.Employees)
                        .HasForeignKey(x => x.DepId)
                        .IsRequired();

            //one to one relationship
            //by default DeleteBehavior is Cascade delete.
            //Uncomment the OnDelete() if cascade delete is not required
            modelBuilder.Entity<Employee>()
                        .HasOne(x => x.Profile)
                        .WithOne(x => x.Employee)
                        .HasForeignKey<EmployeeProfile>(x => x.EmployeeId)
                        .IsRequired();
                        //.OnDelete(DeleteBehavior.Restrict); 

            //many to many relationship
            modelBuilder.Entity<Employee>()
                        .HasMany(x => x.Skills)
                        .WithMany(x => x.Employees)
                        .UsingEntity("EmployeeSkills");


            base.OnModelCreating(modelBuilder);
        }
    }
}
