using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.DAL.DbContext;

namespace DAL.Repository
{
    public class CrewRepository : BaseRepository<Crew>
    {
        public CrewRepository(AirportContext db):base(db)
        {

        }
    }
}
