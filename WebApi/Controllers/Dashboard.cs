using Application.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Concrete;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Dashboard : ControllerBase
    {
        private readonly IDashboardRepository _dashboardRepository;

        public Dashboard(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }


        [HttpGet("dashboardtotalday")]
        public IActionResult DashboardTotalDay()
        {
            try
            {
                var data = _dashboardRepository.DashboardTotalDay();
                return Ok(data);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("dashboarddetaillday")]
        public IActionResult DashboardDetailDay(int EntryOut)
        {
            try
            {
                var data = _dashboardRepository.DashboardDetailDay(EntryOut);
                return Ok(data);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
