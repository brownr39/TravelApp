using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Models
{ 
    public class TripsRepository
    {
       private TravelContext db { get; set; }

       public TripsRespository(TravelContext context)
       {
           db = context;
       }

        public IEnumerable<Trip> GetAllTrips()
        {
            return db.Trip.OrderBy(t => t.Name).ToList();
        }

        public Trip GetTrip(int id)
        {
            var trip = db.Trip.Include(t => t.StopsList).Where(t => t.ID == id).Single();
            return trip;
        }





    }

    

    
}