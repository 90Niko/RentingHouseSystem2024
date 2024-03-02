using Microsoft.AspNetCore.Mvc;
using RentingHouseSystem.Core.Contracts.House;
using RentingHouseSystem.Models;
using System.Diagnostics;
using System.Web.Http;

namespace RentingHouseSystem.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        private readonly IHouseService houseService;

        public HomeController(ILogger<HomeController> _logger, IHouseService _houseService)
        {
            logger = _logger;
            houseService = _houseService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await houseService.LastThreedHouse();

            return View(model);
        }

        [AllowAnonymous]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
