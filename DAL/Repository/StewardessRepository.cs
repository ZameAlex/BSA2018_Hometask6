using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.DAL.DbContext;
using System.Linq;

namespace DAL.Repository
{
    public class StewardessRepository : BaseRepository<Stewardess>
    {
        public StewardessRepository(AirportContext db):base(db)
        {

        }

        public override void Update(Stewardess entity, int id)
        {
            var temp = DbContext.SetOf<Stewardess>().SingleOrDefault(x => x.Id == id);
            temp.Birthday = entity.Birthday;
            temp.LastName = entity.LastName;
            temp.Name = entity.Name;
            DbContext.Stewardesses.Update(temp);
            base.Update(entity, id);
        }
    }
}
