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
    public class CrewService_Tests
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;
        CrewService service;
        [SetUp]
        public void SetUp()
        {
            unitOfWork = new FakeUnitOfWork();
            mapper = new Mapping(unitOfWork);
            service = new CrewService(unitOfWork, mapper, new CrewValidator());
        }

        [Test]
        public void Create_When_CrewModel_is_not_valid_Then_throws_ValidatorException()
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
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(crew1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(crew2));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(crew3));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(crew4));
        }

        [Test]
        public void Update_When_CrewModel_is_not_valid_Then_throws_ValidatorException()
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
            var id = 1;

            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(crew1,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(crew2,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(crew3,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(crew4,id));
        }


        [Test]
        public void Create_When_CrewModel_is_valid_Then_returns_id()
        {
            var expectedCrew = new CrewDto()
            {
                Pilot = 1,
                Stewadress = new List<int>() { 1 }
            };

            var id = service.Create(expectedCrew);
            var actualCrew = service.Get(id);
            Assert.AreEqual(expectedCrew.Pilot, actualCrew.Pilot);
            for (int i = 0; i < expectedCrew.Stewadress.Count; i++)
            {
                Assert.AreEqual(expectedCrew.Stewadress[i], actualCrew.Stewadress[i]);
            }
            

        }

        [Test]
        public void Update_When_CrewModel_is_valid_Then_crew_changed()
        {
            var expectedCrew = new CrewDto()
            {
                Pilot = 1,
                Stewadress = new List<int>() { 1 }
            };

            var id = 1;
            service.Update(expectedCrew,id);
            var actualCrew = service.Get(id);
            Assert.AreEqual(expectedCrew.Pilot, actualCrew.Pilot);
            for (int i = 0; i < expectedCrew.Stewadress.Count; i++)
            {
                Assert.AreEqual(expectedCrew.Stewadress[i], actualCrew.Stewadress[i]);
            }


        }
    }
}
