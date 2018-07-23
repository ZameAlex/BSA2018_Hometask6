using BSA2018_Hometask4.BLL.Interfaces;
using BSA2018_Hometask4.BLL.Mapping;
using BSA2018_Hometask4.BLL.Services;
using BSA2018_Hometask4.BLL.Validators;
using BSA2018_Hometask4.DAL.DbContext;
using BSA2018_Hometask4.Shared.DTO;
using DAL.UnitOfWork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSA2018_Hometask6.Tests.DBTests
{
    [TestFixture]
    public class DB_Tests
    {
        AirportContext context;
        IUnitOfWork unitOfWork;
        IMapper mapper;

        [OneTimeSetUp]
        public void SetContext()
        {
            context = new AirportContext();
            context.Database.EnsureDeleted();
            new DataSource(context);
            unitOfWork = new UnitOfWork();
            mapper = new Mapping(unitOfWork);
            
        }
    
        [Test]
        public void Create_Pilot_When_get_Then_find()
        {
            var pilotService = new PilotService(unitOfWork, mapper, new PilotValidator());
            var id = pilotService.Create(new BSA2018_Hometask4.Shared.DTO.PilotDto
            {
                Birthday = DateTime.Now.AddYears(-30),
                Experience = 3,
                FirstName = "Oleksii",
                LastName = "Bogdanovych"
            });

            Assert.AreEqual(id, pilotService.Get(id).ID);
            pilotService.Delete(id);
        }

        [Test]
        public void Get_by_id_When_is_not_exists_Then_throws_NullReferenceException()
        {
            var pilotService = new PilotService(unitOfWork, mapper, new PilotValidator());
            var id = 1123;

            Assert.Throws<NullReferenceException>(()=>pilotService.Get(id));
        }

        [Test]
        public void Create_Plane_When_model_is_not_valid_Then_throws_ValidatorExceprion()
        {
            var planeService = new PlaneService(unitOfWork, mapper, new PlaneValidator());
            var plane = new PlaneDto()
            {
                Name = "Bobo",
                Type = 1,
                Created = new DateTime(2013, 08, 03),
                Expires = new TimeSpan(29, 0, 0, 0)
            };

            Assert.Throws<FluentValidation.ValidationException>(() => planeService.Create(plane));
        }

        [Test]
        public void Delete_Crew_When_search_by_id_Then_throws_NullReferenceException()
        {
            var crewService = new CrewService(unitOfWork, mapper, new CrewValidator());

            var id = crewService.Create(new CrewDto()
            {
                Pilot = 1,
                Stewadress = new List<int>() { 1 }
            });
            crewService.Delete(id);
            Assert.Throws<NullReferenceException>(() => crewService.Get(id));
        }

        [Test]
        public void Update_Plane_When_model_is_not_valid_Then_throws_ValidatorException()
        {
            var planeService = new PlaneService(unitOfWork, mapper, new PlaneValidator());
            var id = 1;
            var plane = new PlaneDto()
            {
                Name = "Bobo",
                Type = 1,
                Created = new DateTime(2013, 08, 03),
                Expires = new TimeSpan(29, 0, 0, 0)
            };

            Assert.Throws<FluentValidation.ValidationException>(() => planeService.Update(plane,id));
        }

        [Test]
        public void Update_Plane_When_model_is_valid_Then_get_right_value_through_mapping()
        {
            var planeService = new PlaneService(unitOfWork, mapper, new PlaneValidator());
            var id = 1;
            var plane = new PlaneDto()
            {
                Name = "Bobo",
                Type = 1,
                Created = new DateTime(2013, 08, 03),
                Expires = new TimeSpan(750, 0, 0, 0)
            };

            planeService.Update(plane, id);
            var planeResult = planeService.Get(id);
            Assert.AreEqual(plane.Created, planeResult.Created);
        }

        [Test]
        public void Delete_Plane_When_not_exists_Then_throws_ArgumentNullException()
        {
            var planeService = new PlaneService(unitOfWork, mapper, new PlaneValidator());
            var id = 1123;
            Assert.Throws<ArgumentNullException>(() => planeService.Delete(id));
        }

        [Test]
        public void Pilots_When_get_from_get_all_by_id_and_get_by_id_Then_results_are_equals()
        {
            var pilotService = new PilotService(unitOfWork, mapper, new PilotValidator());
            var id = 2;
            var pilots = pilotService.Get();
            var pilot = pilotService.Get(id);
            var resultFromList = pilots.SingleOrDefault(x => x.ID == id);
            Assert.AreEqual(pilot.Birthday, resultFromList.Birthday);
            Assert.AreEqual(pilot.FirstName, resultFromList.FirstName);
            Assert.AreEqual(pilot.LastName, resultFromList.LastName);
            Assert.AreEqual(pilot.Experience, resultFromList.Experience);
        }

        [Test]
        public void Update_Plane_When_update_expires_date_Then_results_are_in_db()
        {
            var planeService = new PlaneService(unitOfWork, mapper, new PlaneValidator());
            var id = 2;
            var oldValue = planeService.Get(id).Expires;
            planeService.Update(new TimeSpan(900, 0, 0, 0), id);
            var newValue = planeService.Get(id).Expires;
            Assert.AreNotEqual(oldValue, newValue);
        }

        [Test]
        public void Update_Plane_When_id_is_not_in_db_Then_throws_NullReferenceException()
        {
            var planeService = new PlaneService(unitOfWork, mapper, new PlaneValidator());
            var id = 1123;
            var plane = new PlaneDto()
            {
                Name = "Bobo",
                Type = 1,
                Created = new DateTime(2013, 08, 03),
                Expires = new TimeSpan(750, 0, 0, 0)
            };
            Assert.Throws<NullReferenceException>(() => planeService.Update(plane, id));
        }
    }
}
