using BSA2018_Hometask4.BLL.Interfaces;
using BSA2018_Hometask4.BLL.Mapping;
using BSA2018_Hometask4.BLL.Services;
using BSA2018_Hometask4.BLL.Validators;
using BSA2018_Hometask4.Shared.DTO;
using BSA2018_Hometask6.Tests.Fake.UnitOfWork;
using DAL.UnitOfWork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask6.Tests.ServicesTests
{
    [TestFixture]
    public class FlightService_Tests
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;
        FlightService service;
        [SetUp]
        public void SetUp()
        {
            unitOfWork = new FakeUnitOfWork();
            mapper = new Mapping(unitOfWork);
            service = new FlightService(unitOfWork, mapper, new FlightValidator());
        }

        [Test]
        public void Create_When_FlightModel_is_not_valid_Then_throws_ValidatorException()
        {
            var tickets = service.Get(1).Tickets;
            var flight1 = new FlightDto()
            {
                ID = -1,
                DeparturePoint = "Kyiv",
                DepartureTime = DateTime.Now,
                Destination = "Lviv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid(),
                Tickets = tickets
            };
            var flight2 = new FlightDto()
            {
                DepartureTime = DateTime.Now,
                Destination = "Lviv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid(),
                Tickets = tickets
            };
            var flight3 = new FlightDto()
            {
                DeparturePoint = "Kyiv",
                DepartureTime = DateTime.Now,
                Destination = "Lviv",
                DestinationTime = DateTime.Now,
                Number = Guid.NewGuid(),
                Tickets = tickets
            };
            var flight4 = new FlightDto()
            {
                DeparturePoint = "Kyiv",
                DepartureTime = DateTime.Now,
                Destination = "Kyiv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid(),
                Tickets = tickets
            };

            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(flight1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(flight2));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(flight3));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(flight4));
        }

        [Test]
        public void Create_When_Tickets_are_empty_Then_throws_NullReferenceException()
        {
            var flight1 = new FlightDto()
            {
                DeparturePoint = "Kyiv",
                DepartureTime = DateTime.Now,
                Destination = "Lviv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid()
            };
            

            Assert.Throws<NullReferenceException>(() => service.Create(flight1));

        }

        [Test]
        public void Update_When_FlightModel_is_not_valid_Then_throws_ValidatorException()
        {
            var flight1 = new FlightDto()
            {
                ID = -1,
                DeparturePoint = "Kyiv",
                DepartureTime = DateTime.Now,
                Destination = "Lviv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid(),
            };
            var flight2 = new FlightDto()
            {
                DepartureTime = DateTime.Now,
                Destination = "Lviv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid(),
            };
            var flight3 = new FlightDto()
            {
                DeparturePoint = "Kyiv",
                DepartureTime = DateTime.Now,
                Destination = "Lviv",
                DestinationTime = DateTime.Now,
                Number = Guid.NewGuid(),
            };
            var flight4 = new FlightDto()
            {
                DeparturePoint = "Kyiv",
                DepartureTime = DateTime.Now,
                Destination = "Kyiv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid(),
            };
            var id = 1;

            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(flight1,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(flight2,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(flight3,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(flight4,id));
        }

        [Test]
        public void Create_When_FlightModel_is_valid_Then_returns_id()
        {
            var expectedFlight = new FlightDto()
            {
                DeparturePoint = "Kyiv",
                DepartureTime = DateTime.Now,
                Destination = "Lviv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid(),
            };

            expectedFlight.Tickets = new List<int> { 1 };

            var id = service.Create(expectedFlight);
            var actualFlight = service.Get(id);
            Assert.AreEqual(expectedFlight.Number, actualFlight.Number);
        }

        [Test]
        public void Update_When_FlightModel_is_valid_Then_flight_changed()
        {
            var id = 1;
            var tickets = service.Get(id).Tickets;
            var expectedFlight = new FlightDto()
            {
                DeparturePoint = "Kyiv",
                DepartureTime = DateTime.Now,
                Destination = "Lviv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid(),
                Tickets = tickets
            };
            
            service.Update(expectedFlight,id);
            var actualFlight = service.Get(id);
            Assert.AreEqual(expectedFlight.Number, actualFlight.Number);
        }

        [Test]
        public void Update_dates_When_dates_are_valid_Then_plane_changed()
        {
            var id = 1;
            var prevFlight = service.Get(id);
            var departureTime = DateTime.Now.AddDays(-1);
            var destinationTime = DateTime.Now;
            service.Update(departureTime, destinationTime, id);
            var actualFlight = service.Get(id);
            Assert.AreEqual(departureTime, actualFlight.DepartureTime);
            Assert.AreEqual(destinationTime, actualFlight.DestinationTime);
            Assert.AreNotEqual(prevFlight.DepartureTime, actualFlight.DepartureTime);
            Assert.AreNotEqual(prevFlight.DestinationTime, actualFlight.DestinationTime);

        }

        [Test]
        public void Update_dates_When_dates_are_not_valid_Then_plane_changed()
        {
            var id = 1;
            var prevFlight = service.Get(id);
            var departureTime = DateTime.Now;
            var destinationTime = departureTime;
            Assert.Throws<FluentValidation.ValidationException>(()=> service.Update(departureTime, destinationTime, id));
        }
    }
}
