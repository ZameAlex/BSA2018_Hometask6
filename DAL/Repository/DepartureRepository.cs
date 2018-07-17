using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.DAL.DbContext;

namespace DAL.Repository
{
    public class DepartureRepository : BaseRepository<Departure>
    {

        public DepartureRepository(AirportContext db):base(db)
        {
                
        }

        public void Update(DateTime date, int id)
        {
            Get(id).Date = date;
            DbContext.SaveChanges();
        }
    }
}
