using System;
using System.Collections.Generic;

namespace DAF_Project.Models
{
    public partial class Disaster
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Type { get; set; } = null!;
    }
}
