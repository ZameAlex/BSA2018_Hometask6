using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.DAL.DbContext;

namespace DAL.Repository
{
    public class PlaneRepository : BaseRepository<Plane>
    {
        public PlaneRepository(AirportContext db):base(db)
        {
                
        }

        public void Update(TimeSpan expires,int id)
        {
            Get(id).Expired = expires;
            DbContext.SaveChanges();
        }
    }
}
