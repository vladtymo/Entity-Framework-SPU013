using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Intro
{
    public class EPAMCompanyDb : DbContext // NuGet - EntityFrameworkCore (.SqlServer)
    {
        public EPAMCompanyDb()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=EPUM_Db;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // You can find the FluentAPI configurations in FluentAPI branch

            // Seed
            modelBuilder.SeedDepartments();
            modelBuilder.SeedCountries();
            modelBuilder.SeedProjects();
        }

        // Collections (tables in db)
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Project> Projects { get; set; }
    }

    public class Project
    {
        public Project()
        {
            Workers = new HashSet<Worker>();
        }
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }

    public class Department
    {
        public Department()
        {
            Workers = new HashSet<Worker>();
        }
        [Key]   // set primary key
        public int Number { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }
    public class Country
    {
        public Country()
        {
            Workers = new HashSet<Worker>();
        }
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }

    // Entities
    [Table("Employees")] // set table name in db
    public class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
        }
        // Properties (columns in db)

        // Primary Key: Id/ID/id EntityName+Id (WorkerId)
        public int Id { get; set; }
        [Required]            // set not null
        [MaxLength(200)]      // set max length (NVarChar(200))
        [Column("FirstName")] // set column name in db
        public string Name { get; set; }
        [Required, MaxLength(200), Column("LastName")]
        public string Surname { get; set; }
        [NotMapped]           // only in model
        public string FullName => Name + " " + Surname;
        public DateTime? Birthdate { get; set; }
        public decimal Salary { get; set; }
        [MaxLength(350)]
        public string Address { get; set; }

        // Navigation Properties
        // Relationship Type: 1...* (One to Many)
        [Required]
        public Department Department { get; set; }
        // Relationship Type: 0/1...* (Zero or One to Many)
        public Country Country { get; set; }
        // Relationship Type: *...* (Many to Many)
        public ICollection<Project> Projects { get; set; }
    }
}
