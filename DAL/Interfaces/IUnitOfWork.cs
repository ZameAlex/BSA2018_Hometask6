using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Flight> Flights { get; }
        IRepository<Ticket> Tickets { get; }
        IRepository<Departure> Departures { get; }
        IRepository<Stewardess> Stewadresses { get; }
        IRepository<Pilot> Pilots { get; }
        IRepository<Crew> Crew { get; }
        IRepository<Plane> Planes { get; }
        IRepository<PlaneType> Types { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
