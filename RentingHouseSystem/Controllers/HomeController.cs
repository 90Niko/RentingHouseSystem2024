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
            var model = await houseService.LastThreedHouseAsync();

            return View(model);
        }

        [AllowAnonymous]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("NotFound");
            }
            if (statusCode == 500)
            {
                return View("InternalServerError");
            }
            if (statusCode == 403)
            {
                return View("AccessDenied");
            }

            if (statusCode == 401)
            {
                return View("Unauthorized");
            }
            if (statusCode == 400)
            {
                return View("BadRequest");
            }

            return View();
        }
    }
}
