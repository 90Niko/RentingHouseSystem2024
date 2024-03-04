using Microsoft.AspNetCore.Mvc;
using RentingHouseSystem.Core.Contracts.Agent;
using System.Security.Claims;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace RentingHouseSystem.Controllers
{
    [Authorize]
    public class AgentController : BaseController
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await agentService.ExistByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return BadRequest("You are already an agent");
            }

            var model = new BecomeAgentFormModel
            {
                PhoneNumber = await agentService.UserWithPhoneNumberAsync(User.FindFirstValue(ClaimTypes.MobilePhone))
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
