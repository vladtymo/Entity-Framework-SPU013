using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            EPAMCompanyDb db = new EPAMCompanyDb();

            //var worker1 = new Worker()
            //{
            //    Name = "Olga",
            //    Surname = "Bereza",
            //    Salary = 1300,
            //    Birthdate = new DateTime(1994, 3, 2),
            //    Address = "Rivne, Soborna 5a",
            //    Department = db.Departments.Find(1),
            //    Country = db.Countries.Find(2)
            //};
            //worker1.Projects.Add(db.Projects.Find(1));

            //db.Workers.Add(worker1);
            //db.SaveChanges();

            var result = db.Workers.Include(w => w.Country)
                                   .Include(w => w.Department)
                                   .Include(w => w.Projects)
                                   .Where(w => w.Salary > 1000);

            foreach (var w in result)
            {
                Console.WriteLine($"Worker {w.Name} {w.Surname} has salary of {w.Salary}$\n" +
                                $"Country: {w.Country?.Name}\n" +
                                $"Address: {w.Address ?? "no address"}\n" +
                                $"Department: {w.Department.Name}\n" +
                                $"Birthdate: {w.Birthdate}\n" +
                                $"Projects: {w.Projects.Count}");
            }

            foreach (var item in db.Departments)
            {
                Console.WriteLine($"Department #{item.Number} {item.Name} {item.Phone}");
            }
        }
    }
}
