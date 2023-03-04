using Application.Abstract;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistence.Concrete;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public Products(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

       
        [HttpPost("addproduct")]
        public   async Task<IActionResult> productadd(Product model)
        {
            if (model.Id>0)
            {
                var result =  _productRepository.Update(model);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
            else
            {
                var result = await _productRepository.AddAsync(model);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
 
          
        }


        [HttpGet("getall")]
        public    IActionResult  ProductCartList()
        {
            var data =  _productRepository.ProductCartList();

            return Ok(data);
        }


        [HttpGet("getbyproduct")]
        public IActionResult GetByProduct(int Id)
        {
            var data = _productRepository.GetById(Id);

            return Ok(data.Result);
        }
    }
}
