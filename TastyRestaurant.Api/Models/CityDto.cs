﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TastyRestaurant.Api.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int NumberOfRestaurants
        {
            get => Restaurants.Count;
        }

        public ICollection<RestaurantDto> Restaurants { get; set; } = new List<RestaurantDto>();
    }
}
