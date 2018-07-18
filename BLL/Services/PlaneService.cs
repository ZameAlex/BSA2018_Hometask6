
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
    public class PlaneService : IPlaneService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<PlaneDto> validator;

        public PlaneService(IUnitOfWork uow, IMapper map, AbstractValidator<PlaneDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public int Create(PlaneDto Plane)
        {
            var validationResult = validator.Validate(Plane);
            if (validationResult.IsValid)
                return unit.Planes.Create(mapper.MapPlane(Plane));
            else
                throw new ValidationException(validationResult.Errors);
            
        }

        public void Delete(int id)
        {
            unit.Planes.Delete(id);
        }

        public void Delete(PlaneDto Plane)
        {
            unit.Planes.Delete(mapper.MapPlane(Plane));
        }

        public PlaneDto Get(int id)
        {
            return mapper.MapPlane(unit.Planes.Get(id));
        }

        public List<PlaneDto> Get()
        {
            var result = new List<PlaneDto>();
            foreach (var item in unit.Planes.Get())
            {
                result.Add(mapper.MapPlane(item));
            }
            return result;
        }

        public void Update(PlaneDto Plane, int id)
        {
            var validationResult = validator.Validate(Plane);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                Plane.ID = id;
                unit.Planes.Update(mapper.MapPlane(Plane), id);
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

        public void Update(TimeSpan expires, int id)
        {
            var validationResult = validator.Validate(new PlaneDto() { Expires = expires }, "Expires");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                (unit.Planes as PlaneRepository).Update(DateTime.Now.AddDays(expires.Days), id);
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
