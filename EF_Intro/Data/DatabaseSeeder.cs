using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Intro
{
    public static class DatabaseSeeder
    {
        public static void SeedDepartments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new[]
            {
                new Department()
                {
                    Number = 1,
                    Name = "Security Programming",
                    Phone = "3455-223-44"
                },
                new Department()
                {
                    Number = 2,
                    Name = "Design",
                    Phone = "45462-223-44"
                },
                new Department()
                {
                    Number = 3,
                    Name = "Admin Department",
                    Phone = "101010-44-44"
                }
            });
        }
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new[]
            {
                new Country()
                {
                    Id = 1,
                    Name = "Ukraine",
                },
                new Country()
                {
                    Id = 2,
                    Name = "Poland",
                },
                new Country()
                {
                    Id = 3,
                    Name = "Italy",
                },
                new Country()
                {
                    Id = 4,
                    Name = "Spain",
                }
            });
        }
        public static void SeedProjects(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(new[]
            {
                new Project()
                {
                    Id = 1,
                    Title = "Eco Project in Rivne",
                    Description = "Helps people to sort the rubbish."
                },
                new Project()
                {
                    Id = 2,
                    Title = "Vets-Pets",
                    Description = "Helps people to find animals."
                }
            });
        }
    }
}
