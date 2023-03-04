using Application.Abstract;
using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Concrete
{
    public class ProductRepository : RepositoryBase<Product> ,IProductRepository
    {
        private readonly PbysContext _context;
        public ProductRepository(PbysContext context) : base(context)
        {
            _context = context;
        }
      
        public IQueryable<ProductCartDto> ProductCartList()
        {


            return from p in _context.Products
                             join c in _context.Categories on p.CategoryId equals  c.Id
                             join b in _context.Brands on p.BrandId equals b.Id
                             join m in _context.Models on p.ModelId equals m.Id
                   where p.status==true
                   select new ProductCartDto
                             {
                                 Id = p.Id,
                                 CategoryType = c.CategoryType,
                                 CategoryTypeName = (
                                       c.CategoryType == 1 ? "Cep Telefonları" :
                                       c.CategoryType == 2 ? "Tabletler" :
                                       c.CategoryType == 3 ? "Aksesuar" :
                                       c.CategoryType == 4 ? "Ses Ekipmanları" :
                                       c.CategoryType == 5 ? "Diğer" : ""),
                       CategoryName = c.Name,
                                 BrandName = b.BrandName,
                                 ModelName = m.ModelName,
                                 Ram = p.Ram,
                                 Capacity = p.Capacity,
                                 Color = p.Colour,
                                 Note = p.Note,
                                 MinStock = p.Min,
                                 MaxStock = p.Max,
                                 ProductDescription= b.BrandName +" "+ m.ModelName+" "+p.Capacity
                   };
               
 
        }
    }
}
