using Application.Abstract;
using Domain.Dto;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistence.Concrete
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        private readonly PbysContext _context;
        public BrandRepository(PbysContext context) : base(context)
        {
            _context=context;
        }
        public  IQueryable<CategoryBrandDto>  CategoryBrandGetAll()
        {
            
         
                var   result = from c in _context.Categories
                             join b in _context.Brands on c.Id equals b.CategoryId
                               select new CategoryBrandDto
                             {
                                 id = b.Id,
                                 CategoryType=c.CategoryType,
                                 CategoryTypeName = (
                               c.CategoryType == 1 ? "Cep Telefonları" :
                               c.CategoryType == 2 ? "Tabletler" :
                               c.CategoryType == 3 ? "Aksesuar" :
                               c.CategoryType == 4 ? "Ses Ekipmanları" :
                               c.CategoryType == 5 ? "Diğer" : ""),
                                 CategoryName = c.Name,
                                 BrandName =  b.BrandName,
                                 Status = b.status
                             };
                return result;
            
        }
    }
}
 