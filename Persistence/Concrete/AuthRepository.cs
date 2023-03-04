using Application.Abstract;
using Application.Security.Hashing;
using Application.Security.Jwt;
using Application.Utilities;
using Domain.Dto;
using Domain.Entities;
using Persistence.Constants;

namespace Persistence.Concrete
{
    public class AuthRepository : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthRepository(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public  IDataResult<User> Register(RegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserName = userForRegisterDto.UserName,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                status = true,
                Role = userForRegisterDto.Role,
                userkey = Guid.NewGuid(),
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(LoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByUser(userForLoginDto.UserName);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string UserName)
        {
            if (_userService.GetByUser(UserName) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Update(RegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            //var getUser = _userService.GetByUserKey(userForRegisterDto.userkey);
            var user = new User
            {
                Id = userForRegisterDto.Id,
                UserName = userForRegisterDto.UserName,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                status = userForRegisterDto.status,
                Role =   userForRegisterDto.Role,
                userkey = userForRegisterDto.userkey

            };
            _userService.Update(user);
            return new SuccessDataResult<User>(user, Messages.UserUpdated);
        }

        public IDataResult<User> GetBeyUser(Guid key)
        {
          var result =  _userService.GetByUserKey(key);

            return new SuccessDataResult<User>(result.Data);
    
        }
    }
}


