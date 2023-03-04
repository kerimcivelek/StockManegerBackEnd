using Application.Abstract;
using Application.Utilities;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Concrete;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Stock : ControllerBase
    {
        private readonly IProductStockRepository _productStockRepository;
        public Stock(IProductStockRepository productStockRepository)
        {
            _productStockRepository = productStockRepository;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductStock model)
        {
           
           
            var productCheck = _productStockRepository.GroupBySumProduct();
            var data = productCheck.Where(x => x.Id == model.ProductId) ;
            var stockcontrol = data.SingleOrDefault();

            

            if ( model.InOut==0 && stockcontrol.TotalStock < model.Quantity || model.Quantity==0 || model.Quantity<0)
            {
                return BadRequest("Çıkış Yapılamadı, Yetersiz Stok");
            }
           
            else
            {
                var result = await _productStockRepository.AddAsync(model);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
            }

            return BadRequest("Bilinmeyen Hata");

        }


        [HttpGet("remove")]
        public IActionResult Remove(int Id , int ProductId)
        {

           
            var entryStockControl = _productStockRepository.GetWhere(x=> x.EntryId==Id && x.InOut==0);
            var data = entryStockControl.Count();
            if (data>0)
            {
                return BadRequest("Çıkış Yapılamadı, Bu Girişe Ait Ürün Çıkışı Yapılmış");
            }
            else
            {
                var result = _productStockRepository.RemoveGetById(Id);

                if (result.Success)
                {
                    return Ok(result.Message);
                }
            }
           
            return BadRequest("Bilinmeyen Hata");
        }


        [HttpGet("getbyproductdetail")]
        public IActionResult GetByProduct(int ProductId)
        {
            var data = _productStockRepository.DetailsByProduuct(ProductId);

            return Ok(data);
        }



        [HttpGet("groupbysumproducts")]
        public IActionResult GroupBySumProduct()
        {
            var data = _productStockRepository.GroupBySumProduct();

            return Ok(data);
        }


        [HttpGet("getbyproductid")]
        public IActionResult GetByProductId(int Id)
        {
            var data = _productStockRepository.ProductInStock(Id);
          

            return Ok(data);
        }
 



    }
}
