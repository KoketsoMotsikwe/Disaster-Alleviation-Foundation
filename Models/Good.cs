using System;
using System.Collections.Generic;

namespace DAF_Project.Models
{
    public partial class Good
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfItems { get; set; }
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Donor { get; set; }
    }
}
