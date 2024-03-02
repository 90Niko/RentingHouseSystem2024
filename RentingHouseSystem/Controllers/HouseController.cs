using Microsoft.AspNetCore.Mvc;

namespace RentingHouseSystem.Controllers
{
    public class HouseController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
