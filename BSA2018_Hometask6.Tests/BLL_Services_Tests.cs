using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FakeItEasy;
using DAL.UnitOfWork;
using DAL.Models;
using BSA2018_Hometask4.Shared.DTO;
using BSA2018_Hometask4.BLL.Interfaces;
using BSA2018_Hometask4.BLL.Services;
using BSA2018_Hometask4.BLL.Validators;
using BSA2018_Hometask4.BLL.Mapping;
using BSA2018_Hometask6.Tests.Fake.UnitOfWork;
using System.Linq;

namespace BSA2018_Hometask6.Tests
{
    [TestFixture]
    public class BLL_Services_Tests
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;
        [SetUp]
        public void SetUp()
        {
            unitOfWork = new FakeUnitOfWork();
            mapper = new Mapping(unitOfWork);
        }
        
        #region ValidatorTests
        [Test]
        public void ExceptionThrows_When_PlaneModel_is_not_valid_Then_throws_ValidatorException()
        {
            var plane1 = new PlaneDto()
            {
                Name = "name",
                Created = DateTime.Now,
                Expires = new TimeSpan(2, 0, 0, 0),
                Type = 1
            };
            var plane2 = new PlaneDto()
            {
                Name = "name",
                Created = DateTime.Now,
                Expires = new TimeSpan(31, 0, 0, 0),
                Type = 0
            };
            var plane3 = new PlaneDto()
            {
                Name = "name",
                Expires = new TimeSpan(31, 0, 0, 0),
                Type = 1
            };
            var plane4 = new PlaneDto()
            {
                ID = -1,
                Name = "name",
                Created = DateTime.Now,
                Expires = new TimeSpan(31, 0, 0, 0),
                Type = 1
            };
            var planeService = new PlaneService(unitOfWork, A.Fake<IMapper>(), new PlaneValidator());
            Assert.Throws<FluentValidation.ValidationException>(() => planeService.Create(plane1));
            Assert.Throws<FluentValidation.ValidationException>(() => planeService.Create(plane2));
            Assert.Throws<FluentValidation.ValidationException>(() => planeService.Create(plane3));
            Assert.Throws<FluentValidation.ValidationException>(() => planeService.Create(plane4));
        }

        [Test]
        public void ExceptionThrows_When_CrewModel_is_not_valid_Then_throws_ValidatorException()
        {
            var crew1 = new CrewDto()
            {
                Pilot = 0,
                Stewadress = new List<int>() { 1 }
            };
            var crew2 = new CrewDto()
            {
                Pilot = 1,
                Stewadress = new List<int>() { 0 }
            };
            var crew3 = new CrewDto()
            {
                Pilot = 1
            };
            var crew4 = new CrewDto()
            {
                ID = -1,
                Pilot = 1,
                Stewadress = new List<int>() { 1 }
            };
            var crewService = new CrewService(unitOfWork, A.Fake<IMapper>(), new CrewValidator());
            Assert.Throws<FluentValidation.ValidationException>(() => crewService.Create(crew1));
            Assert.Throws<FluentValidation.ValidationException>(() => crewService.Create(crew2));
            Assert.Throws<FluentValidation.ValidationException>(() => crewService.Create(crew3));
            Assert.Throws<FluentValidation.ValidationException>(() => crewService.Create(crew4));
        }

        [Test]
        public void ExceptionThrows_When_DepartureModel_is_not_valid_Then_throws_ValidatorException()
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
            var departureService = new DepartureService(unitOfWork, A.Fake<IMapper>(), new DepartureValidator());
            Assert.Throws<FluentValidation.ValidationException>(() => departureService.Create(departure1));
            Assert.Throws<FluentValidation.ValidationException>(() => departureService.Create(departure2));
            Assert.Throws<FluentValidation.ValidationException>(() => departureService.Create(departure3));
            Assert.Throws<FluentValidation.ValidationException>(() => departureService.Create(departure4));
        }

        [Test]
        public void ExceptionThrows_When_FlightModel_is_not_valid_Then_throws_ValidatorException()
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
            var flightService = new FlightService(unitOfWork, A.Fake<IMapper>(), new FlightValidator());
            Assert.Throws<FluentValidation.ValidationException>(() => flightService.Create(flight1));
            Assert.Throws<FluentValidation.ValidationException>(() => flightService.Create(flight2));
            Assert.Throws<FluentValidation.ValidationException>(() => flightService.Create(flight3));
            Assert.Throws<FluentValidation.ValidationException>(() => flightService.Create(flight4));
        }

        [Test]
        public void ExceptionThrows_When_PilotModel_is_not_valid_Then_throws_ValidatorException()
        {
            var pilot1 = new PilotDto()
            {
                ID = -1,
                Birthday = DateTime.Now.AddYears(-30),
                FirstName = "Alex",
                LastName = "Zamekula",
                Experience = 3
            };
            var pilot2 = new PilotDto()
            {
                Birthday = DateTime.Now,
                FirstName = "Alex",
                LastName = "Zamekula",
                Experience = 3
            };
            var pilot3 = new PilotDto()
            {
                Birthday = DateTime.Now.AddYears(-30),
                FirstName = "Alex",
                LastName = "Zamekula",
                Experience = 1
            };
            var pilot4 = new PilotDto()
            {
                Birthday = DateTime.Now.AddYears(-30),
                LastName = "Zamekula",
                Experience = 4
            };

            var pilotService = new PilotService(unitOfWork, A.Fake<IMapper>(), new PilotValidator());
            Assert.Throws<FluentValidation.ValidationException>(() => pilotService.Create(pilot1));
            Assert.Throws<FluentValidation.ValidationException>(() => pilotService.Create(pilot2));
            Assert.Throws<FluentValidation.ValidationException>(() => pilotService.Create(pilot3));
            Assert.Throws<FluentValidation.ValidationException>(() => pilotService.Create(pilot4));
        }

        [Test]
        public void ExceptionThrows_When_StewardessModel_is_not_valid_Then_throws_ValidatorException()
        {
            var stewadress1 = new StewadressDto()
            {
                ID = -1,
                Birthday = DateTime.Now.AddYears(-20),
                FirstName = "Ksu",
                LastName = "Black"
            };

            var stewadress2 = new StewadressDto()
            {
                Birthday = DateTime.Now.AddYears(-17),
                FirstName = "Ksu",
                LastName = "Black"
            };

            var stewadress3 = new StewadressDto()
            {
                Birthday = DateTime.Now.AddYears(-20),
                LastName = "Black"
            };


            var stewadressService = new StewadressService(unitOfWork, A.Fake<IMapper>(), new StewadressValidator());
            Assert.Throws<FluentValidation.ValidationException>(() => stewadressService.Create(stewadress1));
            Assert.Throws<FluentValidation.ValidationException>(() => stewadressService.Create(stewadress2));
            Assert.Throws<FluentValidation.ValidationException>(() => stewadressService.Create(stewadress3));
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




            var ticketService = new TicketService(unitOfWork, A.Fake<IMapper>(), new TicketValidator());
            Assert.Throws<FluentValidation.ValidationException>(() => ticketService.Create(ticket1));
            Assert.Throws<FluentValidation.ValidationException>(() => ticketService.Create(ticket2));
            Assert.Throws<FluentValidation.ValidationException>(() => ticketService.Create(ticket3));

        }

        [Test]
        public void ExceptionThrows_When_TypeModel_is_not_valid_Then_throws_ValidatorException()
        {
            var type1 = new TypeDto()
            {
                FleightLength = 900,
                MaxHeight = 900,
                MaxMass = 72,
                Places = 300,
                Speed = 400
            };

            var type2 = new TypeDto()
            {
                FleightLength = 900,
                MaxHeight = 900,
                Model = "Model",
                MaxMass = 72,
                Places = 0,
                Speed = 400
            };

            var type3 = new TypeDto()
            {
                ID = 300,
                FleightLength = 900,
                MaxHeight = 900,
                Model = "Model",
                MaxMass = 72,
                Places = 300,
                Speed = 400
            };


            var typeService = new TypeService(unitOfWork, A.Fake<IMapper>(), new TypeValidator());
            Assert.Throws<FluentValidation.ValidationException>(() => typeService.Create(type1));
            Assert.Throws<FluentValidation.ValidationException>(() => typeService.Create(type2));
            Assert.Throws<FluentValidation.ValidationException>(() => typeService.Create(type3));
        }
        #endregion

        //Mapper testing
        //create Dto, create model, equals test
        #region MapperTests
        [Test]
        public void Mapper_When_PlaneDto_Then_map_right_PlaneModel()
        {

            SetUp();
            var planeDto = new PlaneDto()
            {
                Name = "name",
                Type = 1,
                Created = DateTime.Now,
                Expires = new TimeSpan(31, 0, 0, 0)
            };

            var expectedPlane = new Plane()
            {
                Name = "name",
                Type = new PlaneType() { Id = 1 },
                Created = DateTime.Now,
                Expired = DateTime.Now.AddDays(31)
            };

            var planeService = new PlaneService(unitOfWork, mapper, new PlaneValidator());
            planeService.Update(planeDto, 1);
            Assert.AreEqual(expectedPlane.Type.Id, planeService.Get(1).Type);
        }

        [Test]
        public void Mapper_When_DepartureDto_Then_map_right_DepartureModel()
        {
            var departureService = new DepartureService(unitOfWork, mapper, new DepartureValidator());
            var FlightService = new FlightService(unitOfWork, mapper, new FlightValidator());
            var number = FlightService.Get(1).Number;
            var departureDto = new DepartureDto()
            {
                Number= number,
                CrewId=1,
                Date=DateTime.Now,
                PlaneId=1
            };

            

            
            departureService.Update(departureDto, 1);
            var resultDeparture = departureService.Get(1);
            Assert.AreEqual(number, resultDeparture.Number);
            Assert.AreEqual(1, resultDeparture.CrewId);
            Assert.AreEqual(1, resultDeparture.PlaneId);
        }

        [Test]
        public void Mapper_When_CrewDto_Then_map_right_CrewModel()
        {
            var crewService = new CrewService(unitOfWork, mapper, new CrewValidator());
            var pilotService = new PilotService(unitOfWork, mapper, new PilotValidator());
            var crewDto = new CrewDto()
            {
                Pilot = 1,
                Stewadress = new List<int>() { 1 }

            };
            crewService.Update(crewDto, 1);
            var resultCrew = crewService.Get(1);
            Assert.AreEqual(1, resultCrew.Pilot);
            Assert.AreEqual(1, resultCrew.Stewadress.Count);
            Assert.AreEqual(1, resultCrew.Stewadress.First());
        }

        [Test]
        public void Mapper_When_Add_flight_and_update_Then_find_it_in_the_list()
        {
            var ticketService = new TicketService(unitOfWork, mapper, new TicketValidator());
            var flight1 = new FlightDto()
            {
                DeparturePoint = "Kyiv",
                DepartureTime = DateTime.Now,
                Destination = "Lviv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid(),
                Tickets=new List<int> { 1 }
            };

            var flight2 = new FlightDto()
            {
                DeparturePoint = "Lviv",
                DepartureTime = DateTime.Now,
                Destination = "Kyiv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid(),
                Tickets=new List<int> { 2 }
            };

            var flightService = new FlightService(unitOfWork, mapper, new FlightValidator());
            var id = flightService.Create(flight1);

            flightService.Update(flight2, id);
            Assert.AreEqual(flight2.Number, flightService.Get(id).Number);
        }

        [Test]
        public void Mapper_When_Add_pilot_and_update_to_invalid_Then_throws_ValidationException()
        {
            var pilot1 = new PilotDto()
            {
                Birthday = DateTime.Now.AddYears(-30),
                FirstName = "Alex",
                LastName = "Zamekula",
                Experience = 3
            };
            var pilot2 = new PilotDto()
            {
                Birthday = DateTime.Now,
                FirstName = "Alex",
                LastName = "Zamekula",
                Experience = 3
            };
           

            var pilotService = new PilotService(unitOfWork, mapper, new PilotValidator());
            var id = pilotService.Create(pilot1);
            Assert.Throws<FluentValidation.ValidationException>(() => pilotService.Update(pilot2,id));
        }

        [Test]
        public void Mapper_When_Add_Stewardess_and_update_to_invalid_Then_throws_ValidationException()
        {
            var stewadress1 = new StewadressDto()
            {
                Birthday = DateTime.Now.AddYears(-20),
                FirstName = "Ksu",
                LastName = "Black"
            };

            var stewadress2 = new StewadressDto()
            {
                Birthday = DateTime.Now.AddYears(-17),
                FirstName = "Ksu",
                LastName = "Black"
            };


            var stewadressService = new StewadressService(unitOfWork, mapper, new StewadressValidator());
            var id = stewadressService.Create(stewadress1);
            Assert.Throws<FluentValidation.ValidationException>(() => stewadressService.Update(stewadress2, id));
        }

        [Test]
        public void Mapper_When_update_ticket_Then_will_contain_new_price()
        {
            var ticketService = new TicketService(unitOfWork, mapper, new TicketValidator());
            var flightService = new FlightService(unitOfWork, mapper, new FlightValidator());
            var flight = new FlightDto()
            {
                DeparturePoint = "Kyiv",
                DepartureTime = DateTime.Now,
                Destination = "Lviv",
                DestinationTime = DateTime.Now.AddHours(2),
                Number = Guid.NewGuid(),
                Tickets = new List<int> { 1 }
            };
            var id = flightService.Create(flight);
            var ticket1 = new TicketDto()
            {
                Number = flightService.Get(id).Number,
                Price = 290m,
            };

            ticketService.Update(ticket1, 1);
            Assert.AreEqual(ticketService.Get(1).Price, ticket1.Price);
        }
        #endregion



    }
}
