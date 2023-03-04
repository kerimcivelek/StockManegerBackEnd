using Application.Abstract;
using Domain.Dto;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Concrete
{
    public class ProductStockRepository : RepositoryBase<ProductStock>, IProductStockRepository
    {
        private readonly PbysContext _context;
        public ProductStockRepository(PbysContext context) : base(context)
        {
            _context = context;
        }

  

        public IQueryable<ProductStockDto> DetailsByProduuct(int ProductId)
        {
            return from s in _context.ProductStocks
                   join p in _context.Products on s.ProductId equals p.Id
                   join b in _context.Brands on p.BrandId equals b.Id
                   join m in _context.Models on p.ModelId equals m.Id
                   join u in _context.Users on  s.UserId  equals u.Id
                   where s.ProductId == ProductId
                   select new ProductStockDto
                   {

                       Id = s.Id,
                       ProductId=s.ProductId,
                       ProductName = b.BrandName + " " + m.ModelName,
                       IMEI = s.IMEI,
                       CustomerDescrition = s.CustomerDescrition,
                       Tckn = s.Tckn,   
                       InOut = (s.InOut == 1 ? "Giriş" : s.InOut == 0 ? "Çıkış" : ""),
                       UsedDivace = (s.UsedDivace==true?"İkinci El" : s.UsedDivace==false? "Sıfır" :""),
                       Quantity = s.Quantity,
                       Price = s.Price,
                       TotalPrice = s.Quantity * s.Price,
                       Descrition = s.Descrition,
                       CreatedDate = s.CreatedDate,
                       username = u.FirstName +" "+u.LastName

                   };
        }
        public IQueryable<GroupBySumProductDto> GroupBySumProduct()
        {
            return from p in _context.Products 
                   join c in _context.Categories on p.CategoryId equals c.Id
                   join b in _context.Brands on p.BrandId equals b.Id
                   join m in _context.Models on p.ModelId equals m.Id
                   join s in _context.ProductStocks on p.Id equals s.ProductId into stock from st in stock.DefaultIfEmpty()
                   where p.status == true
                   group new {p, c,st,b,m } by new { c.CategoryType, c.Name , p.Id, b.BrandName , m.ModelName , p.Capacity , p.Ram , p.Min , p.Max , p.Colour ,p.status } into groupdata
                   select new GroupBySumProductDto
                   {
                       Id = groupdata.Key.Id,
                       CategoryTypeId= groupdata.Key.CategoryType,
                       CategoryType = (
                               groupdata.Key.CategoryType == 1 ? "Cep Telefonları" :
                               groupdata.Key.CategoryType == 2 ? "Tabletler" :
                               groupdata.Key.CategoryType == 3 ? "Aksesuar" :
                               groupdata.Key.CategoryType == 4 ? "Ses Ekipmanları" :
                               groupdata.Key.CategoryType == 5 ? "Diğer" :""),
                       CategoryName = groupdata.Key.Name,
                       ProductDescription = groupdata.Key.BrandName + " " + groupdata.Key.ModelName,
                       Capacity = groupdata.Key.Capacity,
                       Ram = groupdata.Key.Ram,
                       MinStock=groupdata.Key.Min,
                       MaxStock=groupdata.Key.Max,
                       Colour=groupdata.Key.Colour,
                       TotalInStock =  groupdata.Sum(x=>x.st.InOut==1 ? x.st.Quantity:0),
                       TotalOutStock = groupdata.Sum(x => x.st.InOut == 0 ? x.st.Quantity : 0)
                     

                   };
        }
        public IQueryable<ProductStockDto> ProductInStock(int ProductId)
        {
            var data = from p in _context.ProductStocks
                       where p.ProductId == ProductId && p.InOut == 1 && 
                       !(from x in _context.ProductStocks where x.InOut == 0 && x.EntryId != null  select x.EntryId).ToList().Contains(p.Id)
                       select new ProductStockDto
                   {
                         Id = p.Id,
                         IMEI=p.IMEI
                   };

            return data;

        }
    }
}


