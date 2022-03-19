using System.Collections.Generic;

namespace EF_Intro
{
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
}
