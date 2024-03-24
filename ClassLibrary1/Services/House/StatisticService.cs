using Microsoft.EntityFrameworkCore;
using RentingHouseSystem.Core.Contracts.House;
using RentingHouseSystem.Core.Models.Statistics;
using RentingHouseSystem.Infrastructure.Data.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingHouseSystem.Core.Services.House
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository _repository;

        public StatisticService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<StatisticServiceModel> TotalAsync()
        {
            int totalHouse = await _repository.AllReadOnly<RentingHouseSystem.Infrastructure.Data.Models.House>().CountAsync();

            int totalRents = await _repository.AllReadOnly<RentingHouseSystem.Infrastructure.Data.Models.House>()
                .Where(x => x.RenterId != null)
                .CountAsync();

            return new StatisticServiceModel
            {
                TotalHouse = totalHouse,
                TotalRents = totalRents
            };
        }
    }
}
