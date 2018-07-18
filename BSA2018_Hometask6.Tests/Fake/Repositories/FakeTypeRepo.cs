using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask6.Tests.Fake.Repositories
{
    public class FakeTypeRepo:FakeRepo<PlaneType>
    {
        public FakeTypeRepo()
        {
            entities.Add(
                new PlaneType
                {
                    Id = 1,
                    Model = "Model1",
                    FleightLength = 9000,
                    MaxHeight = 11000,
                    MaxMass = 900,
                    Places = 150,
                    Speed = 900
                }
                );

            entities.Add(
                new PlaneType
                {
                    Id = 2,
                    Model = "Model2",
                    FleightLength = 7500,
                    MaxHeight = 9000,
                    MaxMass = 1100,
                    Places = 218,
                    Speed = 800
                }
                );
            entities.Add(
                new PlaneType
                {
                    Id = 3,
                    Model = "Model3",
                    FleightLength = 10000,
                    MaxHeight = 8000,
                    MaxMass = 80000,
                    Places = 90,
                    Speed = 900
                }
                );
        }
    }
}
