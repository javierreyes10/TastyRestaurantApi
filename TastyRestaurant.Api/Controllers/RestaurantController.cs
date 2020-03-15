using Microsoft.AspNetCore.JsonPatch;
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

            if (restaurant == null) return NotFound();

            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult CreationRestaurant(int cityId, [FromBody] RestaurantForCreationDto restaurant)
        {
            if (restaurant.Description == restaurant.Name)
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

        [HttpPut("{id}")]
        public IActionResult UpdatedRestaurant(int cityId, int id, 
                                            [FromBody] RestaurantForUpdateDto restaurant)
        {
            if (restaurant.Description == restaurant.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) return NotFound();

            var restaurantFromStore = city.Restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurantFromStore == null) return NotFound();

            restaurantFromStore.Name = restaurant.Name;
            restaurantFromStore.Description = restaurant.Description;

            return NoContent();//most common for update

        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateRestaurant(int cityId, int id,
            [FromBody] JsonPatchDocument<RestaurantForUpdateDto> patchDoc)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) return NotFound();

            var restaurantFromStore = city.Restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurantFromStore == null) return NotFound();

            var restaurantToPatch = new RestaurantForUpdateDto
            {
                Name = restaurantFromStore.Name,
                Description = restaurantFromStore.Description
            };

            patchDoc.ApplyTo(restaurantToPatch, ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (restaurantToPatch.Description == restaurantToPatch.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name");
            }

            if (!TryValidateModel(restaurantToPatch))
            {
                return BadRequest(ModelState);
            }

            restaurantFromStore.Name = restaurantToPatch.Name;
            restaurantFromStore.Description = restaurantToPatch.Description;

            return NoContent();//most common for update
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) return NotFound();

            var restaurantFromStore = city.Restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurantFromStore == null) return NotFound();

            city.Restaurants.Remove(restaurantFromStore);

            return NoContent();
        }
    }
}
  