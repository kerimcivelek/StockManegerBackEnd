using Application.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Concrete;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Features : ControllerBase
    {
        private readonly IFeatureRepository _featureRepository;
        public Features(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }



        [HttpPost("add")]
        public async Task<IActionResult> CategoryAdd(Feature model)
        {
            var result = await _featureRepository.AddAsync(model);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("groupbyId")]
        public IActionResult Brand(int Id)
        {
            var data = _featureRepository.GetWhere(x => x.GroupId == Id);

            return Ok(data);
        }
    }
}
