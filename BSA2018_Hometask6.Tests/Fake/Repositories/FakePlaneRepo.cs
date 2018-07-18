using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSA2018_Hometask6.Tests.Fake.Repositories
{
    public class FakePlaneRepo : FakeRepo<Plane>
    {

        public FakePlaneRepo()
        {
            var tRepo = new FakeTypeRepo();
            entities.Add(
                new Plane
                {
                    Id = 1,
                    Name = "Bobo",
                    Created = new DateTime(2015, 2, 1),
                    Type = tRepo.entities.Single(x => x.Id == 1),
                    Expired = DateTime.Now.AddDays(70)
                }
                );
            entities.Add(
                new Plane
                {
                    Id = 2,
                    Name = "Gutu",
                    Created = new DateTime(2014, 2, 1),
                    Type = tRepo.entities.Single(x => x.Id == 1),
                    Expired = DateTime.Now.AddDays(300)
                }
                );
            entities.Add(
                new Plane
                {
                    Id = 3,
                    Name = "Ulu",
                    Created = new DateTime(2012, 6, 23),
                    Type = tRepo.entities.Single(x => x.Id == 2),
                    Expired = DateTime.Now.AddDays(31)
                }
                );
            entities.Add(
                new Plane
                {
                    Id = 4,
                    Name = "Ukoz",
                    Created = new DateTime(2017, 11, 14),
                    Type = tRepo.entities.Single(x => x.Id == 2),
                    Expired = DateTime.Now.AddDays(700)
                }
                );
        }
       
    }
}
