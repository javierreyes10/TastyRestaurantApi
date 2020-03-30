using Microsoft.EntityFrameworkCore;
using TastyRestaurant.Api.Entities;

namespace TastyRestaurant.Api.Contexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Citites { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
