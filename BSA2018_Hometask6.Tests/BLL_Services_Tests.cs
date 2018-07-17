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

namespace BSA2018_Hometask6.Tests
{
    [TestFixture]
    public class BLL_Services_Tests
    {
        [Test]
        public void ExceptionThrows_When_PlaneModel_is_not_valid_Then_throws_ValidatorException()
        {
            var plane1 = new PlaneDto()
            {
                Name="name",
                Created=DateTime.Now,
                Expires=new TimeSpan(2,0,0,0),
                Type=1
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
                Name = "name",
                Created = DateTime.Now,
                Expires = new TimeSpan(31, 0, 0, 0),
                Type = 1
            };
            var planeService = new PlaneService(A.Fake<IUnitOfWork>(), A.Fake<IMapper>(), new PlaneValidator());
            Assert.Throws<FluentValidation.ValidationException>(() => planeService.Create(plane1));
            Assert.Throws<FluentValidation.ValidationException>(() => planeService.Create(plane2));
            Assert.Throws<FluentValidation.ValidationException>(() => planeService.Create(plane3));
            Assert.Throws<FluentValidation.ValidationException>(() => planeService.Create(plane4));
        }
    }
}
