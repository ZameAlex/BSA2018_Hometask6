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
        BaseRepository<Flight> Flights { get; }
        BaseRepository<Ticket> Tickets { get; }
        BaseRepository<Departure> Departures { get; }
        BaseRepository<Stewadress> Stewadresses { get; }
        BaseRepository<Pilot> Pilots { get; }
        BaseRepository<Crew> Crew { get; }
        BaseRepository<Plane> Planes { get; }
        BaseRepository<PlaneType> Types { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
