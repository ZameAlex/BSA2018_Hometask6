using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BSA2018_Hometask4.DAL.DbContext;
using DAL.Models;
using DAL.Repository;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CrewRepository crewRepository;
        private FlightRepository flightRepository;
        private DepartureRepository departureRepository;
        private PilotRepository pilotRepository;
        private PlaneRepository planeRepository;
        private StewadressRepository stewadressRepository;
        private PlaneTypeRepository typeRepository;
        private TicketRepository ticketRepository;

        private readonly AirportContext db = new AirportContext();

        public UnitOfWork()
        {
            new DataSource(db);
        }

        #region Repositories
        public BaseRepository<Flight> Flights
        {
            get
            {
                if (flightRepository == null)
                    flightRepository = new FlightRepository(db);
                return flightRepository;
            }
        }

        public BaseRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository(db);
                return ticketRepository;
            }
        }

        public BaseRepository<Departure> Departures
        {
            get
            {
                if (departureRepository == null)
                    departureRepository = new DepartureRepository(db);
                return departureRepository;
            }
        }
        public BaseRepository<Stewadress> Stewadresses
        {
            get
            {
                if (stewadressRepository == null)
                    stewadressRepository = new StewadressRepository(db);
                return stewadressRepository;
            }
        }
        public BaseRepository<Pilot> Pilots
        {
            get
            {
                if (pilotRepository == null)
                    pilotRepository = new PilotRepository(db);
                return pilotRepository;
            }
        }
        public BaseRepository<Crew> Crew
        {
            get
            {
                if (crewRepository == null)
                    crewRepository = new CrewRepository(db);
                return crewRepository;
            }
        }
        public BaseRepository<Plane> Planes
        {
            get
            {
                if (planeRepository == null)
                    planeRepository = new PlaneRepository(db);
                return planeRepository;
            }
        }
        public BaseRepository<PlaneType> Types
        {
            get
            {
                if (typeRepository == null)
                    typeRepository = new PlaneTypeRepository(db);
                return typeRepository;
            }
        }

        public void Dispose()
        {
            
        }
        #endregion

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
