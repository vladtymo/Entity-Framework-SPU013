using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=EPUM_Db;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }

        // Collections (tables in db)
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Department> Departments { get; set; }
    }

    public class Department
    {
        [Key]   // set primary key
        public int Number { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }

    // Entities
    public class Worker
    {
        // Properties (columns in db)

        // Primary Key: Id/ID/id EntityName+Id (WorkerId)
        public int Id { get; set; }
        [Required]          // set not null
        [MaxLength(200)]    // set max length (NVarChar(200))
        public string Name { get; set; }
        [Required, MaxLength(200)]
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public decimal Salary { get; set; }

        // Navigation Properties
        [Required]
        public Department Department { get; set; }
    }
}
