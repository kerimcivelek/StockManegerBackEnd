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
    public class AccessoryRepository : RepositoryBase<Accessory>, IAccessoryRepository
    {
        private readonly PbysContext _context;
        
        public AccessoryRepository(PbysContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ProductAccessoryDto> AccessoryinProductGettAll(int productId)
        {

            return from c in _context.Categories
                   join a in _context.Accessories on c.Id equals a.CategoryId
                   where a.ProductId == productId
                   select new ProductAccessoryDto
                   {
                       Id = a.Id,
                       CategoryName = c.Name,
                       Name = a.Name,
                       Note=a.Note
                         
                   };
            

        }
    }
    }
 
