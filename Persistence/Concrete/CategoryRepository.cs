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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly PbysContext _context;
        public CategoryRepository(PbysContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<BaseCategoryDto> BaseCategoryGetAll()
        {
           List<BaseCategoryDto> data = new List<BaseCategoryDto>()
           {
               new BaseCategoryDto() { Id = 0, Name ="-- Ürün Grubu Seçiniz -- " },
               new BaseCategoryDto() { Id = 1, Name = "Cep Telefonları" },
               new BaseCategoryDto() { Id = 2, Name = "Tabletler" },
               new BaseCategoryDto() { Id = 3, Name = "Aksesuar" },
               new BaseCategoryDto() { Id = 4, Name = "Ses Ekipmanları" },
               new BaseCategoryDto() { Id = 5, Name = "Diğer" },
           };
            return data.AsQueryable();
        }

        public IQueryable<CategoryDto> CategoryGetAll()
        {
            var result = from c in _context.Categories
                         select new CategoryDto
                         {
                             id = c.Id,
                             CategoryTyp = c.CategoryType,
                             CategoryTypeName = (
                               c.CategoryType == 1 ? "Cep Telefonları" :
                               c.CategoryType == 2 ? "Tabletler" :
                               c.CategoryType == 3 ? "Aksesuar" :
                               c.CategoryType == 4 ? "Ses Ekipmanları" :
                               c.CategoryType == 5 ? "Diğer" : ""),
                             Name = c.Name ,
                             Status = c.status
                         };
            return result;

        }
    }
}
