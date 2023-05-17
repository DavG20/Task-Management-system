using System;
using Task.Domain.Common;

namespace Task.Domain
{ 
    public class Task : BaseEntity
    {
        
        public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
