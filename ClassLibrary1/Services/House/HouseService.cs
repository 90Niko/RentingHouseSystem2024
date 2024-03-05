using Microsoft.EntityFrameworkCore;
using RentingHouseSystem.Core.Contracts.House;
using RentingHouseSystem.Core.Models.House;
using RentingHouseSystem.Infrastructure.Data.Comman;
using RentingHouseSystem.Infrastructure.Data.Models;

namespace RentingHouseSystem.Core.Services.House
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;

        public HouseService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                 .Select(x => new HouseCategoryServiceModel
                 {
                     Id = x.Id,
                     Name = x.Name
                 })
                 .ToListAsync();
        }

        public async Task<bool> CategoryExistAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>().AnyAsync(x => x.Id == categoryId);
        }

        public async Task<int> CreateAsync(HouseFormModel model, int agentId)
        {
            var house = new Infrastructure.Data.Models.House
            {
                Title = model.Title,
                Address = model.Address,
                AgentId = agentId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                CategoryId = model.CategoryId
            };

            await repository.AddAsync(house);
            await repository.SaveChangesAsync();

            return house.Id;

        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreedHouseAsync()
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.House>()
                .OrderByDescending(x => x.Id)
                .Take(3)
                .Select(x => new HouseIndexServiceModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl
                }).ToListAsync();
        }
    }
}
