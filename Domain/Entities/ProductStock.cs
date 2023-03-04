using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductStock : BaseEntity
    {
        public int ProductId { get; set; }
        public string? CustomerDescrition { get; set; }
        public int InOut { get; set; }
        public int? EntryId { get; set; }
        public bool UsedDivace { get; set; }
        public string? Tckn { get; set; }
        public string? IMEI { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string? Descrition { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }
    }
}
