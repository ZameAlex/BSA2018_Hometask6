using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.DAL.DbContext;
using System.Linq;

namespace DAL.Repository
{
    public class CrewRepository : BaseRepository<Crew>
    {
        public CrewRepository(AirportContext db):base(db)
        {
            
        }
        public override void Update(Crew entity, int id)
        {
            var temp = DbContext.SetOf<Crew>().SingleOrDefault(x => x.Id == id);
            temp.Pilot = entity.Pilot;
            temp.Stewadresses = entity.Stewadresses;
            DbContext.Crew.Update(temp);
            base.Update(entity, id);
        }
    }
}
