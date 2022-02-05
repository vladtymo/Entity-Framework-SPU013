using System;
using System.Linq;

namespace EF_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            EPAMCompanyDb db = new EPAMCompanyDb();

            //db.Departments.Add(new Department()
            //{
            //    Name = "Security Programming",
            //    Phone = "3455-223-44"
            //});
            //db.SaveChanges();

            var result = db.Workers.Where(w => w.Salary > 1000);

            foreach (var item in db.Departments)
            {
                Console.WriteLine($"Department #{item.Number} {item.Name} {item.Phone}");
            }
        }
    }
}
