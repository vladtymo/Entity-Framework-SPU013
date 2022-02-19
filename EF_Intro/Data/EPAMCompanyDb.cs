using Microsoft.EntityFrameworkCore;
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

            modelBuilder.ApplyConfiguration(new WorkerConfig());

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
}
