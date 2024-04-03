using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static RentingHouseSystem.Core.Constants.RoleConstants;

namespace RentingHouseSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
       
    }
}
