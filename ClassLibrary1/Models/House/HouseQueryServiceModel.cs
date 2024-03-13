namespace RentingHouseSystem.Core.Models.House
{
    public class HouseQueryServiceModel
    {
        public int totalHousesCount { get; set; }

        public IEnumerable<HouseServiceModel> Houses { get; set; }= new List<HouseServiceModel>();
    }
}
