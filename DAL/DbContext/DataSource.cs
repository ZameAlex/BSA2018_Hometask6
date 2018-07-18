using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BSA2018_Hometask4.DAL.DbContext
{
    public class DataSource
    {

        public DataSource(AirportContext context)
        {
            context.Database.Migrate();


            #region Pilots initializing
            if (!context.Pilots.Any())
            {
                context.Pilots.Add(
                    new Pilot
                    {
                        Name = "Alex",
                        LastName = "Zamekula",
                        Birthday = new DateTime(1994, 8, 5),
                        Experience = 3
                    }
                    );
                context.Pilots.Add(
                    new Pilot
                    {
                        Name = "Ksu",
                        LastName = "White",
                        Birthday = new DateTime(1992, 5, 31),
                        Experience = 4
                    }
                    );
                context.Pilots.Add(
                    new Pilot
                    {
                        Name = "Yuri",
                        LastName = "Chuklib",
                        Birthday = new DateTime(1993, 9, 6),
                        Experience = 2
                    }
                    );
                context.Pilots.Add(
                    new Pilot
                    {
                        Name = "Dima",
                        LastName = "Polik",
                        Birthday = new DateTime(1990, 11, 15),
                        Experience = 8
                    }
                    );
                context.SaveChanges();
            }
            #endregion

            #region Stewardess initilizing
            if (!context.Stewadresses.Any())
            {
                context.Stewadresses.Add(
                new Stewadress
                {
                    Name = "Tanya",
                    LastName = "Sinchuk",
                    Birthday = new DateTime(1996, 8, 27)
                }
                );
                context.Stewadresses.Add(
                    new Stewadress
                    {
                        Name = "Viktorua",
                        LastName = "Dachuk",
                        Birthday = new DateTime(1995, 3, 18)
                    }
                    );
                context.Stewadresses.Add(
                   new Stewadress
                   {
                       Name = "Kate",
                       LastName = "Kostash",
                       Birthday = new DateTime(1996, 12, 5)
                   }
                   );
                context.Stewadresses.Add(
                   new Stewadress
                   {
                       Name = "Svetlana",
                       LastName = "Polyshuk",
                       Birthday = new DateTime(1998, 2, 23)
                   }
                   );
                context.Stewadresses.Add(
                   new Stewadress
                   {
                       Name = "Natalia",
                       LastName = "Dorohova",
                       Birthday = new DateTime(1996, 6, 21)
                   }
                   );
                context.Stewadresses.Add(
                   new Stewadress
                   {
                       Name = "Maryna",
                       LastName = "Medvin",
                       Birthday = new DateTime(1996, 1, 24)
                   }
                   );
                context.SaveChanges();
            }
            #endregion

            #region Crews initializing
            if (!context.Crew.Any())
            {
                context.Crew.Add(new Crew
                {
                    Pilot = context.Pilots.Single(x => x.Id == 1),
                    Stewadresses = new List<Stewadress>()
            {
                context.Stewadresses.Single(x=>x.Id==1),
                context.Stewadresses.Single(x=>x.Id==2),
                context.Stewadresses.Single(x=>x.Id==6)
            }
                }
                );
                context.Crew.Add(new Crew
                {
                    Pilot = context.Pilots.Single(x => x.Id == 2),
                    Stewadresses = new List<Stewadress>()
            {
                context.Stewadresses.Single(x=>x.Id==3),
                context.Stewadresses.Single(x=>x.Id==4),
                context.Stewadresses.Single(x=>x.Id==5)
            }
                }
                );
                context.Crew.Add(new Crew
                {
                    Pilot = context.Pilots.Single(x => x.Id == 3),
                    Stewadresses = new List<Stewadress>()
            {
                context.Stewadresses.Single(x=>x.Id==1),
                context.Stewadresses.Single(x=>x.Id==3),
                context.Stewadresses.Single(x=>x.Id==5)
            }
                }
                );
                context.SaveChanges();
            }
            #endregion

            #region Ticket initializing
            if (!context.Tickets.Any())
            {
                context.Tickets.Add(
                new Ticket
                {
                    Price = 200m
                }
                );
                context.Tickets.Add(
                   new Ticket
                   {
                       Price = 200m
                   }
                   );
                context.Tickets.Add(
                   new Ticket
                   {
                       Price = 100m
                   }
                   );
                context.Tickets.Add(
                   new Ticket
                   {
                       Price = 300m
                   }
                   );
                context.Tickets.Add(
                   new Ticket
                   {
                       Price = 300m
                   }
                   );
                context.Tickets.Add(
                   new Ticket
                   {
                       Price = 400m
                   }
                   );
                context.SaveChanges();
            }
            #endregion

            #region Flights Initializing
            if (!context.Flights.Any())
            {
                context.Flights.Add(new Flight
                {
                    DeparturePoint = "Kyiv",
                    DepartureTime = new DateTime(2018, 1, 1, 12, 0, 0),
                    DestinationPoint = "Lviv",
                    DestinationTime = new DateTime(2018, 1, 1, 14, 0, 0),
                    Number = Guid.NewGuid(),
                    Tickets = context.Tickets.Where(x => x.Id < 2).ToList()
                }
            );

                context.Flights.Add(new Flight
                {
                    DeparturePoint = "Kyiv",
                    DepartureTime = new DateTime(2018, 1, 1, 14, 0, 0),
                    DestinationPoint = "Berlin",
                    DestinationTime = new DateTime(2018, 1, 1, 17, 0, 0),
                    Number = Guid.NewGuid(),
                    Tickets = context.Tickets.Where(x => x.Id ==2).ToList()
                }
                );
                context.Flights.Add(new Flight
                {
                    DeparturePoint = "Lviv",
                    DepartureTime = new DateTime(2018, 1, 1, 21, 0, 0),
                    DestinationPoint = "London",
                    DestinationTime = new DateTime(2018, 1, 2, 0, 0, 0),
                    Number = Guid.NewGuid(),
                    Tickets = context.Tickets.Where(x => x.Id >= 3).ToList()
                }
                );
                context.SaveChanges();
            }
            #endregion

            #region Types initializing
            if (!context.Types.Any())
            {
                context.Types.Add(
                new PlaneType
                {
                    Model = "Model1",
                    FleightLength = 9000,
                    MaxHeight = 11000,
                    MaxMass = 900,
                    Places = 150,
                    Speed = 900
                }
                );

                context.Types.Add(
                    new PlaneType
                    {
                        Model = "Model2",
                        FleightLength = 7500,
                        MaxHeight = 9000,
                        MaxMass = 1100,
                        Places = 218,
                        Speed = 800
                    }
                    );
                context.Types.Add(
                    new PlaneType
                    { 
                        Model = "Model3",
                        FleightLength = 10000,
                        MaxHeight = 8000,
                        MaxMass = 80000,
                        Places = 90,
                        Speed = 900
                    }
                    );
                context.SaveChanges();
            }
            #endregion
            context.SaveChanges();
            #region Plane initializing
            if (!context.Planes.Any())
            {
                context.Planes.Add(
                new Plane
                {
                    Name = "Bobo",
                    Created = new DateTime(2015, 2, 1),
                    Type = context.Types.Single(x => x.Id == 1),
                    Expired = DateTime.Now.AddDays(70)
                }
                );
                context.Planes.Add(
                    new Plane
                    {
                        Name = "Gutu",
                        Created = new DateTime(2014, 2, 1),
                        Type = context.Types.Single(x => x.Id == 1),
                        Expired = DateTime.Now.AddDays(300)
        }
                    );
                context.Planes.Add(
                    new Plane
                    {
                        Name = "Ulu",
                        Created = new DateTime(2012, 6, 23),
                        Type = context.Types.Single(x => x.Id == 2),
                        Expired = DateTime.Now.AddDays(31)
                    }
                    );
                context.Planes.Add(
                    new Plane
                    {
                        Name = "Ukoz",
                        Created = new DateTime(2017, 11, 14),
                        Type = context.Types.Single(x => x.Id == 2),
                        Expired = DateTime.Now.AddDays(700)
                    }
                    );
                context.SaveChanges();
            }
            #endregion
            #region Departure initializing
            if (!context.Depatures.Any())
            {
                context.Depatures.Add(
                new Departure
                {
                    Flight = context.Flights.Single(x => x.Id == 1),
                    Date = new DateTime(2018, 11, 14),
                    Plane = context.Planes.Single(x => x.Id == 1),
                    Crew = context.Crew.Single(x => x.Id == 1)
                }
                );
                context.Depatures.Add(
                    new Departure
                    {
                        Flight = context.Flights.Single(x => x.Id == 1),
                        Date = new DateTime(2018, 10, 14),
                        Plane = context.Planes.Single(x => x.Id == 2),
                        Crew = context.Crew.Single(x => x.Id == 3)
                    }
                    );
                context.Depatures.Add(
                    new Departure
                    {
                        Flight = context.Flights.Single(x => x.Id == 2),
                        Date = new DateTime(2018, 8, 10),
                        Plane = context.Planes.Single(x => x.Id == 3),
                        Crew = context.Crew.Single(x => x.Id == 2)
                    }
                    );
                context.Depatures.Add(
                    new Departure
                    {
                        Flight = context.Flights.Single(x => x.Id == 3),
                        Date = new DateTime(2018, 8, 15),
                        Plane = context.Planes.Single(x => x.Id == 4),
                        Crew = context.Crew.Single(x => x.Id == 1)
                    }
                    );
                
            }
            #endregion
            context.SaveChanges();

        }

        
    }
}