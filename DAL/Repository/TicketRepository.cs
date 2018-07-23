using BSA2018_Hometask4.DAL.DbContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAL.Repository
{
    public class TicketRepository : BaseRepository<Ticket>
    {
        public TicketRepository(AirportContext db) : base(db)
        {

        }

        public override void Update(Ticket entity, int id)
        {
            var temp = DbContext.SetOf<Ticket>().SingleOrDefault(x => x.Id == id);
            temp.Flight = entity.Flight;
            temp.Price = entity.Price;
            DbContext.Tickets.Update(temp);
            base.Update(entity, id);
        }
    }
}
