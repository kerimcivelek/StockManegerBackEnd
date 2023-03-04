using Application.Repositories;
using Application.Utilities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Persistence.Constants;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PbysContext _context;

        public RepositoryBase(PbysContext context)
        {
            _context = context;
        }
          
        public DbSet<T> Table => _context.Set<T>();

      
        public async Task<IResult> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = Table.Add(model);
            var data = entityEntry.State == EntityState.Added;

            await _context.SaveChangesAsync();
            return new SuccessResult(Messages.Added);


        }
        public IResult Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            var result = entityEntry.State == EntityState.Deleted;
            _context.SaveChanges();
             return new SuccessResult(Messages.Deleted);

        }
        public IResult RemoveGetById(int id)
        {
            T model =   Table.FirstOrDefault(data => data.Id == id);

            return Remove(model);
        }
        public async Task<IResult> Removesync(int id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
            return Remove(model);
        }

        public IResult Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            var result = entityEntry.State == EntityState.Modified;
            _context.SaveChanges();
            return new SuccessResult(Messages.Updated);

        }



        public async Task<IEnumerable<T>> GetAll()
        {
            return Table;
        }

        public async Task<T> GetById(int id)
        {
            return await Table.FirstOrDefaultAsync(data => data.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
        {
            return await Table.FirstOrDefaultAsync(filter);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter)
        {
            return Table.Where(filter);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IResult Add(T model)
        {
            EntityEntry<T> entityEntry = Table.Add(model);
            var data = entityEntry.State == EntityState.Added;

              _context.SaveChanges();
            return new SuccessResult(Messages.Added);
        }
    }
}
