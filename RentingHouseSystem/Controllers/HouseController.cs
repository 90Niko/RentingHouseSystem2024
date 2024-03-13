using Microsoft.AspNetCore.Mvc;
using RentingHouseSystem.Attributes;
using RentingHouseSystem.Core.Contracts.Agent;
using RentingHouseSystem.Core.Contracts.House;
using RentingHouseSystem.Core.Models.House;
using RentingHouseSystem.Extensions;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace RentingHouseSystem.Controllers
{
    [Authorize]
    public class HouseController : BaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HouseController(IHouseService houseService, IAgentService agentService)
        {
            this.houseService = houseService;
            this.agentService = agentService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllHousesQueryModel query)
        {
            var model = await houseService.AllAsync(
                   query.Category,
                   query.SearchTerm,
                   query.Sorting,
                   query.CurrentPage,
                   AllHousesQueryModel.HousesPerPage);

            query.TotalHousesCount = model.totalHousesCount;
            query.Houses = model.Houses;
            query.Categories = await houseService.AllCategoryNamesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = new AllHousesQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var model = new HouseDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        [MustBeAgent]
        public async Task<IActionResult> Add()
        {
            var model = new HouseFormModel
            {
                Categories = await houseService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeAgent]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            if (!await houseService.CategoryExistAsync(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await houseService.AllCategoriesAsync();

                return View(model);
            }

            int? agentId = await agentService.GetIdByUserIdAsync(User.Id());
            int? houseId = await houseService.CreateAsync(model, agentId.Value);

            if (agentId == null)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Mine), new { id = houseId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new HouseFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new HouseDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, HouseDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }


        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
