using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class GroupBySumProductDto
    {
        public int Id { get; set; }
        public int CategoryTypeId { get; set; }
        public string? CategoryType { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductDescription { get; set; }
        public string? InOut { get; set; }
        public string? Capacity { get; set; }
        public string? Ram { get; set; }
        public int? MinStock { get; set; }
        public int? MaxStock { get; set; }
        public string? Colour { get; set; }
        public int? Quantity { get; set; }
        public float? Price { get; set; }
        public float? TotalPrice { get; set; }
        public int? TotalInStock { get; set; }
        public int? TotalOutStock { get; set; }

        private int? totalstock;

        public int? TotalStock
        {
            get { return TotalInStock - TotalOutStock; }
            set { totalstock =value; }
        }


    }
}
