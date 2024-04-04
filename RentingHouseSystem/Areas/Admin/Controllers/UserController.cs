using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RentingHouseSystem.Core.Contracts.User;
using RentingHouseSystem.Core.Models.Admin.User;
using static RentingHouseSystem.Core.Constants.AdministratorConstants;

namespace RentingHouseSystem.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;
        public UserController(IUserService userService,IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        public async Task<IActionResult> All()
        {
            var model = memoryCache.Get<IEnumerable<UserServiceModel>>(UsersCacheKey);

            if (model == null ||model.Any()==false)
            {
                model = await userService.AllAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                memoryCache.Set(UsersCacheKey, model, cacheEntryOptions);
            }
             
            return View(model);
        }
    }
}
