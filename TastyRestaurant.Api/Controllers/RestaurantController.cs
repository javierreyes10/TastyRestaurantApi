using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TastyRestaurant.Api.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/restaurant")]   
    public class RestaurantController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRestaurants(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) return NotFound();

            return Ok(city.Restaurants);
        }

        [HttpGet("{id}")]
        public IActionResult GetRestaurantById(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) return NotFound();

            var restaurant = city.Restaurants.FirstOrDefault(r => r.Id == id);
            
            if(restaurant == null) return NotFound();

            return Ok(restaurant);
        }
    }
}
