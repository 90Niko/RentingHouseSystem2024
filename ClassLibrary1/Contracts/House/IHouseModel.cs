﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingHouseSystem.Core.Contracts.House
{
    public interface IHouseModel
    {
        public string Title { get; set; }
        public string Address { get; set; }
    }
}
