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
        public JsonResult GetCities()
        {
            return new JsonResult( 
            new List<object>
            {
                new {id = 1, Name = "New York"},
                new {id = 2, Name = "Antwerp"}
            });
        }
    }
}
