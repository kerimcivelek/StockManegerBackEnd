using Application.Repositories;
using Application.Utilities;
using Domain.Dto;
using Domain.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IUserService : IRepository<User>   
    {

        User GetByUser(string username);
       
        List<OperationClaim> GetClaims(User user);
        
        //void Add(User user);
        //IResult Update(User user);

         IDataResult<User> GetByUserKey(Guid key);

        IQueryable<User> UserList();

        IDataResult<UserListDto> GetByUserId(int Id);
    }
}
