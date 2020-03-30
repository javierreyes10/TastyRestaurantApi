using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TastyRestaurant.Api.Contexts;

namespace TastyRestaurant.Api.Controllers
{
    [ApiController]
    [Route("api/testdatabase")]
    public class DummyController : ControllerBase
    {
        private readonly CityInfoContext _ctx;

        public DummyController(CityInfoContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult TestDatase()
        {
            return Ok();
        }
    }
}
