using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSA2018_Hometask6.Tests.Fake.Repositories
{
    public class FakeDeparturesRepo:FakeRepo<Departure>
    {
        public FakeDeparturesRepo()
        {
            var fRepo = new FakeFlightsRepo();
            var pRepo = new FakePlaneRepo();
            var cRepo = new FakeCrewRepo();
            entities.Add(
                new Departure
                {
                    Id = 1,
                    Flight = fRepo.entities.Single(x => x.Id == 1),
                    Date = new DateTime(2018, 11, 14),
                    Plane = pRepo.entities.Single(x => x.Id == 1),
                    Crew = cRepo.entities.Single(x => x.Id == 1)
                }
                );
            entities.Add(
                new Departure
                {
                    Id = 2,
                    Flight = fRepo.entities.Single(x => x.Id == 1),
                    Date = new DateTime(2018, 10, 14),
                    Plane = pRepo.entities.Single(x => x.Id == 2),
                    Crew = cRepo.entities.Single(x => x.Id == 3)
                }
                );
            entities.Add(
                new Departure
                {
                    Id = 3,
                    Flight = fRepo.entities.Single(x => x.Id == 2),
                    Date = new DateTime(2018, 8, 10),
                    Plane = pRepo.entities.Single(x => x.Id == 3),
                    Crew = cRepo.entities.Single(x => x.Id == 2)
                }
                );
            entities.Add(
                new Departure
                {
                    Id = 4,
                    Flight = fRepo.entities.Single(x => x.Id == 3),
                    Date = new DateTime(2018, 8, 15),
                    Plane = pRepo.entities.Single(x => x.Id == 4),
                    Crew = cRepo.entities.Single(x => x.Id == 1)
                }
                );
        }
    }
}
