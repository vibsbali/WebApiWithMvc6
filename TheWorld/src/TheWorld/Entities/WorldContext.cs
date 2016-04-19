using Microsoft.Data.Entity;
using TheWorld.Models;

namespace TheWorld.Entities
{
    public class WorldContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }
    }
}
