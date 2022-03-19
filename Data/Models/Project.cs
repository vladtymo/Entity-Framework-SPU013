using System.Collections.Generic;

namespace EF_Intro
{
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
}
