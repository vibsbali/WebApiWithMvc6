using System.Collections.Generic;
using TheWorld.Entities;

namespace TheWorld.Repository
{
    public interface IRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsWithStops();
        void AddTrip(Trip newTrip);
        bool SaveAll();
    }
}
