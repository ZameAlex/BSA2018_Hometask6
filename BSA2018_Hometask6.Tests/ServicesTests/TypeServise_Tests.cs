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
    public class TypeService_Tests
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;
        TypeService service;
        [SetUp]
        public void SetUp()
        {
            unitOfWork = new FakeUnitOfWork();
            mapper = new Mapping(unitOfWork);
            service = new TypeService(unitOfWork, mapper, new TypeValidator());
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

            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(type1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(type2));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(type3));
        }

        [Test]
        public void Update_When_TypeModel_is_not_valid_Then_throws_ValidatorException()
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
            var id = 1;
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(type1,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(type2,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(type3,id));
        }


        [Test]
        public void Create_When_TypeModel_is_valid_Then_returns_id()
        {
            var expectedType = new TypeDto()
            {
                FleightLength = 900,
                MaxHeight = 900,
                Model = "Model",
                MaxMass = 72,
                Places = 300,
                Speed = 400
            };

            var id = service.Create(expectedType);
            var actualType = service.Get(id);
            Assert.AreEqual(expectedType.Model, actualType.Model);
            Assert.AreEqual(expectedType.FleightLength, actualType.FleightLength);
            Assert.AreEqual(expectedType.MaxHeight, actualType.MaxHeight);
            Assert.AreEqual(expectedType.MaxMass, actualType.MaxMass);
            Assert.AreEqual(expectedType.Places, actualType.Places);
            Assert.AreEqual(expectedType.Speed, actualType.Speed);


        }

        [Test]
        public void Update_When_TypeModel_is_valid_Then_Type_changed()
        {
            var expectedType = new TypeDto()
            {
                FleightLength = 900,
                MaxHeight = 900,
                Model = "Model",
                MaxMass = 72,
                Places = 300,
                Speed = 400
            };

            var id = 1;
            service.Update(expectedType, id);
            var actualType = service.Get(id);
            Assert.AreEqual(expectedType.Model, actualType.Model);
            Assert.AreEqual(expectedType.FleightLength, actualType.FleightLength);
            Assert.AreEqual(expectedType.MaxHeight, actualType.MaxHeight);
            Assert.AreEqual(expectedType.MaxMass, actualType.MaxMass);
            Assert.AreEqual(expectedType.Places, actualType.Places);
            Assert.AreEqual(expectedType.Speed, actualType.Speed);


        }
    }
}
