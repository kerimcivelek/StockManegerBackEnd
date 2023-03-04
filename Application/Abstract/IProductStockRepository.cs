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
    public interface IProductStockRepository: IRepository<ProductStock>
    {
        IQueryable<ProductStockDto> DetailsByProduuct(int ProductId);

        IQueryable<GroupBySumProductDto> GroupBySumProduct();

        IQueryable<ProductStockDto> ProductInStock(int ProductId);

       


    }
}
