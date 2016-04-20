using System.Collections.Generic;
using Microsoft.Data.Entity;
using TheWorld.Entities;
using TheWorld.Model;

namespace TheWorld.Repository
{
    public class WorldRespository : IRepository
    {
        private readonly WorldContext context;

        public WorldRespository(WorldContext context)
        {
            this.context = context;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return context.Trips;
        }

        public IEnumerable<Trip> GetAllTripsWithStops()
        {
            return context.Trips.Include(t => t.Stops);
        }

        public void AddTrip(Trip newTrip)
        {
            context.Add(newTrip);
        }

        public bool SaveAll()
        {
            var result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public void AddStop(string tripName, Stop newStop)
        {
            
        }
    }
}
