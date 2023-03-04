using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class ProductStockDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? CustomerDescrition { get; set; }
        public string InOut { get; set; }
        public string UsedDivace { get; set; }
        public string? Tckn { get; set; }
        public string? IMEI { get; set; }
        public int EntryOut { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }
        public int TotalInStock { get; set; }
        public int TotalOutStock { get; set; }
        public int TotalStock { get; set; }
        public string? Descrition { get; set; }
        public string username { get; set; }
        public DateTime CreatedDate { get; set; }
 

    }
}
