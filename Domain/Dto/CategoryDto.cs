using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class CategoryDto
    {
        public int id { get; set; }
        public int CategoryTyp { get; set; }
        public string CategoryTypeName { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
