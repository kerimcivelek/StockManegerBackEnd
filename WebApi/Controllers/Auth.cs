using Application.Abstract;
using Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistence.Concrete;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private IAuthService _authService;
        private IUserService _userService;


        public Auth(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;

        }

        [HttpPost("login")]
        public ActionResult Login(LoginDto loginDto)
        {

            var userToLogin = _authService.Login(loginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
                // return BadRequest(JsonConvert.SerializeObject( new MessageModel { Messages = userToLogin.Message }));


            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
 

        [HttpPost("register")]
        public ActionResult Register(RegisterDto dto)
        {
            var userExists = _authService.UserExists(dto.UserName);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(dto, dto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public ActionResult Update(RegisterDto dto)
        {
            var result = _authService.Update(dto, dto.Password);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyuser")]
        public IActionResult GetByUser(Guid key)
        {
            var data = _userService.GetByUserKey(key);

            return Ok(data.Data);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int Id)
        {
            var result = _userService.GetByUserId(Id);
            
            return Ok(result.Data);
        }

        [HttpGet("getall")]
        public IActionResult GetUserList()
        {
            var result = _userService.UserList();
          
            return Ok(result);
        }
    }
}
