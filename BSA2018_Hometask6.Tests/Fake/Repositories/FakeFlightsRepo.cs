using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSA2018_Hometask6.Tests.Fake.Repositories
{
    public class FakeFlightsRepo:FakeRepo<Flight>
    {
        public FakeFlightsRepo()
        {
            var tRepo = new FakeTicketsRepo();
            entities.Add(new Flight
            {
                Id = 1,
                DeparturePoint = "Kyiv",
                DepartureTime = new DateTime(2018, 1, 1, 12, 0, 0),
                DestinationPoint = "Lviv",
                DestinationTime = new DateTime(2018, 1, 1, 14, 0, 0),
                Number = Guid.NewGuid(),
                Tickets = tRepo.entities.Where(x => x.Id < 2).ToList()
            }
            );

            entities.Add(new Flight
            {
                Id = 2,
                DeparturePoint = "Kyiv",
                DepartureTime = new DateTime(2018, 1, 1, 14, 0, 0),
                DestinationPoint = "Berlin",
                DestinationTime = new DateTime(2018, 1, 1, 17, 0, 0),
                Number = Guid.NewGuid(),
                Tickets = tRepo.entities.Where(x => x.Id == 2).ToList()
            }
            );
            entities.Add(new Flight
            {
                Id = 3,
                DeparturePoint = "Lviv",
                DepartureTime = new DateTime(2018, 1, 1, 21, 0, 0),
                DestinationPoint = "London",
                DestinationTime = new DateTime(2018, 1, 2, 0, 0, 0),
                Number = Guid.NewGuid(),
                Tickets = tRepo.entities.Where(x => x.Id >= 3).ToList()
            }
            );
            foreach(var f in entities)
            {
                f.Tickets.ForEach(t => t.Flight = f);
            }
        }
    }
}
