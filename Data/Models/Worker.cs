using System;
using System.Collections.Generic;

namespace EF_Intro
{
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
