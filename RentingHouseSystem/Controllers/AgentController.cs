using Microsoft.AspNetCore.Mvc;
using RentingHouseSystem.Attributes;
using RentingHouseSystem.Core.Contracts;
using RentingHouseSystem.Core.Contracts.Agent;
using RentingHouseSystem.Core.Models.Agent;
using RentingHouseSystem.Extensions;
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
        [NotAnAgent]
        public IActionResult Become()
        {
            var model = new BecomeAgentFormModel();

            return View(model);
        }

        [HttpPost]
        [NotAnAgent]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            if (await agentService.UserHasRentsAsync(User.Id()))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "You have rents and cannot become an agent");
            }

            if (await agentService.UserWithPhoneNumberAsync(User.Id()))
            {
                ModelState.AddModelError("Error", "You are already an agent");
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");

            await agentService.CreateAsync(User.Id(), model.PhoneNumber);
        }


    }
}
