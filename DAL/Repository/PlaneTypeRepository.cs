using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.DAL.DbContext;
using System.Linq;

namespace DAL.Repository
{
    public class PlaneTypeRepository : BaseRepository<PlaneType>
    {
        public PlaneTypeRepository(AirportContext db) : base(db)
        {
        }

        public override void Update(PlaneType entity, int id)
        {
            var temp = DbContext.SetOf<PlaneType>().SingleOrDefault(x => x.Id == id);
            temp.MaxHeight = entity.MaxHeight;
            temp.MaxMass = entity.MaxMass;
            temp.Model = entity.Model;
            temp.Places = entity.Places;
            temp.Speed = entity.Speed;
            DbContext.Types.Update(temp);
            base.Update(entity, id);
        }
    }

}

