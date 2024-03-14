using Microsoft.EntityFrameworkCore;
using RentingHouseSystem.Core.Contracts.Agent;
using RentingHouseSystem.Infrastructure.Data.Comman;
using RentingHouseSystem.Core.Models;
using System.Reflection.Metadata.Ecma335;

namespace RentingHouseSystem.Core.Services.Agent
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;

        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new Infrastructure.Data.Models.Agent
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });

            await repository.SaveChangesAsync();
        }

        public Task<bool> ExistByIdAsync(string userId)
        {
            return repository.AllReadOnly<Infrastructure.Data.Models.Agent>()
                 .AnyAsync(x => x.UserId == userId);
        }

        public async Task<int> GetIdByAgentIdAsync(string userId)
        {
           return await repository.AllReadOnly<Infrastructure.Data.Models.Agent>()
                .Where(x => x.UserId == userId)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UserHasRentsAsync(string userId)
        {
            return await repository.AllReadOnly<RentingHouseSystem.Infrastructure.Data.Models.House>()
                  .AnyAsync(x => x.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Agent>()
                .AnyAsync(x => x.PhoneNumber == phoneNumber);
        }
    }
}
