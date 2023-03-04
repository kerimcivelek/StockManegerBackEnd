using Application.Repositories;
using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IAccessoryRepository : IRepository<Accessory>
    {
        IQueryable<ProductAccessoryDto> AccessoryinProductGettAll(int productId);
    }
}
