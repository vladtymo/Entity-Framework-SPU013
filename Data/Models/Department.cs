using System.Collections.Generic;

namespace EF_Intro
{
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
}
