using Application.Abstract;
using Application.Utilities;
using Domain.Dto;
using Domain.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Persistence.Constants;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Concrete
{
    public class UserRepository : RepositoryBase<User>, IUserService
    {
        private readonly PbysContext _context;
        public UserRepository(PbysContext context) : base(context)
        {
            _context = context;
        }

        public User GetByUser(string username)
        {
            var data = from u in _context.Users where u.UserName == username select u;

            return data.FirstOrDefault();
        }

        public IDataResult<UserListDto> GetByUserId(int Id)
        {
            var data =  from user in _context.Users
                        where user.Id == Id
                   select new UserListDto
                   {
                       Id = user.Id,
                       UserName = user.UserName,
                       LastName = user.LastName,
                       FirstName = user.FirstName,
                       Status = user.status,
                       Rol = user.Role,
                       userkey = user.userkey
                   };

            return new SuccessDataResult<UserListDto>(data.FirstOrDefault());
        }

        public IDataResult<User> GetByUserKey(Guid key)
        {
            var data = from u in _context.Users where u.userkey == key select u;
            return new SuccessDataResult<User>(data.FirstOrDefault());
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = from operationClaim in _context.OperationClaims
                         join userOperationClaim in _context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }

        public IQueryable<User> UserList()
        {
            return from user in _context.Users
                   select new User
                   {
                     Id = user.Id,
                     UserName  = user.UserName,
                     LastName = user.LastName,
                     FirstName = user.FirstName,
                     status =   user.status,
                     Role   =   user.Role
                   };
        }
    }
}
