using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentingHouseSystem.Core.Contracts.House;

namespace RentingHouseSystem.Controllers
{
    [Route("api/statistic")]
    [ApiController]
    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticApiController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet]   
        public async Task<IActionResult> GetStatistic()
        {
            var result = await _statisticService.TotalAsync();
            return Ok(result);
        }
    }
}
