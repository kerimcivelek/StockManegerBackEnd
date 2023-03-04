using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TechnicalService : BaseEntity
    {
        public string CustomerDescrition { get; set; }
        public string  Gsm { get; set; }
        public string? BugDefination{ get; set; }
        public string? DescriptionOfAction { get; set; }
        public int? ActionStatus { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
    }
}
