using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TastyRestaurant.Api.Controllers
{
    [ApiController]
    [Route("api/cities")]//common base route for all the action methods
    public class CitiesController : ControllerBase //not adding support for views
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null) return NotFound();

            return Ok(cityToReturn);
        }
    }


}
