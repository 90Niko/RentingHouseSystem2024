using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using RentingHouseSystem.Attributes;
using RentingHouseSystem.Core.Contracts.Agent;
using RentingHouseSystem.Core.Contracts.House;
using RentingHouseSystem.Core.Extensions;
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


            query.TotalHousesCount = model.TotalHousesCount;
            query.Houses = model.Houses;
            query.Categories = await houseService.AllCategoryNamesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();

            IEnumerable<HouseServiceModel> model = new List<HouseServiceModel>();

            if (User.IsAdmin())
            {
                return RedirectToAction("Mine", "House", new { area = "Admin" });
            }

            if (await agentService.ExistByIdAsync(userId))
            {
                int agentId = await agentService.GetAgentIdAsync(userId) ?? 0;

                model = await houseService.AllHousesByAgentIdAsync(agentId);
            }
            else
            {
                model = await houseService.AllHousesByUserIdAsync(userId);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await houseService.ExistAsync(id))
            {
                return BadRequest();
            }


            var model = await houseService.HouseDetailsByIdAsync(id);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }

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

            int? agentId = await agentService.GetIdByAgentIdAsync(User.Id());
            int? houseId = await houseService.CreateAsync(model, agentId.Value);

            if (agentId == null)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Details), new { id = houseId, information = model.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await houseService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (await houseService.HasAgentWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await houseService.GetHouseFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseFormModel model)
        {
            if (!await houseService.ExistAsync(id))
            {
                return BadRequest();
            }
            if (await houseService.HasAgentWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            if (!await houseService.CategoryExistAsync(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await houseService.AllCategoriesAsync();

                return View(model);
            }

            await houseService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            if (await houseService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await houseService.HasAgentWithIdAsync(id, User.Id()) && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var house = await houseService.HouseDetailsByIdAsync(id);

            var model = new HouseDetailsViewModel
            {
                Id = house.Id,
                Title = house.Title,
                Address = house.Address,
                ImageUrl = house.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, HouseDetailsViewModel model)
        {

            if (await houseService.ExistAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await houseService.HasAgentWithIdAsync(id, User.Id()) && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await houseService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }


        public async Task<IActionResult> Rent(int id)
        {
            if (!await houseService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (await agentService.ExistByIdAsync(User.Id()) && User.IsAdmin() == false)
            {
                return BadRequest();
            }

            if (await houseService.IsRentedAsync(id))
            {
                return BadRequest();
            }

            await houseService.RentAsync(id, User.Id());

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Leave(int id)
        {
            if (!await houseService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (await houseService.IsRentedByUserWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            await houseService.LeaveAsync(id, User.Id());

            return RedirectToAction(nameof(All));
        }
    }
}
