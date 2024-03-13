using Microsoft.EntityFrameworkCore;
using RentingHouseSystem.Core.Contracts.House;
using RentingHouseSystem.Core.Enumaration;
using RentingHouseSystem.Core.Models.House;
using RentingHouseSystem.Infrastructure.Data.Comman;
using RentingHouseSystem.Infrastructure.Data.Models;
using System.Linq;

namespace RentingHouseSystem.Core.Services.House
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;

        public HouseService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<HouseQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var housesQuery = repository.AllReadOnly<Infrastructure.Data.Models.House>();

            if (!string.IsNullOrWhiteSpace(category))
            {
                housesQuery = housesQuery.Where(x => x.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                housesQuery = housesQuery.Where(
                    x => x.Title.ToLower().Contains(normalizedSearchTerm)
                || x.Description.ToLower().Contains(normalizedSearchTerm)
                || x.Address.ToLower().Contains(normalizedSearchTerm));
            }

            housesQuery = sorting switch
            {

                HouseSorting.Price => housesQuery
                .OrderBy(x => x.PricePerMonth),
                HouseSorting.NotRentedFirst => housesQuery
                .OrderBy(x => x.RenterId == null)
                .ThenByDescending(x => x.Id),
                _ => housesQuery
                .OrderByDescending(x => x.Id)
            };

            var houses = housesQuery
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(x => new HouseServiceModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Address = x.Address,
                    ImageUrl = x.ImageUrl,
                    PricePerMonth = x.PricePerMonth,
                    IsRented = x.RenterId != null
                }).ToListAsync();

            int totalHouses = await housesQuery.CountAsync();

            return new HouseQueryServiceModel
            {
                Houses = await houses,
                totalHousesCount = totalHouses
            };
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

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(x => x.Name)
                .Distinct()
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
