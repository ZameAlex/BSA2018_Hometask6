using BSA2018_Hometask4.DAL.DbContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Repository
{
    public class TicketRepository : BaseRepository<Ticket>
    {
        public TicketRepository(AirportContext db) : base(db)
        {

        }
    }
}
