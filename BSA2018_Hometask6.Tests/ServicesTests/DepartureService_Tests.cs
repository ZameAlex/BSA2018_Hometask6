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
    public class DepartureService_Tests
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;
        DepartureService service;
        [SetUp]
        public void SetUp()
        {
            unitOfWork = new FakeUnitOfWork();
            mapper = new Mapping(unitOfWork);
            service = new DepartureService(unitOfWork, mapper, new DepartureValidator());
        }

        [Test]
        public void Create_When_DepartureModel_is_not_valid_Then_throws_ValidatorException()
        {
            var departure1 = new DepartureDto()
            {
                ID = -1,
                Date = DateTime.Now,
                Number = Guid.NewGuid(),
                CrewId = 1,
                PlaneId = 1
            };
            var departure2 = new DepartureDto()
            {
                Date = DateTime.Now,
                Number = Guid.Empty,
                CrewId = 1,
                PlaneId = 1
            };
            var departure3 = new DepartureDto()
            {
                Date = DateTime.Now,
                Number = Guid.NewGuid(),
                CrewId = 0,
                PlaneId = 1
            };
            var departure4 = new DepartureDto()
            {
                Date = DateTime.Now,
                Number = Guid.NewGuid(),
                PlaneId = 1
            };
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(departure1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(departure2));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(departure3));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(departure4));
        }

        [Test]
        public void Update_When_DepartureModel_is_not_valid_Then_throws_ValidatorException()
        {
            var departure1 = new DepartureDto()
            {
                ID = -1,
                Date = DateTime.Now,
                Number = Guid.NewGuid(),
                CrewId = 1,
                PlaneId = 1
            };
            var departure2 = new DepartureDto()
            {
                Date = DateTime.Now,
                Number = Guid.Empty,
                CrewId = 1,
                PlaneId = 1
            };
            var departure3 = new DepartureDto()
            {
                Date = DateTime.Now,
                Number = Guid.NewGuid(),
                CrewId = 0,
                PlaneId = 1
            };
            var departure4 = new DepartureDto()
            {
                Date = DateTime.Now,
                Number = Guid.NewGuid(),
                PlaneId = 1
            };
            var id = 1;
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(departure1,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(departure2,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(departure3,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(departure4,id));
        }

        [Test]
        public void Create_When_DepartureModel_is_valid_Then_returns_id()
        {
            var flightService = new FlightService(unitOfWork, mapper, new FlightValidator());
            var expectedDeparture = new DepartureDto()
            {
                Date = DateTime.Now,
                Number = flightService.Get(1).Number,
                CrewId = 1,
                PlaneId = 1
            };

            var id = service.Create(expectedDeparture);
            var actualDeparture = service.Get(id);

            Assert.AreEqual(expectedDeparture.Date, actualDeparture.Date);
            Assert.AreEqual(expectedDeparture.Number, actualDeparture.Number);

        }

        [Test]
        public void Update_When_DepartureModel_is_valid_Then_departure_changed()
        {
            var flightService = new FlightService(unitOfWork, mapper, new FlightValidator());
            var expectedDeparture = new DepartureDto()
            {
                Date = DateTime.Now,
                Number = flightService.Get(1).Number,
                CrewId = 1,
                PlaneId = 1
            };
            var id = 1;
            service.Update(expectedDeparture, id);
            var actualDeparture = service.Get(id);

            Assert.AreEqual(expectedDeparture.Date, actualDeparture.Date);
            Assert.AreEqual(expectedDeparture.Number, actualDeparture.Number);

        }

        [Test]
        public void Update_date_When_date_is_valid_Then_departure_changed()
        {
            var date = DateTime.Now.AddYears(-1);
            var id = 1;
            var prevDate = service.Get(id).Date;
            service.Update(date, id);
            var actualDeparture = service.Get(id);

            Assert.AreEqual(date,actualDeparture.Date);
            Assert.AreNotEqual(date, prevDate);

        }

        [Test]
        public void Update_date_When_date_is_not_valid_Then_departure_changed()
        {
            var date = new DateTime();
            var id = 1;
            var prevDate = service.Get(id).Date;
            Assert.Throws<FluentValidation.ValidationException> (()=>service.Update(date, id));

        }

    }
}
