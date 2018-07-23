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
    public class PlaneService_Tests
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;
        PlaneService service;
        [SetUp]
        public void SetUp()
        {
            unitOfWork = new FakeUnitOfWork();
            mapper = new Mapping(unitOfWork);
            service = new PlaneService(unitOfWork, mapper, new PlaneValidator());
        }

        [Test]
        public void Create_When_PlaneModel_is_not_valid_Then_throws_ValidatorException()
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
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(plane1));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(plane2));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(plane3));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Create(plane4));
        }

        [Test]
        public void Update_When_PlaneModel_is_not_valid_Then_throws_ValidatorException()
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
            var id = 1;
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(plane1,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(plane2,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(plane3,id));
            Assert.Throws<FluentValidation.ValidationException>(() => service.Update(plane4,id));
        }


        [Test]
        public void Create_When_PlaneModel_is_valid_Then_returns_id()
        {
            var expectedPlane = new PlaneDto()
            {
                Name = "name",
                Created = DateTime.Now,
                Expires = new TimeSpan(33, 0, 0, 0),
                Type = 1
            };
            var id = service.Create(expectedPlane);
            var actualPlane = service.Get(id);
            Assert.AreEqual(expectedPlane.Created, actualPlane.Created);

        }

        [Test]
        public void Update_When_PlaneModel_is_valid_Then_plane_changed()
        {
            var expectedPlane = new PlaneDto()
            {
                Name = "name",
                Created = DateTime.Now,
                Expires = new TimeSpan(33, 0, 0, 0),
                Type = 1
            };
            var id = 1;
            service.Update(expectedPlane, id);
            var actualPlane = service.Get(id);
            Assert.AreEqual(expectedPlane.Created, actualPlane.Created);

        }

        [Test]
        public void Update_expired_When_expired_is_valid_Then_plane_changed()
        {
            var id = 1;
            var prevTime = service.Get(id);
            TimeSpan timeSpan = new TimeSpan(40, 0, 0, 0);
            service.Update(timeSpan, id);
            var actualTime = service.Get(id).Expires;
            Assert.AreEqual(timeSpan.Days, actualTime.Days+1);
            Assert.AreNotEqual(prevTime, actualTime);

        }

        [Test]
        public void Update_expired_When_expired_is_not_valid_Then_plane_changed()
        {
            var id = 1;
            var prevTime = service.Get(id);
            TimeSpan timeSpan = new TimeSpan(29, 0, 0, 0);
            Assert.Throws<FluentValidation.ValidationException>(()=> service.Update(timeSpan, id));
           

        }

    }
}
