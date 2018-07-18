
using BSA2018_Hometask4.BLL.Interfaces;
using BSA2018_Hometask4.Shared.DTO;
using BSA2018_Hometask4.Shared.Exceptions;
using DAL.Models;
using DAL.Repository;
using DAL.UnitOfWork;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.BLL.Services
{
    public class CrewService : ICrewService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<CrewDto> validator;

        public CrewService(IUnitOfWork uow, IMapper map, AbstractValidator<CrewDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public int Create(CrewDto Crew)
        {
            var validationResult = validator.Validate(Crew);
            if (validationResult.IsValid)
            {
                return unit.Crew.Create(mapper.MapCrew(Crew));
            }
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Delete(int id)
        {
            unit.Crew.Delete(id);
        }

        public void Delete(CrewDto Crew)
        {
            unit.Crew.Delete(mapper.MapCrew(Crew));
        }

        public CrewDto Get(int id)
        {
            return mapper.MapCrew(unit.Crew.Get(id));
        }

        public List<CrewDto> Get()
        {
            var result = new List<CrewDto>();
            foreach(var item in unit.Crew.Get())
            {
                result.Add(mapper.MapCrew(item));
            }
            return result;
        }

        public void Update(CrewDto Crew, int id)
        {
            var validationResult = validator.Validate(Crew);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                Crew.ID = id;
                unit.Crew.Update(mapper.MapCrew(Crew), id);
            }
            catch(ArgumentNullException)
            {
                throw new NotFoundException();
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
