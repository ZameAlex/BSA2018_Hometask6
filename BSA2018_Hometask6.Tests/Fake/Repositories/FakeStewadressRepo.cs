using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask6.Tests.Fake.Repositories
{
    public class FakeStewadressRepo:FakeRepo<Stewadress>
    {
        public FakeStewadressRepo()
        {
            entities.Add(
                new Stewadress
                {
                    Id=1,
                    Name = "Tanya",
                    LastName = "Sinchuk",
                    Birthday = new DateTime(1996, 8, 27)
                }
                );
            entities.Add(
                new Stewadress
                {
                    Id = 2,
                    Name = "Viktorua",
                    LastName = "Dachuk",
                    Birthday = new DateTime(1995, 3, 18)
                }
                );
            entities.Add(
               new Stewadress
               {
                   Id = 3,
                   Name = "Kate",
                   LastName = "Kostash",
                   Birthday = new DateTime(1996, 12, 5)
               }
               );
            entities.Add(
               new Stewadress
               {
                   Id = 4,
                   Name = "Svetlana",
                   LastName = "Polyshuk",
                   Birthday = new DateTime(1998, 2, 23)
               }
               );
            entities.Add(
               new Stewadress
               {
                   Id = 5,
                   Name = "Natalia",
                   LastName = "Dorohova",
                   Birthday = new DateTime(1996, 6, 21)
               }
               );
            entities.Add(
               new Stewadress
               {
                   Id = 6,
                   Name = "Maryna",
                   LastName = "Medvin",
                   Birthday = new DateTime(1996, 1, 24)
               }
               );
        }
    }
}
