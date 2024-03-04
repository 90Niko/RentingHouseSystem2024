using Microsoft.EntityFrameworkCore;
using RentingHouseSystem.Core.Contracts.Agent;
using RentingHouseSystem.Infrastructure.Data.Comman;

namespace RentingHouseSystem.Core.Services.Agent
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;

        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task CreateAsync(string userId, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistByIdAsync(string userId)
        {
           return repository.AllReadOnly<Infrastructure.Data.Models.Agent>()
                .AnyAsync(x => x.UserId == userId);
        }

        public Task<bool> UserHasRentsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserWithPhoneNumberAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
