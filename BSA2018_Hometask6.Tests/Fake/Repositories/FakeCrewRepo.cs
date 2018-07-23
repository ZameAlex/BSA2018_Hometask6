using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSA2018_Hometask6.Tests.Fake.Repositories
{
    public class FakeCrewRepo:FakeRepo<Crew>
    {
        public FakeCrewRepo()
        {
            FakePilotsRepo pRepo = new FakePilotsRepo();
            FakeStewadressRepo sRepo = new FakeStewadressRepo();
            entities.Add(new Crew
            {
                Id = 1,
                Pilot = pRepo.entities.Single(x => x.Id == 1),
                Stewadresses = new List<Stewardess>()
            {
                sRepo.entities.Single(x=>x.Id==1),
                sRepo.entities.Single(x=>x.Id==2),
                sRepo.entities.Single(x=>x.Id==6)
            }
            }
                );
            entities.Add(new Crew
            {
                Id = 2,
                Pilot = pRepo.entities.Single(x => x.Id == 2),
                Stewadresses = new List<Stewardess>()
            {
                sRepo.entities.Single(x=>x.Id==3),
                sRepo.entities.Single(x=>x.Id==4),
                sRepo.entities.Single(x=>x.Id==5)
            }
            }
            );
            entities.Add(new Crew
            {
                Id = 3,
                Pilot = pRepo.entities.Single(x => x.Id == 3),
                Stewadresses = new List<Stewardess>()
            {
                sRepo.entities.Single(x=>x.Id==1),
                sRepo.entities.Single(x=>x.Id==3),
                sRepo.entities.Single(x=>x.Id==5)
            }
            }
            );
        }
    }
}
