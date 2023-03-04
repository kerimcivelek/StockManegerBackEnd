using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Model : BaseEntity
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string ModelName { get; set; }
    }
}
