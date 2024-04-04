using Microsoft.AspNetCore.Mvc;
using RentingHouseSystem.Core.Contracts.Agent;
using RentingHouseSystem.Core.Contracts.House;
using RentingHouseSystem.Core.Models.Admin;
using RentingHouseSystem.Extensions;

namespace RentingHouseSystem.Areas.Admin.Controllers
{
    public class HouseController : AdminBaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HouseController(IHouseService houseService, IAgentService agentService)
        {
            this.houseService = houseService;
            this.agentService = agentService;
        }

        public async Task<IActionResult> Mine()
        {
            var user = User.Id();

            int agentId = await agentService.GetAgentIdAsync(user) ?? 0;

            var myHouses = new MyHousesViewModel
            {
                AddedHouses = await houseService.AllHousesByAgentIdAsync(agentId),
                RentedHouses = await houseService.AllHousesByUserIdAsync(user)
            };
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Approve(int id)
        {
            var model = await houseService.GetHouseFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approved(int houseId)
        {
            await houseService.ApprovedHouseAsync(houseId);

            return RedirectToAction(nameof(Approve));
        }
    }
}
