﻿using RentingHouseSystem.Core.Enumaration;
using RentingHouseSystem.Core.Models.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingHouseSystem.Core.Contracts.House
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreedHouseAsync();

        Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistAsync(int categoryId);

        Task<int> CreateAsync(HouseFormModel model, int agentId);

        Task<HouseQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            HouseSorting sorting = HouseSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId);

        Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId);

        Task<bool> ExistAsync(int id);

        Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id);

        Task EditAsync(int houseId, HouseFormModel model);

        Task<bool> HasAgentWithIdAsync(int houseId, string userId);

        Task<HouseFormModel> GetHouseFormModelByIdAsync(int id);

        Task DeleteAsync(int houseId);

        Task<bool> IsRentedAsync(int houseId);

        Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId);

        Task RentAsync(int id, string userId);

        Task LeaveAsync(int houseId, string userId);

       Task<IEnumerable<HouseServiceModel>> GetUnApprovedAsync();

        Task ApprovedHouseAsync(int houseId);
    }
}
