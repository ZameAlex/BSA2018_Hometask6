using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.DAL.DbContext;
using System.Linq;

namespace DAL.Repository
{
    public class PlaneRepository : BaseRepository<Plane>
    {
        public PlaneRepository(AirportContext db):base(db)
        {
                
        }

        public override void Update(Plane entity, int id)
        {
            var temp = DbContext.SetOf<Plane>().SingleOrDefault(x => x.Id == id);
            temp.Created = entity.Created;
            temp.Expired = entity.Expired;
            temp.Type = entity.Type;
            temp.Name = entity.Name;
            DbContext.Planes.Update(temp);
            base.Update(entity, id);
        }

        public void Update(DateTime expires,int id)
        {
            Get(id).Expired = expires;
            DbContext.SaveChanges();
        }
    }
}
