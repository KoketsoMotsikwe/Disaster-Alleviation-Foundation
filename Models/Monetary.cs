using System;
using System.Collections.Generic;

namespace DAF_Project.Models
{
    public partial class Monetary
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string? Donor { get; set; }
    }
}
