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
    public class PilotService : IPilotService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<PilotDto> validator;

        public PilotService(IUnitOfWork uow, IMapper map, AbstractValidator<PilotDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public int Create(PilotDto Pilot)
        {
            var validationResult = validator.Validate(Pilot);
            if (validationResult.IsValid)
                return unit.Pilots.Create(mapper.MapPilot(Pilot));
            else
                throw new ValidationException(validationResult.Errors);
            
        }

        public void Delete(int id)
        {
            unit.Pilots.Delete(id);
        }

        public void Delete(PilotDto Pilot)
        {
            unit.Pilots.Delete(mapper.MapPilot(Pilot));
        }

        public PilotDto Get(int id)
        {
            return mapper.MapPilot(unit.Pilots.Get(id));
        }

        public List<PilotDto> Get()
        {
            var result = new List<PilotDto>();
            foreach (var item in unit.Pilots.Get())
            {
                result.Add(mapper.MapPilot(item));
            }
            return result;
        }

        public void Update(PilotDto Pilot, int id)
        {
            var validationResult = validator.Validate(Pilot);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                Pilot.ID = id;
                unit.Pilots.Update(mapper.MapPilot(Pilot), id);
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundException();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void Update(int experience, int id)
        {
            var validationResult = validator.Validate(new PilotDto() { Experience = experience }, "Experience");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                (unit.Pilots as PilotRepository).Update(experience, id);
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundException();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
