﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingHouseSystem.Core.Contracts.Agent
{
    public interface IAgentService
    {
        Task<bool> ExistByIdAsync(string userId);

        Task<bool> UserWithPhoneNumberAsync(string phoneNumber);

        Task<bool> UserHasRentsAsync(string userId);

        Task CreateAsync(string userId,string phoneNumber);

        Task<int> GetIdByAgentIdAsync(string userId);

        Task<int?> GetAgentIdAsync(string userId);
    }
}
