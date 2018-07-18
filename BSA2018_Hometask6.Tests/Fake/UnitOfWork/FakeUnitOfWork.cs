using BSA2018_Hometask6.Tests.Fake.Repositories;
using DAL.Models;
using DAL.Repository;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask6.Tests.Fake.UnitOfWork
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private FakeCrewRepo crewRepository;
        private FakeFlightsRepo flightRepository;
        private FakeDeparturesRepo departureRepository;
        private FakePilotsRepo pilotRepository;
        private FakePlaneRepo planeRepository;
        private FakeStewadressRepo stewadressRepository;
        private FakeTypeRepo typeRepository;
        private FakeTicketsRepo ticketRepository;

        public FakeUnitOfWork()
        {
            crewRepository = new FakeCrewRepo();
            flightRepository = new FakeFlightsRepo();
            departureRepository = new FakeDeparturesRepo();
            pilotRepository = new FakePilotsRepo();
            planeRepository = new FakePlaneRepo();
            stewadressRepository = new FakeStewadressRepo();
            typeRepository = new FakeTypeRepo();
            ticketRepository = new FakeTicketsRepo();
        }
        public IRepository<Flight> Flights => flightRepository;

        public IRepository<Ticket> Tickets => ticketRepository;

        public IRepository<Departure> Departures => departureRepository;

        public IRepository<Stewadress> Stewadresses => stewadressRepository;

        public IRepository<Pilot> Pilots => pilotRepository;

        public IRepository<Crew> Crew => crewRepository;

        public IRepository<Plane> Planes => planeRepository;

        public IRepository<PlaneType> Types => typeRepository;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

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
