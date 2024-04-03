using Microsoft.AspNetCore.Mvc;

namespace RentingHouseSystem.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> ForReview()
        {
            return View();
        }
    }
}
