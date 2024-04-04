using Microsoft.EntityFrameworkCore;
using RentingHouseSystem.Core.Contracts.House;
using RentingHouseSystem.Core.Models.Admin;
using RentingHouseSystem.Infrastructure.Data.Comman;

namespace RentingHouseSystem.Core.Services.User
{
    public class RentService: IRentService
    {
        private readonly IRepository _rentRepository;

        public RentService(IRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }
        public async Task<IEnumerable<RentServiceModel>> AllAsync()
        {
            return await _rentRepository.AllReadOnly<RentingHouseSystem.Infrastructure.Data.Models.House>()
                .Include(x => x.Agent)
                .Include(x => x.Renter)
                .Select(x => new RentServiceModel()
                {
                    AgentEmail = x.Agent.User.Email,
                    AgentFullName = $"{x.Agent.User.FirstName} {x.Agent.User.LastName}",
                    HouseImageURL = x.ImageUrl,
                    HouseTitle = x.Title,
                    RenterEmail = x.Renter != null ? x.Renter.Email : string.Empty,
                    RenterFullName = x.Renter != null ? $"{x.Renter.FirstName} {x.Renter.LastName}" : string.Empty
                })
                .ToListAsync();
        }
    }
}
