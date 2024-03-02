using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace RentingHouseSystem.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
