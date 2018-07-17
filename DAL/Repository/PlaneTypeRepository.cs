using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.DAL.DbContext;

namespace DAL.Repository
{
    public class PlaneTypeRepository : BaseRepository<PlaneType>
    {
        public PlaneTypeRepository(AirportContext db):base(db)
        {

        }

    }
}
