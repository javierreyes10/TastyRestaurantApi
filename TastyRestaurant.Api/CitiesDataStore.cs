using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using TastyRestaurant.Api.Models;

namespace TastyRestaurant.Api
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();    
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>
            {
                new CityDto {Id = 1, Name = "New York City", Description = "The one with the big park"},
                new CityDto {Id = 2, Name = "San Francisco", Description = "The city with a beautiful bridge"},
                new CityDto {Id = 3, Name = "Buenos Aires", Description = "The city where tango is danced"}
            };
        }
    }
}
