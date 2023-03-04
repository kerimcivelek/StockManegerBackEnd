using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product :BaseEntity
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public string? Ram { get; set; }
        public string? Capacity { get; set; }
        public string? Colour { get; set; }
        public int? Min { get; set; } = 0;
        public int? Max { get; set; } = 0;
        public string? Note { get; set; }

    }
}
