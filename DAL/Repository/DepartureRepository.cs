using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.DAL.DbContext;
using System.Linq;

namespace DAL.Repository
{
    public class DepartureRepository : BaseRepository<Departure>
    {

        public DepartureRepository(AirportContext db):base(db)
        {
                
        }


        public override void Update(Departure entity, int id)
        {
            var temp = DbContext.SetOf<Departure>().SingleOrDefault(x => x.Id == id);
            temp.Crew = entity.Crew;
            temp.Date = entity.Date;
            temp.Flight = entity.Flight;
            temp.Plane = entity.Plane;
            DbContext.Depatures.Update(temp);
            base.Update(entity, id);
        }

        public void Update(DateTime date, int id)
        {
            Get(id).Date = date;
            DbContext.SaveChanges();
        }
    }
}
