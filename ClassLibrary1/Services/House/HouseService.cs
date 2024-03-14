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

            if (category != null)
            {
                housesQuery = housesQuery.Where(x => x.Category.Name == category);
            }

            if (searchTerm != null)
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

            var houses = await housesQuery
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

            HouseQueryServiceModel model = new HouseQueryServiceModel
            {
                TotalHousesCount = totalHouses,
                Houses = houses
            };

            return Task.FromResult(model).Result;
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

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.House>()
                 .Where(x => x.AgentId == agentId)
                 // .ProjectHouse()
                 .Select(x => new HouseServiceModel
                 {
                     Id = x.Id,
                     Title = x.Title,
                     Address = x.Address,
                     ImageUrl = x.ImageUrl,
                     PricePerMonth = x.PricePerMonth,
                     IsRented = x.RenterId != null
                 })
                 .ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.House>()
                .Where(x => x.RenterId == userId)
                //.ProjectHouse()
                .Select(x => new HouseServiceModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Address = x.Address,
                    ImageUrl = x.ImageUrl,
                    PricePerMonth = x.PricePerMonth,
                    IsRented = x.RenterId != null
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

        public async Task EditAsync(int houseId, HouseFormModel model)
        {
            var house = await repository.GetByIdAsync<Infrastructure.Data.Models.House>(houseId);

            if (house != null)
            {
                return;
                house.Address = model.Address;
                house.CategoryId = model.CategoryId;
                house.Description = model.Description;
                house.ImageUrl = model.ImageUrl;
                house.PricePerMonth = model.PricePerMonth;
                house.Title = model.Title;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.House>()
                 .AnyAsync(x => x.Id == id);
        }

        public async Task<HouseFormModel?> GetHouseFormModelByIdAsync(int id)
        {
            var house = await repository.AllReadOnly<Infrastructure.Data.Models.House>()
                  .Where(x => x.Id == id)
                  .Select(x => new HouseFormModel
                  {
                      Address = x.Address,
                      CategoryId = x.CategoryId,
                      Description = x.Description,
                      ImageUrl = x.ImageUrl,
                      PricePerMonth = x.PricePerMonth,
                      Title = x.Title
                  }).FirstOrDefaultAsync();


            if (house != null)
            {
                house.Categories = await AllCategoriesAsync();
            }

            return house;
        }

        public async Task<bool> HasAgentWithIdAsync(int houseId, string userId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.House>()
                 .AnyAsync(x => x.Id == houseId && x.Agent.UserId == userId);
        }

        public async Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.House>()
                 .Where(x => x.Id == id)
                 .Select(x => new HouseDetailsServiceModel
                 {
                     Id = x.Id,
                     Address = x.Address,
                     Agent = new Models.Agent.AgentServiceModel()
                     {
                         Email = x.Agent.User.Email,
                         PhoneNumber = x.Agent.PhoneNumber
                     },
                     Category = x.Category.Name,
                     Description = x.Description,
                     ImageUrl = x.ImageUrl,
                     IsRented = x.RenterId != null,
                     PricePerMonth = x.PricePerMonth,
                     Title = x.Title
                 }).FirstAsync();
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

        private List<HouseServiceModel> ProjectTo(List<Infrastructure.Data.Models.House> houses)
        {
            return houses.Select(x => new HouseServiceModel
            {
                Id = x.Id,
                Title = x.Title,
                Address = x.Address,
                ImageUrl = x.ImageUrl,
                PricePerMonth = x.PricePerMonth,
                IsRented = x.RenterId != null
            }).ToList();
        }
    }
}
