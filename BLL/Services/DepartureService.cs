using BSA2018_Hometask4.BLL.Interfaces;
using BSA2018_Hometask4.Shared.DTO;
using DAL.Models;
using DAL.Repository;
using DAL.UnitOfWork;
using FluentValidation;
using System;
using System.Collections.Generic;
using BSA2018_Hometask4.Shared.Exceptions;
using System.Text;


namespace BSA2018_Hometask4.BLL.Services
{
    public class DepartureService : IDepartureService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<DepartureDto> validator;

        public DepartureService(IUnitOfWork uow, IMapper map, AbstractValidator<DepartureDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public int Create(DepartureDto departure)
        {
            var validationResult = validator.Validate(departure);
            if (validationResult.IsValid)
                return unit.Departures.Create(mapper.MapDeparture(departure));
            else
                throw new ValidationException(validationResult.Errors);
            
        }

        public void Delete(int id)
        {
            unit.Departures.Delete(id);
        }

        public void Delete(DepartureDto departure)
        {
            unit.Departures.Delete(mapper.MapDeparture(departure));
        }

        public DepartureDto Get(int id)
        {
            return mapper.MapDeparture(unit.Departures.Get(id));
        }

        public List<DepartureDto> Get()
        {
            var result = new List<DepartureDto>();
            foreach (var item in unit.Departures.Get())
            {
                result.Add(mapper.MapDeparture(item));
            }
            return result;
        }

        public void Update(DepartureDto departure, int id)
        {
            var validationResult = validator.Validate(departure);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                departure.ID = id;
                unit.Departures.Update(mapper.MapDeparture(departure), id);
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

        public void Update(DateTime date, int id)
        {
            var validationResult = validator.Validate(new DepartureDto() { Date = date }, "Date");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                (unit.Departures as DepartureRepository).Update(date, id);
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
