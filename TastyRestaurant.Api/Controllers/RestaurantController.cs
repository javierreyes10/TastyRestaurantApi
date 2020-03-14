using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TastyRestaurant.Api.Models;

namespace TastyRestaurant.Api.Controllers
{
    [ApiController]//in charge of the validation of ModelState. If a rule is invalid a bad request is sent automatically
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

        [HttpGet("{id}", Name = "GetRestaurantById")]
        public IActionResult GetRestaurantById(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) return NotFound();

            var restaurant = city.Restaurants.FirstOrDefault(r => r.Id == id);
            
            if(restaurant == null) return NotFound();

            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult CreationRestaurant(int cityId, [FromBody] RestaurantForCreationDto restaurant)
        {
           if(restaurant.Description == restaurant.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) return NotFound();

            var maxRestaurantId = CitiesDataStore.Current.Cities.SelectMany(c => c.Restaurants).Max(r => r.Id);

            var finalRestaurant = new RestaurantDto
            {
                Id = ++maxRestaurantId,
                Name = restaurant.Name,
                Description = restaurant.Description
            };

            city.Restaurants.Add(finalRestaurant);

            return CreatedAtRoute(
                "GetRestaurantById",
                new { cityId, id = finalRestaurant.Id },
                finalRestaurant);
        }
    }
}
