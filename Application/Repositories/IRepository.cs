using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Utilities;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
        //Task<bool> AddAsync(T model);
        Task<IResult> AddAsync(T model);

        IResult Add(T model);
        IResult Remove(T model);
        IResult RemoveGetById(int id);
        Task<IResult> Removesync(int id);
        IResult Update(T model);
        Task<IEnumerable<T>> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);
        Task<T> GetById(int id);
      
        Task<int> SaveAsync();
    }
}
