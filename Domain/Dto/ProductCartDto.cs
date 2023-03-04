using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class ProductCartDto
    {
        public int Id { get; set; }
        public int CategoryType { get; set; }
        public string CategoryTypeName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ProductDescription { get; set; }
        public string? Ram { get; set; }
        public string? Capacity { get; set; }
        public string? Color { get; set; }
        public string? Note { get; set; }
        public int? MinStock { get; set; }
        public int? MaxStock { get; set; }
    }
}
