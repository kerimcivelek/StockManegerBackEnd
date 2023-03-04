using Application.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalServices : ControllerBase
    {
        private readonly ITechnicalServiceRepository _technicalServiceRepository;
        public TechnicalServices(ITechnicalServiceRepository technicalServiceRepository)
        {
            _technicalServiceRepository= technicalServiceRepository;    
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(TechnicalService model)
        {
            if (model.Id > 0)
            {
                var result = _technicalServiceRepository.Update(model);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
            else
            {
                var result = await _technicalServiceRepository.AddAsync(model);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }


        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var data = _technicalServiceRepository.GetAll();

            return Ok(data.Result);
        }


        [HttpGet("detail")]
        public IActionResult Detail(int Id)
        {
            var data = _technicalServiceRepository.GetById(Id);

            return Ok(data.Result);
        }
    }
}
