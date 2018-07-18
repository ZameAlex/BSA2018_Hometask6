using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask6.Tests.Fake.Repositories
{
    public class FakeTicketsRepo:FakeRepo<Ticket>
    {
        public FakeTicketsRepo()
        {
            var fRepo = new FakeFlightsRepo();
            entities.Add(
                new Ticket
                {
                    Id = 1,
                    Price = 200m
                }
                );
            entities.Add(
               new Ticket
               {
                   Id = 2,
                   Price = 200m
               }
               );
            entities.Add(
               new Ticket
               {
                   Id = 3,
                   Price = 100m
               }
               );
            entities.Add(
               new Ticket
               {
                   Id = 4,
                   Price = 300m
               }
               );
            entities.Add(
               new Ticket
               {
                   Id = 5,
                   Price = 300m
               }
               );
            entities.Add(
               new Ticket
               {
                   Id = 6,
                   Price = 400m
               }
               );
        }
    }
}
