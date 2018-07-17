using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.DAL.DbContext;

namespace DAL.Repository
{
    public class PilotRepository : BaseRepository<Pilot>
    {
        public PilotRepository(AirportContext db):base(db)
        {

        }

        public void Update(int experience,int id)
        {
            Get(id).Experience = experience;
            DbContext.SaveChanges();
        }
    }
}
