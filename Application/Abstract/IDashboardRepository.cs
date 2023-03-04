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
    public interface IDashboardRepository:IRepository<ProductStock>
    {
        IQueryable<DashboardTotalDto> DashboardTotalDay();

        IQueryable<DashboardDetailDto> DashboardDetailDay(int EntryOut);

    }
}
