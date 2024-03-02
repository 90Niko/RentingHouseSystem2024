using Microsoft.EntityFrameworkCore;
using RentingHouseSystem.Core.Contracts.House;
using RentingHouseSystem.Core.Models;
using RentingHouseSystem.Infrastructure.Data.Comman;

namespace RentingHouseSystem.Core.Services.House
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;

        public HouseService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreedHouse()
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
