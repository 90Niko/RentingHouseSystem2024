using RentingHouseSystem.Core.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingHouseSystem.Core.Contracts.House
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}
