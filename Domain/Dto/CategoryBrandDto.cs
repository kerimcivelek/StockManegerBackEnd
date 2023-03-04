using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class CategoryBrandDto
    {
        public int id { get; set; }
        public int CategoryType { get; set; }
        public string CategoryTypeName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public bool Status { get; set; }

    }
}
