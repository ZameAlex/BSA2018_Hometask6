using BSA2018_Hometask4.DAL.DbContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class FlightRepository : BaseRepository<Flight>
    {

        public FlightRepository(AirportContext db) : base(db)
        {

        }

        public void Update(DateTime departure, DateTime destination, int id)
        {
            var temp = Get(id);
            temp.DepartureTime = departure;
            temp.DestinationTime = destination;
            DbContext.SaveChanges();
        }
    }
}
