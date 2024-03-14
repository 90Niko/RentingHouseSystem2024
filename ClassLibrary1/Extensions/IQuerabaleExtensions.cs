using RentingHouseSystem.Core.Models.House;
using RentingHouseSystem.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerabaleHouseExtensions
    {
        public static IQueryable<HouseServiceModel> ProjectHouse(this IQueryable<House> houses)
        {
            return houses.Select(h => new HouseServiceModel
            {
                Id = h.Id,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                IsRented = h.RenterId != null,
                PricePerMonth = h.PricePerMonth,
                Title = h.Title
            });
        }
    }
}
