using Application.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Concrete;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Accessories : ControllerBase
    {
        private readonly IAccessoryRepository _accessoryRepository;
        public Accessories(IAccessoryRepository  accessoryRepository)
        {
            _accessoryRepository = accessoryRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAccessory(Accessory model)
        {
            
                var result = await _accessoryRepository.AddAsync(model);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);

        }


        [HttpGet("remove")]
        public IActionResult BrandRemove(int Id)
        {
           var result =  _accessoryRepository.RemoveGetById(Id);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("accessoriesinproduct")]
        public IActionResult GetByProduct(int ProductId)
        {
            var data = _accessoryRepository.AccessoryinProductGettAll(ProductId);

            return Ok(data);
        }
    }
}
