using Microsoft.EntityFrameworkCore;
using RentingHouseSystem.Core.Contracts.User;
using RentingHouseSystem.Core.Models.Admin.User;
using RentingHouseSystem.Infrastructure.Data.Comman;
using RentingHouseSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingHouseSystem.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<AplicationUser>()
                .Include(u => u.Agent)
                .Select(u => new UserServiceModel
                {
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                    PhoneNumber = u.Agent != null ? u.Agent.PhoneNumber : null,
                    IsAgent = u.Agent != null
                })
                .ToListAsync();
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;
            var user = await repository.GetByIdAsync<AplicationUser>(userId);

            if (user != null)
            {
                result = user.FirstName + " " + user.LastName;
            }
            return result;
        }
    }
}
