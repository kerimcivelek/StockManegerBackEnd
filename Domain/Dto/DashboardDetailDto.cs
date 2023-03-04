using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DashboardDetailDto : DashboardTotalDto
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
    }
}
