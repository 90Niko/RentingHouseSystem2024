﻿using RentingHouseSystem.Core.Contracts.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingHouseSystem.Core.Models.House
{
    public class HouseIndexServiceModel: IHouseModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
