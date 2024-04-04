using RentingHouseSystem.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingHouseSystem.Core.Contracts.House
{
    public interface IRentService
    {
        Task<IEnumerable<RentServiceModel>> AllAsync();
    }
}
