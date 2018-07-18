using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BSA2018_Hometask4.DAL.DbContext
{
    public class AirportContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public AirportContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SQLEXPRESS; Database = AirportDB; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //entities
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Departure> Depatures { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Stewadress> Stewadresses { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<PlaneType> Types { get; set; }

        public DbSet<TEntity> SetOf<TEntity>() where TEntity : Entity
        {
            if (Flights is IEnumerable<TEntity>)
            {
                Tickets.Load();
                return Flights as DbSet<TEntity>;
            }
            else if (Depatures is IEnumerable<TEntity>)
            {
                Flights.Load();
                Crew.Load();
                Planes.Load();
                return Depatures as DbSet<TEntity>;
            }
            else if (Crew is IEnumerable<TEntity>)
            {
                Pilots.Load();
                Stewadresses.Load();
                return Crew as DbSet<TEntity>;
            }
            else if (Stewadresses is IEnumerable<TEntity>)
                return Stewadresses as DbSet<TEntity>;
            else if (Pilots is IEnumerable<TEntity>)
                return Pilots as DbSet<TEntity>;
            else if (Planes is IEnumerable<TEntity>)
            {
                Types.Load();
                return Planes as DbSet<TEntity>;
            }
            else if (Types is IEnumerable<TEntity>)
                return Types as DbSet<TEntity>;
            else
            {
                Flights.Load();
                return Tickets as DbSet<TEntity>;
            }
        }
    }
}
