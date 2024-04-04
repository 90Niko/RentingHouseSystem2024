using RentingHouseSystem.Core.Models.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingHouseSystem.Core.Models.Admin
{
    public class MyHousesViewModel
    {
        public IEnumerable<HouseServiceModel> AddedHouses { get; set; }= new List<HouseServiceModel>();

        public IEnumerable<HouseServiceModel> RentedHouses { get; set; } = new List<HouseServiceModel>();
    }
}
