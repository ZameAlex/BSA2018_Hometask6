using BSA2018_Hometask4.BLL.Interfaces;
using BSA2018_Hometask4.BLL.Mapping;
using BSA2018_Hometask4.BLL.Services;
using BSA2018_Hometask4.BLL.Validators;
using BSA2018_Hometask4.Shared.DTO;
using BSA2018_Hometask6.Tests.Fake.UnitOfWork;
using DAL.UnitOfWork;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask6.Tests.ServicesTests
{
    [TestFixture]
    public class PilotService_Tests
    {

        IUnitOfWork unitOfWork;
        IMapper mapper;
        PilotService service;
        [SetUp]
        public void SetUp()
        {
            unitOfWork = new FakeUnitOfWork();
            mapper = new Mapping(unitOfWork);
            service= new PilotService(unitOfWork, mapper, new PilotValidator());
        }


        [Test]
        public void Create_When_PilotModel_is_not_valid_Then_throws_ValidatorException()
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


            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(pilot1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(pilot2));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(pilot3));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(pilot4));
        }

        [Test]
        public void Update_When_PilotModel_is_not_valid_Then_throws_ValidatorException()
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


            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(pilot1,1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(pilot2,1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(pilot3,1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(pilot4,1));
        }

        [Test]
        public void Create_When_PilotModel_is_valid_Then_return_id()
        {
            var expectedPilot = new PilotDto()
            {
                Birthday = DateTime.Now.AddYears(-30),
                FirstName = "Alex",
                LastName = "Zamekula",
                Experience = 3
            };

            int id = service.Create(expectedPilot);
            var actualPilot = service.Get(id);
            Assert.AreEqual(expectedPilot.FirstName, actualPilot.FirstName);
            Assert.AreEqual(expectedPilot.LastName, actualPilot.LastName);
            Assert.AreEqual(expectedPilot.Birthday, actualPilot.Birthday);

        }

        [Test]
        public void Update_When_PilotModel_is_valid_Then_pilot_changed()
        {
            var expectedPilot = new PilotDto()
            {
                Birthday = DateTime.Now.AddYears(-30),
                FirstName = "Alex",
                LastName = "Zamekula",
                Experience = 3
            };
            var id = 1;

            service.Update(expectedPilot,id);
            var actualPilot = service.Get(id);
            Assert.AreEqual(expectedPilot.FirstName, actualPilot.FirstName);
            Assert.AreEqual(expectedPilot.LastName, actualPilot.LastName);
            Assert.AreEqual(expectedPilot.Birthday, actualPilot.Birthday);

        }

        [Test]
        public void Update_experience_When_experience_is_valid_Then_plane_changed()
        {
            var id = 1;
            var prevExp = service.Get(id);
            var experience = 9;
            service.Update(experience, id);
            var actualExp = service.Get(id).Experience;
            Assert.AreEqual(experience, actualExp);
            Assert.AreNotEqual(prevExp, actualExp);

        }

        [Test]
        public void Update_experience_When_experience_is_not_valid_Then_plane_changed()
        {
            var id = 1;
            var prevExp = service.Get(id);
            var experience = 1;
            Assert.Throws<FluentValidation.ValidationException>(()=> service.Update(experience, id));

        }



    }
}
