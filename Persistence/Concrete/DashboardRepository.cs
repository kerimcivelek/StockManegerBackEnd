using Application.Abstract;
using Application.Repositories;
using Domain.Dto;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Concrete
{
    public class DashboardRepository : RepositoryBase<ProductStock>, IDashboardRepository
    {
        private readonly PbysContext _context;
        public DashboardRepository(PbysContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<DashboardDetailDto> DashboardDetailDay(int EntryOut)
        {
            DateTime t1 = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
            DateTime t2 = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddDays(1).AddSeconds(-1);

            return from s in _context.ProductStocks
                   join p in _context.Products on s.ProductId equals p.Id
                   join c in _context.Categories on p.CategoryId equals c.Id
                   join b in _context.Brands on p.BrandId equals b.Id
                   join m in _context.Models on p.ModelId equals m.Id
                   where s.CreatedDate > t1 && s.CreatedDate < t2 && s.InOut== EntryOut
                   group new { s, b, m, c } by new {   b.BrandName, m.ModelName, c.Name } into groupdata
                   select new DashboardDetailDto
                   {
                       CategoryName = groupdata.Key.Name,
                       ProductName = groupdata.Key.BrandName + " " + groupdata.Key.ModelName,
                       Quantity =  groupdata.Sum(x=> x.s.Quantity),
                       Price = groupdata.Sum(x => x.s.Price)
                   };
        }

        public IQueryable<DashboardTotalDto> DashboardTotalDay()
        {
            DateTime t1 = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
            DateTime t2 = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddDays(1).AddSeconds(-1);

            return from s in _context.ProductStocks
                   where s.CreatedDate > t1 && s.CreatedDate < t2
                   select new DashboardTotalDto
                   {
                       Quantity = s.Quantity,
                       Price = s.Price,
                       EntryOut = s.InOut
                   };
                    
                   
        }
    }
}
