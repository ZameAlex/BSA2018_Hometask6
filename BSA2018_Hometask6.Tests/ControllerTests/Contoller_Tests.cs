using BSA2018_Hometask4.BLL.Interfaces;
using BSA2018_Hometask4.Controllers;
using BSA2018_Hometask4.Shared.DTO;
using BSA2018_Hometask4.Shared.Exceptions;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask6.Tests.ControllerTests
{
    [TestFixture]
    public class Contoller_Tests
    {
        [Test]
        public void Get_When_get_called_Then_return_status_code_200()
        {
            var service = A.Fake<IPilotService>();
            A.CallTo(() => service.Get()).Returns(new List<PilotDto>());
            var controller = new PilotsController(service);

            var result = controller.Get() as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void Get_When_get_by_id_called_and_id_dont_exists_Then_return_status_code_404()
        {
            var service = A.Fake<IPilotService>();
            var id = 23221;
            A.CallTo(() => service.Get(id)).Throws(new Exception());
            var controller = new PilotsController(service);

            var result = controller.Get(id) as ObjectResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void Post_When_model_is_not_valid_Then_return_status_code_404()
        {
            var service = A.Fake<IPilotService>();
            var pilot = new PilotDto()
            {
                Birthday = DateTime.Now,
                Experience = 3,
                FirstName = "Alex",
                LastName = "Zams"
            };
            A.CallTo(() => service.Create(pilot)).Throws(new FluentValidation.ValidationException(""));
            var controller = new PilotsController(service);

            var result = controller.Post(pilot) as ObjectResult;

            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void Post_When_model_is_valid_Then_return_status_code_200()
        {
            var service = A.Fake<IPilotService>();
            var pilot = new PilotDto()
            {
                Birthday = DateTime.Now.AddYears(-30),
                Experience = 3,
                FirstName = "Alex",
                LastName = "Zams"
            };
            A.CallTo(() => service.Create(pilot)).Returns(1);
            var controller = new PilotsController(service);

            var result = controller.Post(pilot) as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void Patch_When_model_is_not_valid_Then_return_status_code_400()
        {
            var service = A.Fake<IPilotService>();
            A.CallTo(() => service.Update(1,1)).Throws(new FluentValidation.ValidationException(""));
            var controller = new PilotsController(service);

            var result = controller.Patch(1,1) as ObjectResult;

            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void Patch_When_opject_is_not_found_Then_return_status_code_404()
        {
            var service = A.Fake<IPilotService>();
            A.CallTo(() => service.Update(1, 1)).Throws(new NotFoundException());
            var controller = new PilotsController(service);

            var result = controller.Patch(1, 1) as ObjectResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void Patch_When_model_is_valid_Then_return_status_code_200()
        {
            var service = A.Fake<IPilotService>();
            A.CallTo(() => service.Update(1, 1));
            var controller = new PilotsController(service);

            var result = controller.Patch(1, 1) as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
