using Application.Abstract;
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
    public class ModelRepository : RepositoryBase<Model>, IModelRepository
    {
      
        private readonly PbysContext _context;
        public ModelRepository(PbysContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<CategoryBrandDto> CategoryBrandModelGetAll()
        {


            var result = from c in _context.Categories
                         join b in _context.Brands on c.Id equals b.CategoryId
                         join m in _context.Models on b.Id equals m.BrandId
                         select new CategoryBrandDto
                         {
                             id = m.Id,
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
                             Status = b.status
                         };
            return result;

        }
      
    }
}
