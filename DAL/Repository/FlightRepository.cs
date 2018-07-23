using BSA2018_Hometask4.DAL.DbContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class FlightRepository : BaseRepository<Flight>
    {

        public FlightRepository(AirportContext db) : base(db)
        {

        }


        public override void Update(Flight entity, int id)
        {
            var temp = DbContext.SetOf<Flight>().SingleOrDefault(x => x.Id == id);
            temp.DeparturePoint = entity.DeparturePoint;
            temp.DepartureTime = entity.DepartureTime;
            temp.DestinationPoint = entity.DestinationPoint;
            temp.DestinationTime = entity.DestinationTime;
            temp.Number = entity.Number;
            temp.Tickets = entity.Tickets;
            DbContext.Flights.Update(temp);
            base.Update(entity, id);
        }

        public override void Update(int id, dynamic[] dynamics)
        {
            var temp = Get(id);
            temp.DepartureTime = dynamics[0];
            temp.DestinationTime = dynamics[1];
            DbContext.Update(temp);
            DbContext.SaveChanges();
        }
    }
}
