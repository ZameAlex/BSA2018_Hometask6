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
    public class TicketService_Tests
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;
        TicketService service;
        [SetUp]
        public void SetUp()
        {
            unitOfWork = new FakeUnitOfWork();
            mapper = new Mapping(unitOfWork);
            service = new TicketService(unitOfWork, mapper, new TicketValidator());
        }

        [Test]
        public void ExceptionThrows_When_TicketModel_is_not_valid_Then_throws_ValidatorException()
        {
            var ticket1 = new TicketDto()
            {
                ID = -1,
                Number = Guid.NewGuid(),
                Price = 290m
            };
            var ticket2 = new TicketDto()
            {
                Number = Guid.Empty,
                Price = 290m
            };
            var ticket3 = new TicketDto()
            {
                Number = Guid.NewGuid()
            };

            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(ticket1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(ticket2));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(ticket3));

        }

        [Test]
        public void Update_When_TicketModel_is_not_valid_Then_throws_ValidatorException()
        {
            var ticket1 = new TicketDto()
            {
                ID = -1,
                Number = Guid.NewGuid(),
                Price = 290m
            };
            var ticket2 = new TicketDto()
            {
                Number = Guid.Empty,
                Price = 290m
            };
            var ticket3 = new TicketDto()
            {
                Number = Guid.NewGuid()
            };
            var id = 1;
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(ticket1, id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(ticket2, id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(ticket3, id));
        }


        [Test]
        public void Create_When_TicketModel_is_valid_Then_returns_id()
        {
            var flightService = new FlightService(unitOfWork, mapper, new FlightValidator());
            var expectedTicket = new TicketDto()
            {
                Number = flightService.Get(1).Number,
                Price = 290m
            };

            var id = service.Create(expectedTicket);
            var actualTicket = service.Get(id);
            Assert.AreEqual(expectedTicket.Price, actualTicket.Price);
            


        }

        [Test]
        public void Update_When_TicketModel_is_valid_Then_Ticket_changed()
        {
            var flightService = new FlightService(unitOfWork, mapper, new FlightValidator());
            var expectedTicket = new TicketDto()
            {
                Number = flightService.Get(1).Number,
                Price = 290m
            };

            var id = 1;
            service.Update(expectedTicket, id);
            var actualTicket = service.Get(id);
            Assert.AreEqual(expectedTicket.Price, actualTicket.Price);


        }
    }
}
