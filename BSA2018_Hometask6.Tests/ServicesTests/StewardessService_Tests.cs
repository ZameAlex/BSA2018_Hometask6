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
    public class StewardessService_Tests
    {

        IUnitOfWork unitOfWork;
        IMapper mapper;
        StewardessService service;
        [SetUp]
        public void SetUp()
        {
            unitOfWork = new FakeUnitOfWork();
            mapper = new Mapping(unitOfWork);
            service = new StewardessService(unitOfWork, mapper, new StewardessValidator());
        }


        [Test]
        public void Create_When_StewardessModel_is_not_valid_Then_throws_ValidatorException()
        {
            var stewardess1 = new StewardessDto()
            {
                ID = -1,
                Birthday = DateTime.Now.AddYears(-20),
                FirstName = "Ksu",
                LastName = "Black"
            };

            var stewardess2 = new StewardessDto()
            {
                Birthday = DateTime.Now.AddYears(-17),
                FirstName = "Ksu",
                LastName = "Black"
            };

            var stewardess3 = new StewardessDto()
            {
                Birthday = DateTime.Now.AddYears(-20),
                LastName = "Black"
            };


            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(stewardess1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(stewardess2));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(stewardess3));
        }

        [Test]
        public void Update_When_StewardessModel_is_not_valid_Then_throws_ValidatorException()
        {
            var stewardess1 = new StewardessDto()
            {
                ID = -1,
                Birthday = DateTime.Now.AddYears(-20),
                FirstName = "Ksu",
                LastName = "Black"
            };

            var stewardess2 = new StewardessDto()
            {
                Birthday = DateTime.Now.AddYears(-17),
                FirstName = "Ksu",
                LastName = "Black"
            };

            var stewardess3 = new StewardessDto()
            {
                Birthday = DateTime.Now.AddYears(-20),
                LastName = "Black"
            };


            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(stewardess1, 1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(stewardess2, 1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(stewardess3, 1));
        }

        [Test]
        public void Create_When_StewardessModel_is_valid_Then_return_id()
        {
            var expectedStewardess = new StewardessDto()
            {
                Birthday = DateTime.Now.AddYears(-20),
                FirstName = "Ksu",
                LastName = "Black"
            };

            int id = service.Create(expectedStewardess);
            var actualStewardess = service.Get(id);
            Assert.AreEqual(expectedStewardess.FirstName, actualStewardess.FirstName);
            Assert.AreEqual(expectedStewardess.LastName, actualStewardess.LastName);
            Assert.AreEqual(expectedStewardess.Birthday, actualStewardess.Birthday);

        }

        [Test]
        public void Update_When_StewardessModel_is_valid_Then_Stewardess_changed()
        {
            var expectedStewardess = new StewardessDto()
            {
                Birthday = DateTime.Now.AddYears(-20),
                FirstName = "Ksu",
                LastName = "Black"
            };
            var id = 1;

            service.Update(expectedStewardess, id);
            var actualStewardess = service.Get(id);
            Assert.AreEqual(expectedStewardess.FirstName, actualStewardess.FirstName);
            Assert.AreEqual(expectedStewardess.LastName, actualStewardess.LastName);
            Assert.AreEqual(expectedStewardess.Birthday, actualStewardess.Birthday);

        }

    }
}
