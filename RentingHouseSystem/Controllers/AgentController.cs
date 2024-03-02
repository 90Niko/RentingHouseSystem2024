using Microsoft.AspNetCore.Mvc;
using RentingHouseSystem.Core.Contracts.Agent;
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
            var model = new BecomeAgentFormModel();

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
