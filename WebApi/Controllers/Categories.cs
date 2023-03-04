using Application.Abstract;
using Application.Utilities;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    
   

    [Route("api/[controller]")]
    [ApiController]
    public class Categories : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IModelRepository _modelRepository;
        public Categories(ICategoryRepository categoryRepository, IBrandRepository brandRepository , IModelRepository modelRepository)
        {
            _categoryRepository = categoryRepository; ;
            _brandRepository = brandRepository  ;
            _modelRepository = modelRepository ;    
        }


        [HttpGet("basecategorygetall")]
        [Authorize(Roles ="Admin")]
        public IActionResult basecategorygetall()
        {
            try
            {
                var data = _categoryRepository.BaseCategoryGetAll();
                return Ok(data);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("getcategorybyid")]
        public IActionResult GetCategoryById(int Id)
        {
            var data = _categoryRepository.GetWhere(x => x.CategoryType == Id);

            return Ok(data);
        }


        [HttpGet("categorygetall")]
        public IActionResult getall()
        {
            try
            {
                var data = _categoryRepository.CategoryGetAll();
                return Ok(data);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
         
        [HttpGet("categorygbrandlist")]
        public IActionResult categorygbrandlist()
        {
             
            
                var data = _brandRepository.CategoryBrandGetAll();
                return Ok(data);
            
        }

        [HttpGet("modelgetall")]
        public IActionResult ModelList()
        {


            var data = _modelRepository.CategoryBrandModelGetAll();
            return Ok(data);

        }

        [HttpPost("categoryAdd")]
        public async  Task<IActionResult> CategoryAdd(Category model)
        {
         var result =  await _categoryRepository.AddAsync(model);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
            
        }

        [HttpPost("brandadd")]
        public async Task<IActionResult> BrandAdd(Brand model)
        {
          var result =  await _brandRepository.AddAsync(model);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        
        }

        [HttpPost("modeladd")]
        public async Task<IActionResult> ModelAdd(Model model)
        {
           var result = await _modelRepository.AddAsync(model);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("brandremovegetbyid")]
        public  IActionResult  BrandRemove(int Id)
        {
              _brandRepository.RemoveGetById(Id);

            return Ok();
        }

        [HttpGet("brandgetbyid")]
        public  IActionResult  Brand(int Id)
        {
             var data =  _brandRepository.GetWhere(x => x.CategoryId == Id) ;

            return Ok(data);
        }

        [HttpGet("modelgetbyid")]
        public IActionResult model(int Id)
        {
            var data = _modelRepository.GetWhere(x => x.BrandId == Id);

            return Ok(data);
        }
    }
}
