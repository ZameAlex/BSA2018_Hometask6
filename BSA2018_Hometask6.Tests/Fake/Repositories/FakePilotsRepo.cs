using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask6.Tests.Fake.Repositories
{
    public class FakePilotsRepo : FakeRepo<Pilot>
    {


        public FakePilotsRepo()
        {
                entities.Add(
                    new Pilot
                    {
                        Id = 1,
                        Name = "Alex",
                        LastName = "Zamekula",
                        Birthday = new DateTime(1994, 8, 5),
                        Experience = 3
                    }
                    );
            entities.Add(
                    new Pilot
                    {
                        Id = 2,
                        Name = "Ksu",
                        LastName = "White",
                        Birthday = new DateTime(1992, 5, 31),
                        Experience = 4
                    }
                    );
            entities.Add(
                    new Pilot
                    {
                        Id = 3,
                        Name = "Yuri",
                        LastName = "Chuklib",
                        Birthday = new DateTime(1993, 9, 6),
                        Experience = 2
                    }
                    );
            entities.Add(
                    new Pilot
                    {
                        Id = 4,
                        Name = "Dima",
                        LastName = "Polik",
                        Birthday = new DateTime(1990, 11, 15),
                        Experience = 8
                    }
                    );
            }

        
    }
}
