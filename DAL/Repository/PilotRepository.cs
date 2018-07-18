using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.DAL.DbContext;
using System.Linq;

namespace DAL.Repository
{
    public class PilotRepository : BaseRepository<Pilot>
    {
        public PilotRepository(AirportContext db):base(db)
        {

        }


        public override void Update(Pilot entity, int id)
        {
            var temp = DbContext.SetOf<Pilot>().SingleOrDefault(x => x.Id == id);
            temp.Birthday = entity.Birthday;
            temp.Experience = entity.Experience;
            temp.LastName = entity.LastName;
            temp.Name = entity.Name;
            DbContext.Pilots.Update(temp);
            base.Update(entity, id);
        }

        public void Update(int experience,int id)
        {
            Get(id).Experience = experience;
            DbContext.SaveChanges();
        }
    }
}
