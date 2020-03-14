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
                new CityDto {
                    Id = 1,
                    Name = "Santa Tecla",
                    Description = "Sport Capital",
                    Restaurants = new List<RestaurantDto>
                    {
                        new RestaurantDto{Id = 1, Name = "Carymar", Description = "Pupusas located in Las Delicias"},
                        new RestaurantDto{Id = 2, Name = "Pizza Italia", Description = "Cash only"},
                        new RestaurantDto{Id = 3, Name = "Paseo el Carmen", Description = "A lot of places for hanging out" }
                    },
                 },
                new CityDto {Id = 2, 
                    Name = "Antiguo Cuscatlan", 
                    Description = "A small but a beautiful village",
                    Restaurants = new List<RestaurantDto>
                    {
                        new RestaurantDto{Id = 1, Name = "El Arco", Description = "A good coffe along with the nature"},
                        new RestaurantDto{Id = 2, Name = "Pupuseria everywhere", Description = "A Pupuseria in each corner"},
                        new RestaurantDto{Id = 3, Name = "Belen", Description = "Home-made food" }
                    },
                },
                new CityDto {
                    Id = 3, 
                    Name = "Zona Rosa", 
                    Description = "A fancy city",
                    Restaurants = new List<RestaurantDto>
                    {
                        new RestaurantDto{Id = 1, Name = "Denny's", Description = "Always open"},
                        new RestaurantDto{Id = 2, Name = "Sucre", Description = "A fancy restaurant"},
                        new RestaurantDto{Id = 3, Name = "Alive", Description = "A place for dancing and singing" }
                    }
                }
            };
        }
    }
}
