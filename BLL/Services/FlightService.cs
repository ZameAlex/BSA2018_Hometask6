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
    public class FlightService : IFlightService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<FlightDto> validator;

        public FlightService(IUnitOfWork uow, IMapper map, AbstractValidator<FlightDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public int Create(FlightDto flight)
        {
            var validationResult = validator.Validate(flight);
            if (validationResult.IsValid)
                return unit.Flights.Create(mapper.MapFlight(flight));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Delete(int id)
        {
            unit.Flights.Delete(id);
        }

        public void Delete(FlightDto flight)
        {
            unit.Flights.Delete(mapper.MapFlight(flight));
        }

        public FlightDto Get(int id)
        {
            return mapper.MapFlight(unit.Flights.Get(id));
        }

        public List<FlightDto> Get()
        {
            var result = new List<FlightDto>();
            foreach (var item in unit.Flights.Get())
            {
                result.Add(mapper.MapFlight(item));
            }
            return result;
        }

        public void Update(FlightDto flight, int id)
        {
            var validationResult = validator.Validate(flight);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                flight.ID = id;
                unit.Flights.Update(mapper.MapFlight(flight), id);
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

        public void Update(DateTime departureTime, DateTime destinationTime, int id)
        {
            var validationResult = validator.Validate(new FlightDto()
            {
                DepartureTime = departureTime,
                DestinationTime = destinationTime
            },
            "DepartureTime", "DestinationTime");

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                (unit.Flights as FlightRepository).Update(departureTime, destinationTime, id);
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
