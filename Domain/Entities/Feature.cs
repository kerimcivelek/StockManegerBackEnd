using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Feature :BaseEntity
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
    }
}
