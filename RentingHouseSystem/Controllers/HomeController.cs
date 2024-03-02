using Microsoft.AspNetCore.Mvc;
using RentingHouseSystem.Core.Contracts.House;
using RentingHouseSystem.Models;
using System.Diagnostics;

namespace RentingHouseSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        private readonly IHouseService houseService;

        public HomeController(ILogger<HomeController> _logger, IHouseService _houseService)
        {
            logger = _logger;
            houseService = _houseService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await houseService.LastThreedHouse();

            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
