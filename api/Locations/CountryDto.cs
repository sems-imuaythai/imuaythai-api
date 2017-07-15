﻿using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Locations
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public static explicit operator CountryDto(Country country)
        {
            return new CountryDto
            {
                Id = country.Id,
                Code = country.Code,
                Name = country.Name
            };
        }
    }

    
}
