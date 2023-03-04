using Application.Security.Jwt;
using Application.Utilities;
using Domain.Dto;
using Domain.Entities;


namespace Application.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(LoginDto userForLoginDto);
        IDataResult<User> Update(RegisterDto userForRegisterDto, string password);
        IResult UserExists(string username);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<User> GetBeyUser(Guid key);
    }
}
