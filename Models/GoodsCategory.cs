using System;
using System.Collections.Generic;

namespace DAF_Project.Models
{
    public partial class GoodsCategory
    {
        public int Id { get; set; }
        public string Category { get; set; } = null!;
        public int Sequence { get; set; }
    }
}
