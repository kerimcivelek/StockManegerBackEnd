using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DashboardDto
    {
        public int TotalEntryProduct { get; set; }
        public int TotalOutputProduct { get; set; }
        public float TotalEntryPrice { get; set; }
        public float TotalOutPutPrice { get; set; }
    }
}
