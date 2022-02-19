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

            // FluentAPI configurations
            modelBuilder.Entity<Worker>().ToTable("Employees");          // set table name in db
            modelBuilder.Entity<Worker>().Property(w => w.Name)
                                            .IsRequired()                // set not null
                                            .HasMaxLength(200)           // set max length(NVarChar(200))
                                            .HasColumnName("FirstName"); // set column name in db
            modelBuilder.Entity<Worker>().Property(w => w.Surname)
                                            .IsRequired()
                                            .HasMaxLength(200)
                                            .HasColumnName("LastName");
            modelBuilder.Entity<Worker>().Ignore(w => w.FullName);       // only in model
            modelBuilder.Entity<Worker>().Property(w => w.Address).HasMaxLength(350);

            modelBuilder.Entity<Project>().Property(p => p.Title)
                                            .IsRequired()
                                            .HasMaxLength(200);

            modelBuilder.Entity<Department>().HasKey(d => d.Number);     // set primary key
            modelBuilder.Entity<Department>().Property(d => d.Name)
                                           .IsRequired()
                                           .HasMaxLength(100);
            modelBuilder.Entity<Department>().Property(d => d.Phone).HasMaxLength(30);

            modelBuilder.Entity<Country>().Property(c => c.Name)
                                            .IsRequired()
                                            .HasMaxLength(100);

            // Relationship configurations
            // Relationship Type: 1...* (One to Many)
            modelBuilder.Entity<Worker>().HasOne(w => w.Department)
                                         .WithMany(d => d.Workers)
                                         .IsRequired();
            // Relationship Type: 0/1...* (Zero or One to Many)
            modelBuilder.Entity<Worker>().HasOne(w => w.Country)
                                         .WithMany(d => d.Workers)
                                         .IsRequired(false);
            // Relationship Type: *...* (Many to Many)
            modelBuilder.Entity<Worker>().HasMany(w => w.Projects)
                                         .WithMany(p => p.Workers);

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
        public int Number { get; set; }
        public string Name { get; set; }
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
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }

    // Entities
    public class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
        }
        // Properties (columns in db)

        // Primary Key: Id/ID/id EntityName+Id (WorkerId)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + " " + Surname;
        public DateTime? Birthdate { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
        public Country Country { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
